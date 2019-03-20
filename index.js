const url = "http://localhost:5000/api/product";
const update = document.querySelector(".update_product")
const updateBtn = document.querySelector(".update_button")
const value1 = document.querySelector("input[name='name']")
const value2 = document.querySelector("input[name='description']")
const productsContainer = document.querySelector(".products-container")


const productCard = (data) => {

    const item = document.createElement('div');
    item.classList.add('product-item');

    // Create a new image for the GIF.
    const image = document.createElement('img');
    image.src = data.productImage;

    const title = document.createElement('h3');
    title.innerText = data.productName;

    // const description = document.createElement('p')
    // description.innerText = data.productDescription;

    const price = document.createElement('p');
    price.classList.add('product-item-price');
    price.innerText = data.productPrice
    // Add the image to the anchor element.


    item.appendChild(image);
    item.appendChild(title);
    // item.appendChild(description);
    item.appendChild(price);

    // Return the newly created element.
    return item;
}

fetch(url)
.then(res => res.json())
.then(data =>
    {
        console.log(data)
        data.forEach(item => {
            const product = productCard(item)
            productsContainer.appendChild(product)
        });
    })



updateBtn.addEventListener('click', (e) => {
    e.preventDefault();


    const formData = {
        // Id: 5,
        productName: value1.value,
        productDescription: value2.value,
    }    

    //   console.log(JSON.stringify(formData))
        // console.log(typeof formData)
    fetch(url, {
        method: 'POST',
        body: JSON.stringify(formData),
        headers: {
            'Accept': 'application/json',
            "Content-Type": "application/json",
        },
        // mode: 'no-cors',
    })
    .then(response => response.json())
    .then(data => console.log(data));
         
})
        // let product = document.querySelector(
        //     `.update_product${update[0].value}`
        //     );
            
            
    
        // like.innerText = json;
        // if (likeForm[1].value === 'like') {
        //     likeForm[1].value = 'unlike';
        // } else {
        //     likeForm[1].value = 'like';
        // }