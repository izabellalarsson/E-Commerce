import React, {Component} from 'react';
import ProductList from '../ProductList';
import './Product.css';

class Product extends Component {
    constructor() {
        super();
        this.state = {
            products: []
        }

        this.handleClick = this.handleClick.bind();
    }

    componentDidMount() {
        this.fetchProducts();
        this.handleClick();
        // this.addProductToCart();
    }

    fetchProducts = () => {
        fetch("http://localhost:5000/api/product")
        .then(res => res.json())
        .then(data =>
            data.map(item => {
               return this.setState({
                    products: [
                        ...this.state.products,
                        {
                            productId: item.productId,
                            productName: item.productName,
                            productDescription: item.productDescription,
                            productImage: item.productImage,
                            productPrice: item.productPrice
                        }
                    ],
                })

            })
        )
    }

    addProductToCart = () => {
        // console.log(this.state.products)
        this.state.products.map(item => {
        const result = item.filter(product => item.productId == product.productId)
        console.log(result);
        //     console.log(item)
        //     // item.filter(choice => choice.productId == item.productId)
        //     // console.log(choice)
        })
        // this.state.products.map(item => {
        //     console.log(item)
        //     // fetch("http://localhost:5000/api/cart/1", {
        //     //     method: 'POST',
        //     //     body: JSON.stringify(item.productId),
        //     //     headers: {
        //     //         'Accept': 'application/json',
        //     //         'Content-Type': 'application/json',
        //     //     },
        //     // })
        //     // .then(res => res.json())
        //     // .then(data =>
        //     //     console.log(data)
        //     //     // data.map(item => {
        //     //     //     console.log(item.productDescription)
        //     //     //     this.setState({
        //     //     //         products: [
        //     //     //             ...this.state.products,
        //     //     //             {
        //     //     //                 productId: item.productId,
        //     //     //                 productName: item.productName,
        //     //     //                 productDescription: item.productDescription,
        //     //     //                 productImage: item.productImage,
        //     //     //                 productPrice: item.productPrice
    
        //     //     //             }
        //     //     //         ],
        //     //     //     })
    
        //     //     // })
        //     // )
        // })
    }

    handleClick = () => {
        this.addProductToCart();
        // console.log('hej')
    }

    render(){
        return (
            <div className="products-container">
                {this.state.products.map(product => (
                    <ProductList onClick={this.handleClick} key={product.productId} name={product.productName} image={product.productImage} description={product.productDescription} price={product.productPrice}></ProductList>
                ))}
            </div>
    );
    }
};

export default Product;