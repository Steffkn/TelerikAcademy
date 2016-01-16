// 9 Write a function for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails. Return the emails as array of strings.


function onExtractEnamils() {
    printInElement('', true);
    var text = "Some emails m.alexiev@abv.bg more mails malexiev@gmail.com Even more @mails that wont work like _ma@yahoo.com ! Just broken email@ malex@iev@gmail.com";

    printInElement(text + "\n");

    var emails = [];
    var index = text.indexOf("@");
    while (index > -1) {
        if (text[index - 1] != " " && text[index + 1] != " ") {
            var identifier = text.substring(text.lastIndexOf(" ", index - 1), index);
            var host = text.substring(index + 1, text.indexOf(".", index + 1));
            var domain = text.substring(text.indexOf(".", index + 1) + 1, text.indexOf(" ", text.indexOf(".", index + 1) + 1));
            var email = new String();

            // skip emails with more than one @ symbol
            if (identifier.indexOf("@") === -1 && host.indexOf("@") === -1 && domain.indexOf("@") === -1) {
                email = email.concat(identifier, "@", host, ".", domain);
                emails.push(email);
            }
        }
        index = text.indexOf("@", index + 1);
    }

    printInElement(emails);
}

