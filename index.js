const url = "http://localhost:5000/api/product";


fetch(url)
.then(res => res.json())
.then(data => console.log(data))