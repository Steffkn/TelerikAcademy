define(["jquery"], function ($, controller) {

    function renderChat(data) {
        var messages = data.slice(data.length - 14, data.length - 1);

        var $panel = $('<div>');

        messages.forEach(function (msg) {
            var messageText = $("<div>").html(msg.by + ': ' + msg.text).text();

            if ((msg.by.trim() != '') && (msg.text.trim() != '')) {
                var $newMsg = $('<div>')
	                                .text(messageText)
	                                .css('word-wrap', 'break');
                $panel.append($newMsg);
            }
        })

        $('#chat-container').text('').append($panel);
    }

    return {
        renderChat: renderChat
    }
})