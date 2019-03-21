import React from 'react';
import PropTypes from 'prop-types';
import './Header.css'
import {Link} from 'react-router-dom'


const Header = props => {
    return (
        <nav className="navbar">
            <ul className="navbar-nav">
                <li>
                    <img src="" alt="" />
                </li>
                <li>
                    <Link to='/product'>Products</Link> 
                </li>
                <li>
                    <a href="#">Register</a>
                </li>
                <li>
                    <a href="#">Log in</a>
                </li>
                <li>
                    <a href="#">Admin</a>
                </li>
                <li>
                    <Link to='/cart'>Cart
                        <i className="fas fa-shopping-cart"></i>
                    </Link> 
                
                </li>
            </ul>
        </nav>
    );
};

Header.propTypes = {
    
};

export default Header;