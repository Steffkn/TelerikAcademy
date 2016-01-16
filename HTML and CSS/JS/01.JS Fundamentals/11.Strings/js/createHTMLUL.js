// 12-*// Write a function that creates a HTML UL using a template for every HTML LI. 
//  The source of the list should an array of elements. Replace all placeholders marked with –{…}–  
//  with the value of the corresponding property of the object. 

//      Example:
//  <div data-type="template" id="list-item">
//   <strong>-{name}-</strong> <span>-{age}-</span>
//  </div>

// var people = [{name: 'Peter', age: 14},…];
// var tmpl = document.getElementById('list-item').innerHtml;
// var peopleList = generateList(people, template);
// //peopleList = '<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>'

function onCreatingHTMLUL() {
    printInElement('', true);

    var people = [{ name: ' Stefan ', age: 23 },
              { name: ' Gosho ', age: 15 },
              { name: ' Pesho ', age: 29 }];
    var template = document.getElementById("list-item").innerHTML;
    var peopleList = generateList(people, template);

    document.getElementById("list-item").innerHTML = peopleList;
}

function generateList(people, tmpl) {
    tmpl = new String(tmpl); //parse to string
    var list = new String('<ul>');//string for keeping the result
    for (var i in people) {
        var currentLI = new String('<li>');
        currentLI += tmpl.replace('-{name}-', people[i].name);
        currentLI = currentLI.replace('-{age}-', people[i].age);
        currentLI += '</li>';
        list += currentLI;
    }
    list += '</ul>';
    return list;
}