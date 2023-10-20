import React, { useState } from 'react';
import axios from 'axios';

function Signup() {
    const initialFormData = {
        Username: '',
        FirstName: '',
        LastName: '',
        Email: '',
        PasswordHash: '',
        Role: '',
    };

    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (event) => {
        const { name, value } = event.target;
        setFormData({ ...formData, [name]: value });
    };

    const signupUser = () => {
        console.log(formData);
        axios.post('https://localhost:44384/api/users/signup', formData)
            .then(response => {
                alert("signup successful");
                setFormData(initialFormData);
            })
            .catch(error => {
                console.error('Error:', error);
            });
    };

    return (
        <div className="container mt-5">
            <div className="row justify-content-center">
                <div className="col-md-6">
                    <h2 className="text-center mb-4">Signup</h2>
                    <form>
                        <div className="mb-3">
                            <label htmlFor="username" className="form-label">Username</label>
                            <input
                                type="text"
                                className="form-control"
                                id="username"
                                name="Username"
                                placeholder="Username"
                                value={formData.Username}
                                onChange={handleChange}
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="firstName" className="form-label">First Name</label>
                            <input
                                type="text"
                                className="form-control"
                                id="firstName"
                                name="FirstName"
                                placeholder="First Name"
                                value={formData.FirstName}
                                onChange={handleChange}
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="lastName" className="form-label">Last Name</label>
                            <input
                                type="text"
                                className="form-control"
                                id="lastName"
                                name="LastName"
                                placeholder="Last Name"
                                value={formData.LastName}
                                onChange={handleChange}
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="email" className="form-label">Email</label>
                            <input
                                type="email"
                                className="form-control"
                                id="email"
                                name="Email"
                                placeholder="Email"
                                value={formData.Email}
                                onChange={handleChange}
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="password" className="form-label">Password</label>
                            <input
                                type="password"
                                className="form-control"
                                id="password"
                                name="PasswordHash"
                                placeholder="Password"
                                value={formData.PasswordHash}
                                onChange={handleChange}
                            />
                        </div>

                        <div className="mb-3">
                            <label htmlFor="role" className="form-label">Role</label>
                            <input
                                type="role"
                                className="form-control"
                                id="role"
                                name="Role"
                                placeholder="Role"
                                value={formData.Role}
                                onChange={handleChange}
                            />
                        </div>

                        <div className="mb-3">
                            <button type="button" className="btn btn-primary" onClick={signupUser}>
                                Sign Up
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default Signup;
