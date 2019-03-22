import React from 'react';
import PropTypes from 'prop-types';

const CartList = props => {
    return (
        <div>
            <h2>{props.text}</h2>
            <h2>{props.price}</h2>
        </div>
    );
};

CartList.propTypes = {
    
};

export default CartList;