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
        // this.handleClick();
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

    addProductToCart = (productId) => {
        
            fetch("http://localhost:5000/api/cart/", {
                method: 'POST',
                body: JSON.stringify({productId: productId, cartId: 1, quantity: 1}),
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
            })
}

    handleClick = (productId) => {
        this.addProductToCart(productId)
        console.log(productId)
        // .filter(products => products.product.productId === products.productId);
        // console.log(this.state.products)
    }

    render(){
        return (
            <div className="products-container">
                {this.state.products.map(product => (
                    <ProductList onClick={() => this.handleClick(product.productId)} key={product.productId} name={product.productName} image={product.productImage} description={product.productDescription} price={product.productPrice}></ProductList>
                ))}
            </div>
    );
    }
};

export default Product;