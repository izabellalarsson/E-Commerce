import React, { Component } from 'react';
import PropTypes from 'prop-types';
import CartList from '../CartList'

class Cart extends Component {
    constructor() {
        super();
        this.state = {
            cart: []
        }
    }

componentDidMount = () => {
    this.fetchCart();
}
fetchCart = () => {
    fetch("http://localhost:5000/api/cart/1")
        .then(res => res.json())
        .then(data =>
            this.setState({
                cart: data.products
            })
        )
}

    render() {
        console.log(this.state.cart)
        return (
            <div>
                {/* <h2>{this.state.cart.productName}</h2> */}
                {this.state.cart.map(item => (
                    <CartList text={item.productName} price={item.productPrice}/>
                ))}
            </div>
        );
    }
}

Cart.propTypes = {

};

export default Cart;