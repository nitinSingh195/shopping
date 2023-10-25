import React from 'react';
import { useSelector } from 'react-redux';
const Navbar = () => {
    const userName = useSelector((state) => state.user.userName);
    const cartItemCount = 5; // Replace with the actual cart item count
    //const userId = useSelector((state) => state.user.userId);
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <a className="navbar-brand" href="/">Shopping Cart</a>
            <button
                className="navbar-toggler"
                type="button"
                data-toggle="collapse"
                data-target="#navbarNav"
                aria-controls="navbarNav"
                aria-expanded="false"
                aria-label="Toggle navigation"
            >
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarNav">
                <ul className="navbar-nav">
                    <li className="nav-item active">
                        <a className="nav-link" href="/">Home</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="/about">Products</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="/contact">Profile</a>
                    </li>
                </ul>
            </div>
            <div className="ml-auto mr-3">
                <span className="navbar-text mr-3">
                    Welcome, {userName}
                </span>
                <button type="button" class="btn btn-primary position-relative">
                    My Cart
                    <span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger">
                    {cartItemCount}
                    </span>
                </button>
            </div>
        </nav>
    );
};

export default Navbar;
