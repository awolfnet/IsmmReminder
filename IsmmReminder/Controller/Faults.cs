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

namespace IsmmReminder.Controller
{
    public class Faults
    {
        private IFaultsBrowserView _browserView;
        private IFaultsDataView _dataView;
        private IMessage _messageView;

        private Timer _timer = null;
        private Dictionary<string, string> _cookies = null;

        private int draw = 0;

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
            if (_timer == null)
            {
                _timer = new Timer();
            }

            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = 60 * 1000;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("_timer_Elapsed");

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
            query.Set("sd", DateTime.UtcNow.AddMonths(-1).ToString("yyyy-MM-dd"));
            query.Set("ed", DateTime.UtcNow.ToString("yyyy-MM-dd"));
            query.Set("start", "0");
            query.Set("length", "482");


            string json = http.Request($"{uri.Scheme}://{uri.Host}{uri.AbsolutePath}?{query}");

            var o = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            UpdateDatatable((Newtonsoft.Json.Linq.JObject)o);
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
                    fault_number = order.GetValue("fault_number").ToString(),
                    created_at= order.GetValue("created_at").ToString(),
                    responded_date = order.GetValue("responded_date").ToString(),
                    site_visited_date = order.GetValue("site_visited_date").ToString(),
                    ra_acknowledged_date = order.GetValue("ra_acknowledged_date").ToString(),
                    work_started_date = order.GetValue("work_started_date").ToString(),
                    work_completed_date = order.GetValue("work_completed_date").ToString()
                };
                list.Add(faultsOrder);
            }
            _dataView.UpdateDatatable(list);
        }

        public void StopMonitor()
        {
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }

        public void SendCookie(KeyValuePair<string, string> Cookie)
        {
            _cookies[Cookie.Key] = Cookie.Value;
        }
    }
}
