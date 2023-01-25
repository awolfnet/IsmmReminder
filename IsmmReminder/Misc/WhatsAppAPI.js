async function setMessage(message) {
    var textbox = document.querySelector('div[title="Type a message"]');
    var event = document.createEvent("TextEvent");
    event.initTextEvent('input', true, true, window, message, 0, "en-US");
    textbox.focus();
    textbox.dispatchEvent(event);
}

async function sendMessage() {

    var mouseEvent = document.createEvent('MouseEvents');
    mouseEvent.initEvent('click', true, true);
    var sendButton = document.querySelector('span[data-icon="send"]');

    while (sendButton == null) {
        await sleepPromise(100);
        sendButton = document.querySelector('span[data-icon="send"]');
    }
    sendButton.dispatchEvent(mouseEvent);
}


function selectContact(contactName) {
    var event = document.createEvent('MouseEvents');
    event.initEvent('mousedown', true, true);
    var contact = document.querySelector('[title="' + contactName + '"]');
    contact.dispatchEvent(event);
}