define(['jquery', 'controller'], function ($, Controller) {
    var Ui = (function () {
        var $container = $('#main');

        function displayHomePage($context) {
            var isLogged = Controller.isUserLoggedIn();
            if (isLogged) {
                $.get('Views/logged-in-home-page.html')
                    .then(function (template) {
                        $context.$element().html(template);
                    })

            } else {
                $.get('Views/home-page-template.html')
                    .then(function (template) {
                        $context.$element().html(template);
                    });
            }
        }

        function displayPostsPage($context) {
            // This works but it doesn't want to refresh

            //var isLogged = Controller.isUserLoggedIn();
            //if (isLogged) {
            //    $.get('Views/posts-page-template-logged.html')
            //        .then(function (template) {
            //            $context.$element().html(template);
            //        });
            //} else {
            //    $.get('Views/post-page-template-guest.html')
            //        .then(function (template) {
            //            $context.$element().html(template);
            //        });
            //}
            $.get('Views/posts-page-template-logged.html')
                .then(function (template) {
                    $context.$element().html(template);
                });
        }

        function showPosts(allPosts) {
            //can't access it...
        }

        function displayErrorMessage(message) {
            $('#error-messages').html(message).show().hide(3000);
        }

        //function displayNotFound($context) {
        //    $.get('Views/posts-not-found.html')
        //        .then(function (template) {
        //            $context.$element().html(template);
        //        });
        //}

        return {
            displayHomePage: displayHomePage,
            displayPostsPage: displayPostsPage,
            displayErrorMessage: displayErrorMessage,
            showPosts: showPosts
            //displayNotFound: displayNotFound
        }
    }());

    return Ui;
});