import React from 'react';

function Signup() {
    return (
        <div className="container mt-5">
            <div className="row justify-content-center">
                <div className="col-md-6">
                    <h2 className="text-center mb-4">Signup</h2>
                    <form>
                        <div className="mb-3">
                            <label htmlFor="username" className="form-label">Username</label>
                            <input type="text" className="form-control" id="username" placeholder="Username" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="firstName" className="form-label">FirstName</label>
                            <input type="firstName" className="form-control" id="firstName" placeholder="First Name" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="lastName" className="form-label">LastName</label>
                            <input type="lastName" className="form-control" id="lastName" placeholder="Last Name" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="email" className="form-label">Email</label>
                            <input type="email" className="form-control" id="email" placeholder="Email" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="password" className="form-label">Password</label>
                            <input type="password" className="form-control" id="password" placeholder="Password" />
                        </div>
                        <div className="mb-3">
                            <button type="submit" className="btn btn-primary">Sign Up</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default Signup;
