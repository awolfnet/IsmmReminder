function eventFire(element, elementType) {
    var mouseEvent = document.createEvent("MouseEvents");
    mouseEvent.initMouseEvent(elementType, true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
    element.dispatchEvent(mouseEvent);
}

function simulateMouseEvents(element, eventName) {
    var mouseEvent = document.createEvent('MouseEvents');
    mouseEvent.initEvent(eventName, true, true);
    element.dispatchEvent(mouseEvent);
}

function sendMessage(name, message) {
    simulateMouseEvents(document.querySelector('[title="' + name + '"]'), 'mousedown');

    messageBox = document.querySelectorAll("[contenteditable='true']")[1];

    event = document.createEvent("UIEvents");
    messageBox.innerHTML = message;
    event.initUIEvent("input", true, true, window, 1);
    messageBox.dispatchEvent(event);

    eventFire(document.querySelector('span[data-icon="send"]'), 'click');
}
