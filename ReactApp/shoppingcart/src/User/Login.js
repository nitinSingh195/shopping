import React, { useState } from 'react';
import axios from 'axios';

function Login() {
 const [formData, setFormData] = useState({
        Username: '',
        PasswordHash: '',
    });

    const handleChange = (event) => {
        const { name, value } = event.target;
        setFormData({ ...formData, [name]: value });
    };

    const login = async () => {
        try {
            const response = await axios.post('https://localhost:44384/api/Auth/login', formData);
            if (response.data && response.data.accessToken) {
                localStorage.setItem('accessToken', response.data.accessToken);
                console.log(response.data);
                // Redirect to the authorized page, e.g., the dashboard
                // You can use a router for navigation
            } else {
                console.error('Authentication failed');
            }
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <div className="container mt-5">
            <div className="row justify-content-center">
                <div className="col-md-6">
                    <h2 className="text-center mb-4">Login</h2>
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
                            <button type="button" className="btn btn-primary" onClick={login}>
                                LogIn
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default Login;
