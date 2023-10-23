
// import React, { useState, useEffect } from 'react';
// import axios from 'axios';
// import './ProductList.css'; 
// import 'bootstrap/dist/css/bootstrap.min.css'; 
// import { useLocation } from 'react-router-dom';

// function ProductList(props) {
// const [products, setProducts] = useState([]);
//  const location = useLocation();
//   const { userId } = location.state || {};
//     useEffect(() => {
//         axios.get(`https://localhost:44384/api/Products?userId=${userId}`)
//             .then(response => {
//                 setProducts(response.data);
//             })
//             .catch(error => {
//                 console.error('Error:', error);
//             });
//         }, [userId]);

//     return (
//         <div className="container mt-5">
//             <h2>Product List</h2>
//             <div className="row">
//                 {products.map(product => (
//                     <div key={product.ProductId} className="col-md-4">
//                         <div className="card mb-4">
//                         <img
//                              src= "Laptop.jpeg" alt = ""
//                                 className="card-img-top"
//                             />
//                             <div className="card-body">
//                                 <h5 className="card-title">{product.productPrice}</h5>
//                                 <p className="card-text">{product.ProductDescription}</p>
//                                 <p className="card-text">Price: ${product.productPrice}</p>
//                                 <p className="card-text">Discounted Price: ${product.discountedPrice}</p>
//                             </div>
//                         </div>
//                     </div>
//                 ))}
//             </div>
//         </div>
//     );
// }

// export default ProductList;



import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './ProductList.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useLocation } from 'react-router-dom';

function ProductList(props) {
  const [products, setProducts] = useState([]);
  const [cart, setCart] = useState([]); 

  const location = useLocation();
  const { userId } = location.state || {};

  useEffect(() => {
    axios
      .get(`https://localhost:44384/api/Products?userId=${userId}`)
      .then((response) => {
        setProducts(response.data);
      })
      .catch((error) => {
        console.error('Error:', error);
      });
  }, [userId]);

   const addToCart = (product) => {
    setCart([...cart, product]);
    console.log(cart)
  };

  return (
    <div className="container mt-5">
      <h2>Product List</h2>
      <div className="row">
        {products.map((product) => (
          <div key={product.ProductId} className="col-md-4">
            <div className="card mb-4">
              <img src="Laptop.jpeg" alt="" className="card-img-top" />
              <div className="card-body">
                <h5 className="card-title">{product.productPrice}</h5>
                <p className="card-text">{product.ProductDescription}</p>
                <p className="card-text">Price: ${product.productPrice}</p>
                <p className="card-text">Discounted Price: ${product.discountedPrice}</p>
                <button
                  className="btn btn-primary"
                  onClick={() => addToCart(product)}
                >
                  Add to Cart
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
export default ProductList;




