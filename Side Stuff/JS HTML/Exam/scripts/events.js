define(['jquery', 'controller','ui'], function ($, Controller, Ui) {
    var Events = (function () {

        $(document).on('click', '#btn-register', function () {
            Controller.registerUser();
        });

        $(document).on('click', '#btn-login', function () {
            Controller.logIn();
        });

        $(document).on('click', '#sign-out', function () {
           Controller.logOut();
            localStorage.clear();
        });

        $(document).on('click', '#btn-post', function () {
            Controller.createPost();
        });

        $(document).on('click', '#btn-get-posts', function () {
            Controller.getPosts();
        })
    }());

    return Events;
});