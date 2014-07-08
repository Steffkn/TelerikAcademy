function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);
    var leftBigBox = document.createElement('div');
    var rightBigBox = document.createElement('div');

    var imageBoxTitle = document.createElement('strong');
    var imageBoxContent = document.createElement('img');
    var imageBox = document.createElement('div');

    var leftImageBoxTitle = document.createElement('strong');
    var leftImageBoxContent = document.createElement('img');
    var leftImageBox = document.createElement('div');

    var filterLabel = document.createElement('label');
    var filterInput = document.createElement('input');

    var bigImageProp = {
        title: '',
        url: ''
    };

    var selectedBox = null;
    var imagesCount = items.length;

    var searchResultItems = [];
    // styles

    filterLabel.innerHTML = 'Filter';
    filterLabel.style.fontSize = '24px';
    filterLabel.style.display = 'block';
    filterLabel.style.textAlign = 'center';
    filterInput.style.width = '90%';

    container.style.width = '1000px';
    container.style.height = '500px';
    container.style.border = '1px solid black';

    leftImageBoxTitle.style.display = 'block';
    leftImageBoxTitle.style.fontSize = '38px';
    leftImageBoxTitle.style.margin = '40px 0 20px 0';
    leftImageBoxTitle.style.padding = '0';

    leftImageBoxContent.style.display = 'block';
    leftImageBoxContent.style.margin = '0 auto';
    leftImageBoxContent.style.padding = '0';
    leftImageBoxContent.style.borderRadius = '10px';
    leftImageBoxContent.style.width = '500px';
    leftImageBoxContent.style.height = 'auto';

    imageBoxTitle.style.display = 'block';
    imageBoxTitle.style.fontSize = '20px';
    imageBoxTitle.style.textAlign = 'center';

    imageBoxContent.style.display = 'block';
    imageBoxContent.style.margin = '0';
    imageBoxContent.style.padding = '10px';
    imageBoxContent.style.borderRadius = '20px';
    imageBoxContent.style.width = '250px';
    imageBoxContent.style.height = 'auto';

    rightBigBox.style.display = 'inline-block';
    rightBigBox.style.float = 'left';
    rightBigBox.style.margin = '0';
    rightBigBox.style.padding = '0';
    rightBigBox.style.height = '100%';
    rightBigBox.style.textAlign = 'center';
    rightBigBox.style.overflow = 'scroll';

    leftBigBox.style.display = 'inline-block';
    leftBigBox.style.float = 'left';
    leftBigBox.style.margin = '0';
    leftBigBox.style.padding = '0';
    leftBigBox.style.width = '70%';
    leftBigBox.style.height = '100%';
    leftBigBox.style.content = 'auto';
    leftBigBox.style.textAlign = 'center';


    imageBox.appendChild(imageBoxTitle);
    imageBox.appendChild(imageBoxContent);

    function createImageBoxes(properties) {
        bigImageProp.title = properties[0].title;
        bigImageProp.url = properties[0].url;

        var imageBoxs = [];
        for (var i = 0; i < properties.length; i += 1) {
            var property = properties[i];
            imageBoxTitle.innerHTML = property.title;
            imageBoxContent.src = property.url;
            imageBoxs.push(imageBox.cloneNode(true));
        }
        return imageBoxs;
    }

    function createLeftImageBox() {

        leftImageBoxTitle.innerHTML = bigImageProp.title;
        leftImageBoxContent.src = bigImageProp.url;

        leftImageBox.appendChild(leftImageBoxTitle);
        leftImageBox.appendChild(leftImageBoxContent);

        return leftImageBox;
    }

    function onImageBoxMouseover(ev) {
        if (selectedBox !== this) {
            this.style.background = '#ccc';
        }
    }

    function onImageBoxMouseout(ev) {
        if (selectedBox !== this) {
            this.style.background = '';
        }
    }

    function onImageBoxClick(ev) {
        if (selectedBox) {
            selectedBox.style.background = '';
        }
        if (selectedBox && selectedBox === this) {
            selectedBox = null;
        } else {
            this.style.background = 'yellowgreen';
            selectedBox = this;
            var img = this.querySelector('img');
            bigImageProp.url = img.getAttribute('src');

            var strong = this.querySelector('strong');
            bigImageProp.title = strong.innerHTML;

            leftImageBox = createLeftImageBox();
        }
    }

    function onChangeClick(ev) {
        var searchWord = filterInput.value.toLowerCase();
        var searchResult = [];
        for (var i = 0; i < imagesCount; i++) {
            var property = items[i];

            if (property.title.toLowerCase().indexOf(searchWord) > -1) {
                console.log(property.title);
                searchResult.push({
                    title: property.title,
                    url: property.url
                });
            }
        }
        imageBoxes = createImageBoxes(searchResult);
        fillRightBigBox();
        return searchResult;
    }

    filterInput.addEventListener('change', onChangeClick);

    var imageBoxes = createImageBoxes(items);
    leftImageBox = createLeftImageBox();

    var docFragment = document.createDocumentFragment();

    function fillRightBigBox() {
        console.log(imageBoxes.length);
        for (var i = 0; i < imageBoxes.length; i += 1) {
            docFragment.appendChild(imageBoxes[i]);
            imageBoxes[i].addEventListener('click', onImageBoxClick);
            imageBoxes[i].addEventListener('mouseover', onImageBoxMouseover);
            imageBoxes[i].addEventListener('mouseout', onImageBoxMouseout);
        }
    }
    fillRightBigBox();

    rightBigBox.appendChild(filterLabel);
    rightBigBox.appendChild(filterInput);
    rightBigBox.appendChild(docFragment);
    leftBigBox.appendChild(leftImageBox);
    container.appendChild(leftBigBox);
    container.appendChild(rightBigBox);
}