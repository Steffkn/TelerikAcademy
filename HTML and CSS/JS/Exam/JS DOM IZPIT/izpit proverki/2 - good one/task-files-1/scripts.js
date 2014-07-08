function createImagesPreviewer(selector, items) {
    var slideshow = document.querySelector(selector);
    var preview = document.createElement('div');
    var previewTitle = document.createElement('h1');
    var previewContant = document.createElement('img');
    var filterScreen = document.createElement('div');
    var filterTitle = document.createElement('span');
    var filterBox = document.createElement('input');
    var filterImages = [];
    var animalsBox = document.createElement('div');
    var imageDiv = document.createElement('div');
    var imageTitle = document.createElement('strong');
    var imageUrl = document.createElement('img');
    var selected = null;

    previewContant.style.width = '85%';
    previewContant.style.borderRadius = '15px';

    preview.style.display = 'inline-block';
    preview.style.textAlign = 'center';
    preview.style.height = '360px';
    preview.style.width = '430px';
    preview.style.verticalAlign = 'top';

    filterTitle.textContent = 'Filter';
    filterTitle.style.display = 'block';

    filterBox.type = 'text';
    filterBox.style.width = '90%';

    imageTitle.style.display = 'block';

    imageUrl.style.width = '90%';
    imageUrl.style.height = '90%';
    imageUrl.style.borderRadius = '5px';

    filterScreen.style.display = 'inline-block';
    filterScreen.style.height = '360px';
    filterScreen.style.width = '150px';

    filterScreen.style.overflowY = 'auto';
    filterScreen.style.textAlign = 'center';

    function createImageForFilter(element) {
        var clonedImageDiv = imageDiv.cloneNode(true);
        var clonedImageTitle = imageTitle.cloneNode(true);
        var clonedImageUrl = imageUrl.cloneNode(true);

        clonedImageTitle.innerHTML = element.title;
        clonedImageUrl.src = element.url;

        clonedImageDiv.appendChild(clonedImageTitle);
        clonedImageDiv.appendChild(clonedImageUrl);

        return clonedImageDiv;
    }

    function findItemIndex(title) {
        for (var i in items) {
            if (items[i].title === title) {
                return i;
            }
        }

        return -1;
    }

    function changePreview(index) {
        previewTitle.textContent = items[index].title;
        previewContant.src = items[index].url;
    }

    function onMouseover(ev) {
        if (this !== selected) {
            this.style.backgroundColor = '#C9CBD2';
        }
    }

    function onMouseout(ev) {
        if (this !== selected) {
            this.style.backgroundColor = 'white';
        }
    }

    function onClick(ev) {
        var selectedIndex = findItemIndex(this.firstElementChild.textContent);

        if (selected) {
            selected.style.backgroundColor = 'white';
        }
        selected = this;
        this.style.backgroundColor = '#787878';

        changePreview(selectedIndex);
    }

    function clearAnimalsBox() {
        animalsBox.innerHTML = '';
    }

    function filterAnimals(ev) {
        var pattern = this.value.toLowerCase();
        var filteredItems = [];

        for (var i in items) {
            if (items[i].title.toLowerCase().indexOf(pattern) > -1) {
                filteredItems.push(items[i]);
            }
        }

        clearAnimalsBox();
        filterImages = [];
        placeAnimals(filteredItems);
    }

    function placeAnimals(animals) {
        for (var i = 0; i < animals.length; i++) {
            filterImages.push(createImageForFilter(animals[i]));
            filterImages[i].addEventListener('mouseover', onMouseover);
            filterImages[i].addEventListener('mouseout', onMouseout);
            filterImages[i].addEventListener('click', onClick);

            animalsBox.appendChild(filterImages[i]);
        }
    }

    filterBox.addEventListener('keyup', filterAnimals);

    filterScreen.appendChild(filterTitle);
    filterScreen.appendChild(filterBox);
   
    placeAnimals(items);
    filterScreen.appendChild(animalsBox);

    changePreview(0);
    preview.appendChild(previewTitle);
    preview.appendChild(previewContant);

    slideshow.appendChild(preview);
    slideshow.appendChild(filterScreen);
}