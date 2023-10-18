import logo from './logo.svg';
import './App.css';
import Navbar from './Navbar';
import Signup from './User/signUp';
import { BrowserRouter as Router, Route, Switch, Routes,Navigate } from 'react-router-dom';

function App() {
  return (
    <Router>
        <Navbar />
        <Routes>
        <Route path="/" element={<Navigate to="/signup"/>}/>
          <Route path="/signup" element={<Signup />}/>
          </Routes>
    </Router>
  );
}

export default App;
