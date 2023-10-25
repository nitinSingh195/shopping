import React from 'react';

const Navbar = () => {
    const userName = 'John Doe'; // Replace with the actual user name
    const cartItemCount = 5; // Replace with the actual cart item count

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
            <div className="ml-auto">
                {/* <span className="navbar-text">
                    <span className="badge bg-primary mr-2">{cartItemCount}</span>
                    Welcome, {userName}
                </span> */}
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
