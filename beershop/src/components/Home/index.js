import React, {Component} from 'react';
import ProductList from '../ProductList';
import './Home.css';

class Home extends Component {
    constructor() {
        super();
        this.state = {
            products: []
        }
    }

    componentDidMount() {
        this.fetchProducts();
        this.fetchCart();
    }

    fetchProducts = () => {
        fetch("http://localhost:5000/api/product")
        .then(res => res.json())
        .then(data =>
            data.map(item => {
                this.setState({
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

    fetchCart = () => {
        fetch("http://localhost:5000/api/cart")
        .then(res => res.json())
        .then(data =>
            console.log(data)
            // data.map(item => {
            //     console.log(item.productDescription)
            //     this.setState({
            //         products: [
            //             ...this.state.products,
            //             {
            //                 productId: item.productId,
            //                 productName: item.productName,
            //                 productDescription: item.productDescription,
            //                 productImage: item.productImage,
            //                 productPrice: item.productPrice

            //             }
            //         ],
            //     })

            // })
        )
    }

    handleClick = () => {
        this.fetchCart();
    }

    render(){
        return (
            <div className="products-container">
                {this.state.products.map(product => (
                    <ProductList key={product.productId} name={product.productName} image={product.productImage} description={product.productDescription} price={product.productPrice}></ProductList>
                ))}
            </div>
    );
    }
};

export default Home;