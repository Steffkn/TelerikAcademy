var studentsArray = [{
    firstName: 'Peter',
    lastName: 'Ivanov',
    grade: 3
}, {
    firstName: 'Danie',
    lastName: 'Peshov',
    grade: 4
}, {
    firstName: 'Stefan',
    lastName: 'Georgiev',
    grade: 6
}, {
    firstName: 'Mariq',
    lastName: 'Georgieva',
    grade: 6
}];

(function () {
    var $wrapper = $("#wrapper");
    $('<button>')
        .text('Generate table')
        .on('click', generateTable)
        .appendTo($wrapper);

    function generateTable() {
        var $table = $('<table>').appendTo('body');
        var $thead = $('<thead>').appendTo($table);
        var $tr = $('<tr>').appendTo($thead);
        $tr.append($('<th>').text('First name'));
        $tr.append($('<th>').text('Last name'));
        $tr.append($('<th>').text('Grade'));
        var $tbody = $('<tbody>').appendTo($table);

        for (var i = 0; i < studentsArray.length; i++) {
            var $stInfo = $('<tr>');
            $stInfo.append($('<td>').text(studentsArray[i].firstName));
            $stInfo.append($('<td>').text(studentsArray[i].lastName));
            $stInfo.append($('<td>').text(studentsArray[i].grade));

            $stInfo.appendTo($tbody);
        }
    }
})();