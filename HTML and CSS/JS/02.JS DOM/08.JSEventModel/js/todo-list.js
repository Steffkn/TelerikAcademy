(function () {
    'use strict';

    function toArray(list) {
        return Array.prototype.slice.apply(list || []);
    }

    function addEventListener(selector, eventType, listener) {
        document.querySelector(selector).addEventListener(eventType, listener, false);
    }

    var todoList = (function () {

        function getCheckedItems() {
            return toArray(list.querySelectorAll(':checked')).map(function (checkedEl) {
                return checkedEl.parentElement;
            });
        }

        var list = document.querySelector('#todo-list');

        return {
            addItem: function (content) {
                var todoItem = document.createElement('li'),
                    label = document.createElement('label'),
                  itemCheckbox = document.createElement('input');

                itemCheckbox.type = 'radio';
                itemCheckbox.name = 'selected';

                label.appendChild(itemCheckbox);
                label.appendChild(document.createTextNode(content));

                todoItem.appendChild(label);

                list.appendChild(todoItem);
            },
            hideSelected: function () {
                getCheckedItems().forEach(function (item) {
                    item.classList.add('hidden');
                });
            },
            showAll: function () {
                toArray(list.querySelectorAll('.hidden')).forEach(function (hidden) {
                    hidden.classList.remove('hidden');
                });
            },
            deleteSelected: function () {
                getCheckedItems().forEach(function (item) {
                    item.parentElement.removeChild(item);
                });
            },
            deleteAll: function () {
                toArray(list.querySelectorAll('label')).forEach(function (item) {
                    item.parentElement.removeChild(item);
                });
            }
        };
    })();

    addEventListener('#create-todo', 'submit', function (event) {
        event.preventDefault();
        todoList.addItem(event.target.item.value);
        event.target.item.value = '';
    });

    addEventListener('#delete-item', 'click', function (event) {
        todoList.deleteSelected();
    });

    addEventListener('#hide-item', 'click', function (event) {
        todoList.hideSelected();
    });

    addEventListener('#show-item', 'click', function (event) {
        todoList.showAll();
    });

    addEventListener('#deleteAll-items', 'click', function (event) {
        todoList.deleteAll();
    });
})();