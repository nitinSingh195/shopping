import React, { useState } from 'react';
import axios from 'axios';
import MessagePopup from '../MessagePopup';
function Signup() {
    const [formData, setFormData] = useState({
        Username: '',
        FirstName: '',
        LastName: '',
        Email: '',
        PasswordHash: '',
        Role:'IT',
    });
    const [message, setMessage] = useState('');
    const [messageType, setMessageType] = useState('');
    const [validationErrors, setValidationErrors] = useState({});

    const handleChange = (event) => {
        const { name, value } = event.target;
        setFormData({ ...formData, [name]: value });
    };

    const validateForm = () => {
        const errors = {};

        if (!formData.Username) {
            errors.Username = 'Username is required';
        }

        if (!formData.FirstName) {
            errors.FirstName = 'First Name is required';
        }

        if (!formData.LastName) {
            errors.LastName = 'Last Name is required';
        }

        if (!formData.Email) {
            errors.Email = 'Email is required';
        } else if (!/\S+@\S+\.\S+/.test(formData.Email)) {
            errors.Email = 'Invalid email format';
        }

        if (!formData.PasswordHash) {
            errors.PasswordHash = 'Password is required';
        }

        setValidationErrors(errors);

        return Object.keys(errors).length === 0;
    };

    const signupUser = () => {
        if (validateForm()) {
        axios.post('https://localhost:44384/api/users/signup', formData)
            .then(response => {
                setMessage('Signup successful!');
                setMessageType('success');
                setFormData({
                    Username: '',
                    FirstName: '',
                    LastName: '',
                    Email: '',
                    PasswordHash: '',
                    Role:'IT',
                });
                setTimeout(() => {
                    setMessage('');
                }, 5000);
            })
            .catch(error => {
                console.error('Error:', error);
                setMessage('Error signing up. Please try again.');
                setMessageType('error');
            });
        }    
    };

    return (
        <div className="container mt-5">
            <div className="row justify-content-center">
                <div className="col-md-6">
                <div className="card">
                        <div className="card-body">
                    <h2 className="text-center mb-4">Sign Up</h2>
                    <form>
                        <div className="mb-3">
                            <label htmlFor="username" className="form-label">Username</label>
                            <input
                                type="text"
                                className={`form-control ${validationErrors.Username ? 'is-invalid' : ''}`}
                                id="username"
                                name="Username"
                                placeholder="Username"
                                value={formData.Username}
                                onChange={handleChange}
                            />
                             {validationErrors.Username && (
                                <div className="invalid-feedback">{validationErrors.Username}</div>
                            )}
                        </div>
                        <div className="mb-3">
                            <label htmlFor="firstName" className="form-label">First Name</label>
                            <input
                                type="text"
                                className={`form-control ${validationErrors.FirstName ? 'is-invalid' : ''}`}
                                id="firstName"
                                name="FirstName"
                                placeholder="First Name"
                                value={formData.FirstName}
                                onChange={handleChange}
                            />
                            {validationErrors.FirstName && (
                                <div className="invalid-feedback">{validationErrors.FirstName}</div>
                            )}
                        </div>
                        <div className="mb-3">
                            <label htmlFor="lastName" className="form-label">Last Name</label>
                            <input
                                type="text"
                                className={`form-control ${validationErrors.LastName ? 'is-invalid' : ''}`}
                                id="lastName"
                                name="LastName"
                                placeholder="Last Name"
                                value={formData.LastName}
                                onChange={handleChange}
                            />
                            {validationErrors.LastName && (
                                <div className="invalid-feedback">{validationErrors.LastName}</div>
                            )}
                        </div>
                        <div className="mb-3">
                            <label htmlFor="email" className="form-label">Email</label>
                            <input
                                type="email"
                                className={`form-control ${validationErrors.Email ? 'is-invalid' : ''}`}
                                id="email"
                                name="Email"
                                placeholder="Email"
                                value={formData.Email}
                                onChange={handleChange}
                            />
                            {validationErrors.Email && (
                                <div className="invalid-feedback">{validationErrors.Email}</div>
                            )}
                        </div>
                        <div className="mb-3">
                            <label htmlFor="password" className="form-label">Password</label>
                            <input
                                type="password"
                                className={`form-control ${validationErrors.PasswordHash ? 'is-invalid' : ''}`}
                                id="password"
                                name="PasswordHash"
                                placeholder="Password"
                                value={formData.PasswordHash}
                                onChange={handleChange}
                            />
                            {validationErrors.PasswordHash && (
                                <div className="invalid-feedback">{validationErrors.PasswordHash}</div>
                            )}
                        </div>
                        <div className="mb-3">
                            <button type="button" className="btn btn-primary" onClick={signupUser}>
                                Sign Up
                            </button>
                        </div>
                    </form>
                    </div>
                    </div>
                    {message && <MessagePopup message={message} type={messageType} onClose={() => setMessage('')} />}
                </div>
            </div>
        </div>
    );
}

export default Signup;
