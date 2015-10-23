define(['jquery', 'httprequester', 'ui', 'underscore'], function ($, HttpRequester, Ui, _) {
    var Controller = (function () {

        var baseUrl = 'http://localhost:3000',
            username = localStorage.getItem("username"),
            sessionKey = localStorage.getItem("sessionKey");

        function saveUserData(userData) {
            localStorage.setItem("username", userData.username);
            localStorage.setItem("sessionKey", userData.sessionKey);
            username = userData.username;
            username = userData.sessionKey;
        }

        function clearUserData() {
            localStorage.removeItem("nickname");
            localStorage.removeItem("sessionKey");
            username = "";
            sessionKey = "";
        }

        function isUserLoggedIn() {
            var isLoggedIn = username != null && sessionKey != null;
            return isLoggedIn;
        }

        function registerUser() {
            var registerUrl = baseUrl + '/user',
                userData,
                userName,
                password;

            userName = $('#register-username-input').val();
            password = $('#register-password-input').val();
            userData = {
                "username": userName,
                "authCode": CryptoJS.SHA1(userName + password).toString()
            };

            HttpRequester.postJSON(registerUrl, userData)
                .then(function (data) {
                    console.log(data)
                }, function (error) {
                    Ui.displayErrorMessage(JSON.parse(error.responseText).message)
                })
        }

        function logIn() {
            var loginUrl = baseUrl + '/auth',
                userData,
                userName,
                password;

            userName = $('#login-username-input').val();
            password = $('#login-password-input').val();
            userData = {
                "username": userName,
                "authCode": CryptoJS.SHA1(userName + password).toString()
            };

            HttpRequester.postJSON(loginUrl, userData)
                .then(function (data) {
                    saveUserData(data);
                    Ui.displayErrorMessage('You logged')
                }, function (error) {
                    Ui.displayErrorMessage(JSON.parse(error.responseText).message)
                })

        }

        function logOut() {
            var logOutUrl = baseUrl + '/user',
                headers;

            headers = {
                'X-SessionKey': sessionKey
            };
            HttpRequester.put(logOutUrl, headers)
                .then(function (data) {
                    console.log(data)
                }, function (error) {
                    Ui.displayErrorMessage(JSON.parse(error.responseText).message);
                })
        }

        function createPost() {
            var createPostUrl = baseUrl + '/post',
                post,
                postTitle,
                postBody,
                headers;

            postTitle = $('#post-title').val();
            postBody = $('#post-text').val();

            post = {
                "title": postTitle,
                "body": postBody
            };

            headers = {
                'X-SessionKey': sessionKey
            };

            HttpRequester.postJSON(createPostUrl, post, headers)
                .then(function (data) {

                }, function (error) {
                    Ui.displayErrorMessage(JSON.parse(error.responseText).message);
                })
        }

        function getPosts() {
            var getPostsUrl = baseUrl + '/post',
                allPosts,
                sortByValue,
                sortValue,
                sortParameter;

            sortByValue = $('#sort-by').val();
            sortValue = $('#sort').val();

            switch (sortByValue) {
                case '1':
                    sortParameter = 'postDate';
                    break;
                case '2':
                    sortParameter = 'title';
                    break;
                default:
                    alert('This is strange :)')
                    break;
            }

            HttpRequester.getJSON(getPostsUrl)
                .then(function (data) {
                    allPosts = data;
                    var sortedStudents = _.chain(data)
                        .sortBy(sortParameter)
                        .value();

                    if (sortValue === 2) {
                        sortedStudents.reverse();
                    }

                    showPosts(sortedStudents)
                }, function (error) {
                    Ui.displayErrorMessage(JSON.parse(error.responseText).message);
                })

        }

        //This should't be here but I can't access it from Ui... lost 30 min debugging :(
        function showPosts(posts) {
            var $container = $('#all-posts'),
                i,
                allPostsCount = posts.length,
                currentPost,
                $divPost = $('<div/>'), // nice name :)
                $spanTitle = $('<span/>'),
                $spanDate = $('<span/>'),
                $spanBody = $('<span/>');

            for (i = 0; i < allPostsCount; i++) {
                currentPost = posts[i];
                $spanDate = 'Date: ' + currentPost.postDate;
                $spanTitle = 'Title: ' + currentPost.title;
                $spanBody = 'Text: ' + currentPost.body;


                $divPost.append($spanDate).append($spanTitle).append($spanBody);

            }
            $container.append($divPost)
        }

        return{
            registerUser: registerUser,
            logIn: logIn,
            isUserLoggedIn: isUserLoggedIn,
            logOut: logOut,
            createPost: createPost,
            getPosts: getPosts
        }
    }());

    return Controller;
});