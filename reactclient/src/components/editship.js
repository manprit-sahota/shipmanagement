import {React, useState} from 'react';
import ShipForm from './shipform'
import { useParams, useNavigate } from "react-router-dom";
import ShipDataService from '../services/ship.service';

function EditShip(props) {
  const {id}= useParams();
  // const [name, setName] = useState('');
  // const [code, setCode] = useState('');
  // const [width, setWidth] = useState(0);
  // const [length, setLength] = useState(0);

  const navigate = useNavigate();

  
    return (
      <div>
        <h3>Edit Ship</h3>
        <ShipForm id={id} navigate={navigate} loadShip={true} />
      </div>
    );
  }
  
  export default EditShip;