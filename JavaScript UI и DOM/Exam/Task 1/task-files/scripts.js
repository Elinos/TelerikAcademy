function createImagesPreviewer(selector, items) {
  var container = document.querySelector(selector);
  var filter = document.createElement('div');
  var filterTitle = document.createElement('div');
  var filterInput = document.createElement('input');

  var list = document.createElement('ul');
  var item = document.createElement('li');
  var itemTitle = document.createElement('div');
  var itemImage = document.createElement('img');

  var bigItem = document.createElement('div');
  bigItem.className = "bigItem";
  var bigTitle = document.createElement('div');
  var bigImage = document.createElement('img');

  //styles

  container.style.width = '800px';
  container.style.position = 'relative';

  list.style.width = '200px';
  list.style.height = '500px';
  list.style.overflow = 'auto';
  list.style.listStyleType = 'none';
  list.style.display = 'inline-block';
  list.style.position = 'absolute';
  list.style.right = 0;
  list.style.top = '50px';

  bigItem.style.display = 'inline-block';
  bigItem.style.position = 'absolute';
  bigItem.style.top = '100px';
  bigItem.style.left = '50px';


  bigImage.style.width = '500px';
  bigImage.style.height = '100%';
  bigImage.style.borderRadius = '10px';

  bigTitle.style.textAlign = 'center';
  bigTitle.style.fontWeight = 'bold';
  bigTitle.style.fontSize = '2em';

  filter.style.display = 'inline-block';
  filter.style.position = 'absolute';
  filter.style.right = 0;
  filter.style.top = 0;

  filterTitle.style.textAlign = 'center';

  itemTitle.style.textAlign = 'center';
  itemTitle.style.fontWeight = 'bold';

  itemImage.style.width = '100%';
  itemImage.style.borderRadius = '10px';

  filterTitle.innerHTML = "Filter";
  filter.appendChild(filterTitle);
  filter.appendChild(filterInput);

  function setList(itemList) {
    for (var i = 0; i < itemList.length; i++) {

      var currentItem = item.cloneNode(true);
      var currentTitle = itemTitle.cloneNode(true);
      var currentImage = itemImage.cloneNode(true);

      if (i === 0) {
        currentItem.className = 'selected';
      }

      currentTitle.innerHTML = itemList[i].title;
      currentImage.setAttribute('src', itemList[i].url);
      currentItem.appendChild(currentTitle);
      currentItem.appendChild(currentImage);

      currentItem.addEventListener('mouseover', function() {
        this.style.background = 'gray';
      });

      currentItem.addEventListener('mouseout', function() {
        this.style.background = '';
      });

      currentItem.addEventListener('click', function() {
        list.querySelector('.selected').className = '';
        this.className = 'selected';
        setBigItem();
      });

      list.appendChild(currentItem);
    }
  }

  filterInput.addEventListener('change', function() {
    var input = this.value;
    if (input) {
      var newItems = [];
      for (var i = 0; i < items.length; i++) {
        if (items[i].title.toLowerCase().indexOf(input.toLowerCase()) > -1) {
          newItems.push(items[i]);
        }
      }
      while (list.firstChild) {
        list.removeChild(list.firstChild);
      }
      setList(newItems);
      setBigItem();
    } else {
      while (list.firstChild) {
        list.removeChild(list.firstChild);
      }
      setList(items);
      setBigItem();
    }
  });

  function setBigItem() {
    if (document.querySelector('.bigItem')) {
      var oldBigItems = document.querySelectorAll('.bigItem');
      for (var i = 0; i < oldBigItems.length; i++) {
        oldBigItems[i].parentNode.removeChild(oldBigItems[i]);
      }
    }

    var currentBigItem = bigItem.cloneNode(true);
    var currentBigTitle = bigTitle.cloneNode(true);
    var currentBigImage = bigImage.cloneNode(true);

    currentBigTitle.innerHTML = list.querySelector('.selected div').innerHTML;
    currentBigImage.setAttribute('src', list.querySelector('.selected img').getAttribute('src'));
    currentBigItem.appendChild(currentBigTitle);
    currentBigItem.appendChild(currentBigImage);
    container.appendChild(currentBigItem);
  }

  setList(items);
  setBigItem();

  container.appendChild(filter);
  container.appendChild(bigItem);
  container.appendChild(list);
}
