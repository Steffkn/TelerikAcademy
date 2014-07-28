(function () {
    require.config({
        paths: {
            "jquery": "./libs/jquery-2.1.1.min",
            "q": "./libs/q.min",
            "sammy": "./libs/sammy",
            "httpRequest": "./httpRequest",
            "renderer": "./renderer",
            "controller": "./chatController"
        }
    });

    require(["jquery", "q", "httpRequest", "renderer", "sammy", "controller"], function($, Q, httpRequest, renderer, sammy, controller){
        var spa = sammy('#chatContainer', function () {

            this.get('#/chat', function(){
                $('#chatContainer').load('partials/chat.html', function () {
                    $('#send-msg').on('click', function() {
                        var msg = controller.getMsg();
                        httpRequest.postData(msg);
                    });
                });
            })

            this.get('#/about', function(){
                $('#chatContainer').load('partials/about.html');
            })

        });
        spa.run('#/');

        function refreshChat(){
            httpRequest.getData().then(renderer.renderChat);
        }
        setInterval(refreshChat, 1000);
    })
}());