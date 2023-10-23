import logo from './logo.svg';
import './App.css';
import Navbar from './Navbar';
import Signup from './User/signUp';
import Login from './User/Login';
import { BrowserRouter as Router, Route, Switch, Routes,Navigate } from 'react-router-dom';
import ProductList from './User/ProductList';
import ShoppingCart from './User/ShoppingCart';
function App() {
  return (
    <Router>
        <Navbar/>
        <Routes>
        <Route path="/" element={<Navigate to="/Login"/>}/>
        <Route path="/login" element={<Login />}/>
        <Route path="/productlist" element={<ProductList/>}/>
        {/* <Route path="/" element={<Navigate to="/signup"/>}/> */}
          <Route path="/signup" element={<Signup />}/>
          <Route path='/shoppingcart' element={<ShoppingCart />}/>
          </Routes>
         </Router>
  );
}

export default App;
