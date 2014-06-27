function onClickTheButton(event, arguments) {
    var newWindow = window;
    var browser = newWindow.navigator.appCodeName;
    var isMozilla = browser == "Mozilla";

    if (isMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
