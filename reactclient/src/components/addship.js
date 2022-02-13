import React from 'react';
import ShipForm from './shipform'
import  {  useNavigate } from "react-router-dom";

function AddShip() {
    const navigate = useNavigate();

    return (
      <div>
        <h3>Add Ship</h3>
        <ShipForm navigate={navigate} />
      </div>
    );
  }
  
  export default AddShip;