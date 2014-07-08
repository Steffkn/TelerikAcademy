define(function () {
    'use strict';
    var Item;
    Item = (function () {

        function setType(type) {
            if (type === 'accessory' || type === 'smart-phone' || type === 'notebook' || type === 'pc' || type === 'tablet') {
                return type;
            }
            else {
                throw {
                    message: 'Type is not valid!'
                };
            }
        }
        function setName(name) {
            if (name.length >= 6 || name.length <= 40) {
                return name;
            }
            else {
                throw {
                    message: 'Name is not valid! Must be between 6 and 40 characters long!'
                };
            }
        }
        function setPrice(price) {
            if (price >= 0) {
                return price;
            }
            else {
                throw {
                    message: 'Invalid price! Number higher than or equal to zero expected!'
                };
            }
        }

        function Item(type, name, price) {
            this._type = setType(type);
            this._name = setName(name);
            this._price = setPrice(price);
        }

        Item.prototype = {
            getType: function () {
                return this._type;
            },
            getName: function () {
                return this._name;
            },
            getPrice: function () {
                return this._price;
            }
        };
        return Item;
    })();
    return Item;
});