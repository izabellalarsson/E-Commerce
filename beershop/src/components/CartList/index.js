import React from 'react';
import styled from 'styled-components';
import PropTypes from 'prop-types';

const CartListStyled = styled.div `
    width: 20vw;
    height: auto;
    border-radius: 10px;
    box-shadow: 5px 10px 10px #e2e2e2;
    text-decoration: none;
    color: black;
    margin: 5%;

    h1, p {
        padding: 0px 30px;
    }

    img {
        width: 100%;
    }

    button {
        background: #f1f5f8;
        color: #606f7b;
        border-radius: 10px;
        margin: 20px;
        height: 40px;
        padding: 10px;
        font-size: 16px;
        font-weight: bold;
        border: none;

        &:hover {
            background: #c6cbce;
        }
    }
`;


const CartList = ({props, text, price}) => {
    return (
        <CartListStyled>
            <h2>{text}</h2>
            <p>Price: {price} SEK</p>
        </CartListStyled>
    )};

CartList.propTypes = {
    description: PropTypes.string,
};

export default CartList;