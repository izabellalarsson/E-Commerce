import React, { Component } from 'react';
import './App.css';
import {Route} from 'react-router-dom'
import Header from '../Header'
import Product from '../Product'



class App extends Component {

  state = {

  }

  componentDidMount() {
    this.fetchProducts();
  }

 fetchProducts = () => {
    fetch("http://localhost:5000/api/product")
    .then(res => res.json())
    .then(data => console.log(data))
  }
  render() {
    return (
      <div className="App">
      <Header/>
      <Route exact path='/' component={App}/>
      <Route path='/products' component={Product}/>
      {/* <Route path='/cart' component={Cart}/> */}
      </div>
    );
  }
}

export default App;
