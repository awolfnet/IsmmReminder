using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using IsmmReminder.Interface;
using System.Web;
using IsmmReminder.Util;
using IsmmReminder.Model;
using System.Windows.Forms;

namespace IsmmReminder.Controller
{
    public class Faults
    {
        private IFaultsBrowserView _browserView;
        private IFaultsDataView _dataView;
        private IMessage _messageView;

        private System.Timers.Timer _timerUpdate = null;
        private System.Timers.Timer _timerCheck = null;
        private System.Timers.Timer _timerSendMessage = null;
        private Dictionary<string, string> _cookies = null;

        private int draw = 0;

        public Queue<FaultsMessage> faultsMessages = new Queue<FaultsMessage>();

        public Dictionary<string, DateTime> AcknowledgeNotification = new Dictionary<string, DateTime>();
        public Dictionary<string, DateTime> CompleteNotification = new Dictionary<string, DateTime>();

        public Faults()
        {
            _cookies = new Dictionary<string, string>();
        }

        public void SetBrowserView(IFaultsBrowserView View)
        {
            this._browserView = View;
        }

        public void SetDataView(IFaultsDataView View)
        {
            _dataView = View;
        }

        public void SetMessageView(IMessage View)
        {
            _messageView = View;
        }

        public void StartMonitor()
        {
            if (_timerUpdate == null)
            {
                _timerUpdate = new System.Timers.Timer();
            }
            _timerUpdate.Elapsed += _timerUpdate_Elapsed;
            _timerUpdate.Interval = 60 * 1000;
            _timerUpdate.Start();


            if (_timerCheck == null)
            {
                _timerCheck = new System.Timers.Timer();
            }
            _timerCheck.Elapsed += _timerCheck_Elapsed;
            _timerCheck.Interval = 30 * 1000;
            _timerCheck.Start();

            if (_timerSendMessage == null)
            {
                _timerSendMessage = new System.Timers.Timer();
            }
            _timerSendMessage.Elapsed += _timerSendMessage_Elapsed;
            _timerSendMessage.Interval = 60 * 1000;
            _timerSendMessage.Start();
        }

        private void _timerSendMessage_Elapsed(object sender, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("_timerSendMessage_Elapsed");

            if (faultsMessages.Count > 0)
            {
                FaultsMessage message = faultsMessages.Dequeue();
                _messageView.SendMesage("ISMM Reminder", message.Message);
            }

            int interval = new Random(Guid.NewGuid().GetHashCode()).Next(30, 60);
            _timerSendMessage.Interval = interval * 1000;

            System.Diagnostics.Debug.WriteLine($"Send message interval: {interval}s, current message queue length: {faultsMessages.Count}");
        }

        private void _timerCheck_Elapsed(object sender, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("_timerCheck_Elapsed");

            CheckOrder();
        }

        private void _timerUpdate_Elapsed(object sender, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("_timerUpdate_Elapsed");
            this.Fetch();

        }

        public void CheckOrder()
        {
            DataGridViewRowCollection dataGridViewRow = _dataView.GetDatatable();
            for (int i = 0; i < dataGridViewRow.Count - 1; i++)
            {
                string id = dataGridViewRow[i].Cells["ID"].Value.ToString();
                string fid = dataGridViewRow[i].Cells["Site Fault Number"].Value.ToString();
                DateTime reportedDate;
                DateTime.TryParse(dataGridViewRow[i].Cells["Reported Date"].Value.ToString(), out reportedDate);


                if (string.IsNullOrWhiteSpace(dataGridViewRow[i].Cells["Fault Acknowledged Date"].Value.ToString()))
                {
                    if (AcknowledgeNotification.ContainsKey(id))
                    {
                        continue;
                    }

                    if (reportedDate.AddHours(1) < DateTime.Now)
                    {
                        faultsMessages.Enqueue(new FaultsMessage()
                        {
                            Message = $"[!!] Order need to acknowledge: https://ismm.sg/ce/fault/{id}, reported at {reportedDate}."
                        });
                        AcknowledgeNotification.Add(id, reportedDate);
                    }
                }

                if (string.IsNullOrWhiteSpace(dataGridViewRow[i].Cells["Work Completed Date"].Value.ToString()))
                {
                    if (CompleteNotification.ContainsKey(id))
                    {
                        continue;
                    }

                    if (reportedDate.AddHours(4) < DateTime.Now)
                    {
                        faultsMessages.Enqueue(new FaultsMessage()
                        {
                            Message = $"[!!!] Order need to complete: https://ismm.sg/ce/fault/{id}, reported at {reportedDate}."
                        });
                        CompleteNotification.Add(id, reportedDate);
                    }
                }
            }
        }

        public void Fetch()
        {
            draw++;

            HTTP http = new HTTP();
            http.Cookies = _cookies;
            Uri uri = new Uri(@"https://ismm.sg/ce/datatable/faults?draw=2&columns%5B0%5D%5Bdata%5D=action&columns%5B0%5D%5Borderable%5D=false&columns%5B1%5D%5Bdata%5D=f_num&columns%5B2%5D%5Bdata%5D=trd&columns%5B3%5D%5Bdata%5D=type&columns%5B4%5D%5Bdata%5D=cat&columns%5B5%5D%5Bdata%5D=sev&columns%5B6%5D%5Bdata%5D=st&columns%5B7%5D%5Bdata%5D=bl&columns%5B8%5D%5Bdata%5D=fl&columns%5B9%5D%5Bdata%5D=rm&columns%5B10%5D%5Bdata%5D=cff&columns%5B11%5D%5Bdata%5D=ca&columns%5B12%5D%5Bdata%5D=resd&columns%5B13%5D%5Bdata%5D=svd&columns%5B14%5D%5Bdata%5D=rad&columns%5B15%5D%5Bdata%5D=wsd&columns%5B16%5D%5Bdata%5D=wcd&columns%5B17%5D%5Bdata%5D=wcun&columns%5B18%5D%5Bdata%5D=act_dot&columns%5B19%5D%5Bdata%5D=act_taken&columns%5B19%5D%5Bsearchable%5D=false&columns%5B20%5D%5Bdata%5D=otrd&columns%5B21%5D%5Bdata%5D=cosd&columns%5B22%5D%5Bdata%5D=ard&columns%5B23%5D%5Bdata%5D=f_num_ref&columns%5B24%5D%5Bdata%5D=eun&columns%5B25%5D%5Bdata%5D=rank&columns%5B26%5D%5Bdata%5D=euc&columns%5B27%5D%5Bdata%5D=sr&columns%5B28%5D%5Bdata%5D=cu&columns%5B29%5D%5Bdata%5D=rmk&order%5B0%5D%5Bcolumn%5D=1&order%5B0%5D%5Bdir%5D=desc&start=10&length=10&search%5Bvalue%5D=&stat=&ls%5B%5D=60&ls%5B%5D=59&ls%5B%5D=58&ls%5B%5D=83&ls%5B%5D=79&ls%5B%5D=81&lb=&lf=&sd=2022-03-03&ed=2022-05-31&cat=&tp=&cc_stat=&resp_t=&pub=&inca=&inty=&_=1653995731017");
            var query = HttpUtility.ParseQueryString(uri.Query);

            query.Set("draw", draw.ToString());
            query.Set("_", DateTime.UtcNow.ToUnixTimeSeconds().ToString());
            query.Set("sd", DateTime.UtcNow.AddDays(-14).ToString("yyyy-MM-dd"));
            query.Set("ed", DateTime.UtcNow.ToString("yyyy-MM-dd"));
            query.Set("start", "0");
            query.Set("length", "500");


            string json = http.Request($"{uri.Scheme}://{uri.Host}{uri.AbsolutePath}?{query}");
            if (!string.IsNullOrWhiteSpace(json))
            {
                var o = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                UpdateDatatable((Newtonsoft.Json.Linq.JObject)o);
            }

        }

        public void UpdateDatatable(Newtonsoft.Json.Linq.JObject jobject)
        {
            int recordsTotal = int.Parse(jobject.GetValue("recordsTotal").ToString());
            int recordsFiltered = int.Parse(jobject.GetValue("recordsFiltered").ToString());
            Newtonsoft.Json.Linq.JArray faultsOrders = (Newtonsoft.Json.Linq.JArray)jobject.GetValue("data");

            List<FaultsOrder> list = new List<FaultsOrder>();

            foreach (Newtonsoft.Json.Linq.JObject order in faultsOrders)
            {
                FaultsOrder faultsOrder = new FaultsOrder()
                {
                    id = order.GetValue("id").ToString(),
                    fault_number = order.GetValue("fault_number").ToString(),
                    site_fault_id = order.GetValue("site_fault_id").ToString(),
                    site_fault_number = order.GetValue("site_fault_number").ToString(),
                    created_at = order.GetValue("created_at").ToString(),
                    responded_date = order.GetValue("responded_date").ToString(),
                    site_visited_date = order.GetValue("site_visited_date").ToString(),
                    ra_acknowledged_date = order.GetValue("ra_acknowledged_date").ToString(),
                    work_started_date = order.GetValue("work_started_date").ToString(),
                    work_completed_date = order.GetValue("work_completed_date").ToString(),
                    bl = order.GetValue("bl").ToString()
                };
                list.Add(faultsOrder);
            }
            _dataView.UpdateDatatable(list);
        }

        public void StopMonitor()
        {
            _timerUpdate.Stop();
            _timerUpdate.Dispose();
            _timerUpdate = null;

            _timerCheck.Stop();
            _timerCheck.Dispose();
            _timerCheck = null;

            _timerSendMessage.Stop();
            _timerSendMessage.Dispose();
            _timerSendMessage = null;
        }

        public void SendCookie(KeyValuePair<string, string> Cookie)
        {
            _cookies[Cookie.Key] = Cookie.Value;
        }
    }
}
