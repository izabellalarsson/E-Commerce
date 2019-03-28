import React from 'react';
import styled from 'styled-components';
import PropTypes from 'prop-types';

const ProductListStyled = styled.div`
    /* width: 20vw; */
    /* height: auto; */
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
        /* border-radius: 10px 10px 0 0; */
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

const ProductList = ({onClick, image, name, description, price, props}) => {
    return (
        <ProductListStyled>
            <h1>{name}</h1>
            <img src={image} alt="" />
            <p>{description}</p>
            <p>{price} SEK</p>
            <button onClick={onClick}>Buy it here!</button>
        </ProductListStyled>   
)};

ProductList.propTypes = {
        image: PropTypes.string,
        name: PropTypes.string,
        description: PropTypes.string,
        price: PropTypes.number,
};

export default ProductList;