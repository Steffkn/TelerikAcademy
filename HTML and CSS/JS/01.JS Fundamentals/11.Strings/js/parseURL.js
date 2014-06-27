// 1 Write a script that parses an URL address given in the format: [protocol]://[server]/[resource]
// and extracts from it the [protocol], [server] and [resource] elements. 
// Return the elements in a JSON object.
//    For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//  { protocol: 'http', 
//    server: 'www.devbg.org', 
//    resource: '/forum/index.php'}

function onParseURL() {
    printInElement('', true);
    var url = "http://www.devbg.org/forum/index.php";
    printInElement('Given url: '+ url + "\n", true);
    printInElement("Protocol: " + parseURL(url)['Protocol'] + "\n");
    printInElement("Server: " + parseURL(url)['Server'] + "\n");
    printInElement("Resource: " + parseURL(url)['Resource'] + "\n");
}

function parseURL(url) {
    var protokol = url.substring(0, url.indexOf(":"));
    var server = url.substring(url.indexOf(":") + 3, url.indexOf("/", url.indexOf(":") + 3));
    var resource = url.substr(url.indexOf("/", url.indexOf(":") + 3) + 1)
    var URLJSON = { "Protocol": protokol, "Server": server, "Resource": resource };
    return URLJSON;
}