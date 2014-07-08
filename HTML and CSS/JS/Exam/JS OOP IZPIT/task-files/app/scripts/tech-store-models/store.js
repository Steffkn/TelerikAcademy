define(['tech-store-models/item'], function (Item) {
    var Store = (function () {

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


        function Store(name) {
            this._name = setName(name);
            this._items = [];
        }

        function getItemsByType(allItems, type) {
            var itemsToReturn = [],
                item, i, typeIndex;
            for (i = 0; i < allItems.length; i++) {
                item = allItems[i];
                for (typeIndex = 0; typeIndex < type.length; typeIndex++) {
                    if (item.getType() == type[typeIndex]) {
                        itemsToReturn.push(item);
                    }
                }
            }
            return itemsToReturn;
        }

        function getItemsByPrice(allItems, priceMinMax) {
            var itemsToReturn = [],
                itemsSortedByPrice = allItems.sort(compareByPrice),
                priceMinMax = priceMinMax || { min: 0, max: Number.MAX_VALUE },
                item, i, len;

            if (!(priceMinMax.min >= 0)) {
                priceMinMax.min = 0;
            }
            if (!(priceMinMax.max >= 0)) {
                priceMinMax.max = Number.MAX_VALUE;
            }

            for (i = 0, len = itemsSortedByPrice.length; i < len; i++) {
                item = itemsSortedByPrice[i];
                if (item.getPrice() >= priceMinMax.min && item.getPrice() <= priceMinMax.max) {
                    itemsToReturn.push(item);
                }
            }
            return itemsToReturn;
        }

        function getItemsByName(allItems, partOfName) {
            var itemsToReturn = [],
                i, item, len;

            for (i = 0, len = allItems.length ; i < len; i++) {
                item = allItems[i];
                if (item.getName().toLowerCase().indexOf(partOfName.toLowerCase()) > -1) {
                    itemsToReturn.push(item);
                }
            }
            return itemsToReturn;
        }

        function getCountOfItemsByType(allItems) {
            var arrayToReturn = [],
                item, i, len;

            for (i = 0, len = allItems.length ; i < len; i++) {
                item = allItems[i];
                if (arrayToReturn[item.getType()] !== undefined) {
                    arrayToReturn[item.getType()] += 1;
                } else {
                    arrayToReturn[item.getType()] = 1;
                }
            }
            return arrayToReturn;
        }

        function compareByName(a, b) {
            return a.getName().localeCompare(b.getName());
        }

        function compareByPrice(a, b) {
            return a.getPrice() - b.getPrice();
        }

        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof Item)) {
                    throw {
                        message: 'Not an item'
                    };
                }
                this._items.push(item);
                return this;
            },
            getAll: function () {
                var itemsToShow = this._items.slice(0);
                return itemsToShow.sort(compareByName);
            },
            getSmartPhones: function () {
                var itemsToShow = getItemsByType(this._items.slice(0), ['smart-phone']);
                return itemsToShow.sort(compareByName);
            },
            getMobiles: function () {
                var itemsToShow = getItemsByType(this._items.slice(0), ['smart-phone', 'tablet']);
                return itemsToShow.sort(compareByName);
            },
            getComputers: function () {
                var itemsToShow = getItemsByType(this._items.slice(0), ['pc', 'notebook']);
                return itemsToShow.sort(compareByName);
            },
            filterItemsByType: function (type) {
                var itemsToShow = getItemsByType(this._items.slice(0), [type]);
                return itemsToShow.sort(compareByName);
            },
            filterItemsByPrice: function (priceMinMax) {
                var itemsToShow = this._items.slice(0);
                return getItemsByPrice(itemsToShow, priceMinMax);
            },
            filterItemsByName: function (partOfName) {
                var itemsToShow = this._items.slice(0);
                return getItemsByName(itemsToShow, partOfName);
            },
            countItemsByType: function () {
                var itemsToShow = this._items.slice(0);
                return getCountOfItemsByType(itemsToShow);
            }
        };

        return Store;
    })();
    return Store;
});