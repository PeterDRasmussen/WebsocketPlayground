(function () {
    let webSocket
    var getWebSocketMessages = function (onMessageReceived)
    {
        let url = `ws://${location.host}/api/stream`;
        console.log('url is: ' + url);

        webSocket = new WebSocket(url);

        webSocket.onmessage = onMessageReceived;
    };

    let ulElement = document.getElementById('chatMessages');

    getWebSocketMessages(function (message) {
        ulElement.innerHTML = ulElement.innerHTML += `<li>${message.data}</li>`
        console.log(message);
    });

    document.getElementById("sendmessage").addEventListener("click", function () {
        let textElement = document.getElementById("messageTextInput");
        let text = textElement.value;
        console.log('Sending text: ' + text);
        webSocket.send(text);
        textElement.value = '';
    });
}());