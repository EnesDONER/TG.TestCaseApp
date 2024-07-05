const url = 'http://localhost:5000';

document.addEventListener('DOMContentLoaded', function() {
    getListCategories();
    getListProducts();
});

function getListProducts(){
    const params = new URLSearchParams({
      PageIndex: 0,
      PageSize: 10
    });
  
    const fullUrl = `${url}/Products?${params.toString()}`;
  
    fetch(fullUrl)
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
        clearProductList();
        setProduct(data);
    })
    .catch(error => {
      console.error('Fetch error:', error);
    });
}

function getListCategories(){
    const params = new URLSearchParams({
      PageIndex: 0,
      PageSize: 10
    });
  
    const fullUrl = `${url}/Categories?${params.toString()}`;
  
    fetch(fullUrl)
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      const categoryListDiv = document.getElementById('categoryList');

        const categoryLink = document.createElement('a');
        categoryLink.classList.add('list-group-item', 'list-group-item-action','clicked');
        categoryLink.textContent = "All";
        categoryLink.id = `${0}`;
        
        categoryListDiv.appendChild(categoryLink);

      data.Items.forEach(item => {
        const categoryLink = document.createElement('a');
        categoryLink.classList.add('list-group-item', 'list-group-item-action');
        categoryLink.textContent = item.Name;
        categoryLink.id = `${item.Id}`;
        
        categoryListDiv.appendChild(categoryLink);
      });
    })
    .catch(error => {
      console.error('Fetch error:', error);
    });
}

document.getElementById('categoryList').addEventListener('click', function(event) {

    var categoryId = event.target.getAttribute('id');
    var clickedElement = event.target;

    var allElements = document.querySelectorAll('#categoryList a');
        allElements.forEach(function(element) {
            element.classList?.remove('clicked');
        });

        // Tıklanan öğenin rengini değiştir
        clickedElement.classList.add('clicked');

    if(categoryId == 0){
        getListProducts();
        return;
    }
    const params = new URLSearchParams({
        PageIndex: 0,
        PageSize: 10
      });
    
      const fullUrl = `${url}/Products/${categoryId}?${params.toString()}`;

    if (categoryId) {
      fetch(fullUrl)
        .then(response => response.json())
        .then(data => {
          console.log('API Response:', data);
          clearProductList();
          setProduct(data);
        })
        .catch(error => {
          console.error('API Error:', error);
        });
    }
  });

function setProduct(data) {
    const productListDiv = document.getElementById('productList');

    data.Items.forEach(item => {
        const colDiv = document.createElement('div');
        colDiv.classList.add('col');

        const cardDiv = document.createElement('div');
        cardDiv.classList.add('card', 'h-100');

        const cardImage = document.createElement('img');
        cardImage.classList.add('card-img-top');
        cardImage.src = item.Image;

        const cardBodyDiv = document.createElement('div');
        cardBodyDiv.classList.add('card-body');

        const cardTitle = document.createElement('h5');
        cardTitle.classList.add('card-title');
        cardTitle.textContent = item.Name;

        const cardText = document.createElement('p');
        cardText.classList.add('card-text');
        cardText.textContent = `Price: ${item.Price}₺`;

        cardDiv.appendChild(cardImage);
        cardBodyDiv.appendChild(cardTitle);
        cardBodyDiv.appendChild(cardText);

        cardDiv.appendChild(cardBodyDiv);
        colDiv.appendChild(cardDiv);
        productListDiv.appendChild(colDiv);
    });
}

function clearProductList() {
    const productListDiv = document.getElementById('productList');
    while (productListDiv.firstChild) {
        productListDiv.removeChild(productListDiv.firstChild);
    }
}
