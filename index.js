const url = "http://localhost:5000/api/product";
const update = document.querySelector(".update_product")
const updateBtn = document.querySelector(".update_button")
const value1 = document.querySelector("input[name='name']")
const value2 = document.querySelector("input[name='description']")


// fetch(url)
// .then(res => res.json())
// .then(data =>
//     // {
//     //     const div = document.createElement('div');
//     //     const container = document.querySelector('.products-container');
//     //     div.innerText = data.productName;
//     //     container.appendChild(div);
//     // }, 
//     console.log(data))


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