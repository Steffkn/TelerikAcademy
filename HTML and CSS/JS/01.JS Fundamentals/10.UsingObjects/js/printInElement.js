
function printInElement(output, clear) {
    if (clear === true) {
        document.getElementById("result").innerText = "";
    }
    document.getElementById("result").innerText = document.getElementById("result").innerText + output;
    console.log(output);
}