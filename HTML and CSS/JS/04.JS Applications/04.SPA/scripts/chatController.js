define(["jquery"], function ($) {

    function getMsg() {
        var result = {
            user: getUserName(),
            text: getTextMsg()
        }

        return result;
    }

    function getUserName() {
        var USER_MIN_LEN = 4,
	        USER_MAX_LEN = 30,
	        username = $('#username-input').val().trim();

        if (!((username.length >= USER_MIN_LEN) && (username.length <= USER_MAX_LEN))) {
            alert('Username must be between ' + USER_MIN_LEN + ' and ' + USER_MAX_LEN + ' symbols! User will apear as unknown');
            username = 'Unknown User';
        }

        return username;
    }

    function getTextMsg() {
        var MSG_MIN_LEN = 1,
	        MSG_MAX_LEN = 200,
	        msgText = $('#chat-message-input').val().trim();
        if (!((msgText.length >= MSG_MIN_LEN) && (msgText.length <= MSG_MAX_LEN))) {
            alert('Message text must be between ' + MSG_MIN_LEN + ' and ' + MSG_MAX_LEN + ' symbols! Message will apear as empty!');
            msgText = '';
        }

        return msgText;
    }

    return {
        getMsg: getMsg
    }
})