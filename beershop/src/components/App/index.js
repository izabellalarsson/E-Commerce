import React from 'react';
import './App.css';
import {Route} from 'react-router-dom';
import Home from '../Home';
import Header from '../Header';
import Product from '../Product';
import Cart from '../Cart';

const App = () => {
  return (
    <div className="App">
      <Header/>
      <Route exact path='/' component={Home}/>
      <Route path='/products' component={Product}/>
      <Route path='/cart' component={Cart}/>
    </div>
  );
}

export default App;
