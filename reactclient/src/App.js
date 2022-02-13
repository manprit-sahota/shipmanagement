import React from "react";
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import './App.css';
import ShipList from './components/shiplist.js';
import AddShip from './components/addship.js';
import EditShip from './components/editship.js';

function App() {
  return (
    <div>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <a href="/shiplist" className="navbar-brand">
            Ship Management
          </a>
          <div className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to={"/"} className="nav-link">
                Ships
              </Link>
            </li>
            <li className="nav-item">
              <Link to={"/addship"} className="nav-link">
                Add
              </Link>
            </li>
          </div>
        </nav>
        <div className="container mt-3">
          <Routes>
            <Route exact path="/" element={<ShipList/>}></Route>
            <Route exact path="/addship" element={<AddShip/>}  />
            <Route exact path="/editship/:id" element={<EditShip/>}  />
          </Routes>
        </div>
      </div>
  );
}


export default App;
