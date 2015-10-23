(function () {
    require.config({
        paths: {
            jquery: 'libs/jquery',
            sammy: 'libs/sammy',
            q: 'libs/q',
            httpRequester: 'http-requester',
            ui: 'ui',
            controller: 'controller',
            events: 'events',
            CryptoJS: 'libs/sha1',
            underscore: 'libs/underscore'
        }
    });
    require(['jquery', 'sammy', 'ui', 'events', 'CryptoJS', 'underscore'], function ($, sammy, Ui, Events, CryptoJS, underscore) {
        var app = sammy('#main', function () {
            this.get('#/', function ($context) {
                Ui.displayHomePage($context);
            });

            this.get('#/posts', function ($context) {
                Ui.displayPostsPage($context);
            });

            //this.get('any', function ($context) {
            //    Ui.displayNotFound($context);
            //})
        });

        app.run('#/')
    })

}());