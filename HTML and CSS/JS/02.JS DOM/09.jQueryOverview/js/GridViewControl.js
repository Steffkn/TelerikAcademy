(function ($) {

    $.fn.gridView = function () {

        var $container = $(this);
        var $inputContainer = $('<div>')
            .addClass('input-container')
            .appendTo($container);
        var rowNumber = 0;
        var hasHeader = false;
        generateInput($inputContainer, 'GridViewColNumber', 'text', 'colNumber');
        generateButton($inputContainer, 'btn-AddCols', 'Add cols', generateRawInputs);

        function generateRawInputs() {

            var $input = $container.find('input.GridViewColNumber');
            rowNumber = parseInt($input.val());

            $inputContainer.html('')

            generateInput($inputContainer, 'GridViewColNumber', 'text', 'colNumber');
            generateButton($inputContainer, 'btn-AddCols', 'Add cols', generateRawInputs);

            if (!isNaN(rowNumber)) {
                $('<br />').appendTo($inputContainer);
                generateButton($inputContainer, 'btn-AddHeader', 'Add header', function () { generateHeader($gridview); });
                generateButton($inputContainer, 'btn-AddRow', 'Add row', function () { generateRow($gridview); });
                generateButton($inputContainer, 'btn-GridView', 'Add GridView', function () { generateGridView($gridview); });

                $('<br />').appendTo($inputContainer);
                for (var i = 0; i < rowNumber; i++) {
                    generateInput($inputContainer, 'col-data-input', 'text', 'rowData[]');
                }

                var $gridview = generateTable();

            }
            else {
                alert('Invalid input for column number: ' + rowNumber);
            }
        }

        function generateTable() {
            var $gridView = $('<div>').addClass('gridView').appendTo($inputContainer)
            var $table = $('<table>').addClass('gridView-table').appendTo($gridView)
            $('<tbody>').appendTo($table)
            $('<thead>').appendTo($table)
            return $table;
        }

        function generateHeader($table) {
            var $thead = $table.find('thead');
            //var $thead = $('<thead>').appendTo($table);
            var $tr = $('<tr>').appendTo($thead);

            var rowData = $('input[name^=rowData].col-data-input').map(function (idx, elem) {
                return $(elem).val();
            }).get();

            for (var i = 0; i < rowData.length; i++) {
                $('<th>').text(rowData[i]).appendTo($tr);
            }

            return $thead;

        }


        function generateRow($table) {
            var $tbody = $table.find('tbody');
            var $tr = $('<tr>').appendTo($tbody);

            var rowData = $('input[name^=rowData].col-data-input').map(function (idx, elem) {
                return $(elem).val();
            }).get();

            for (var i = 0; i < rowData.length; i++) {
                $('<td>').text(rowData[i]).appendTo($tr);
            }

            return $thead;
        }

        function generateGridView($table) {
            var $tbody = $table.find('tbody');
            var $tr = $('<tr>').appendTo($tbody);
            var $td = $('<td>').attr('colspan', rowNumber).appendTo($tr);
            $td.gridView();
        }

        function generateButton(buttonParent, buttonID, buttonTect, buttonOnClick) {
            return $('<button id="' + buttonID + '">')
                .html(buttonTect)
                .on('click', buttonOnClick)
                .appendTo(buttonParent);
        }

        function generateInput(inputParent, inputClass, inputType, inputName) {
            return $('<input>')
                .addClass(inputClass)
                .attr('type', inputType)
                .attr('name', inputName)
                .appendTo(inputParent);
        }
    }

    $('#gridview-container').gridView();
})(jQuery);