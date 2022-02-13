import React, { useEffect, useState } from 'react';
import ShipDataService from '../services/ship.service';
import { useNavigate } from "react-router-dom";

function ShipList(){
    const [ships, setShips] = useState([])
    const navigate = useNavigate();

    useEffect(() => {
        ShipDataService.getAll()
        .then(res=> {
            setShips(res.data.data);
        });
    }, [])

    const deleteShip = function(id) {
        var isDeleteConfirmed = window.confirm('Are you sure you want to delete this ship?');
        if(isDeleteConfirmed == true) {
            ShipDataService.delete(id).then((res)=>{
                if(res.status == 200){
                    if(res.data.isSuccess == true){
                        setShips(ships.filter(function(x){
                            return x.id != id;
                        }));
                    }else{
                        alert(res.data.message);
                    }
                }else{
                    window.alert('Unable to delete ship');
                }
            })
        }
    }

    const editShip = function(id){
        navigate(`/editship/${id}`);
    }

    return (
        <table className="table table-bordered">
            <thead>
                <tr>
                    <th>Code</th>
                    <th>Name</th>
                    <th>Width</th>
                    <th>Length</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
              {ships.map((ship, key)=>{
                return(<tr>
                    <td>{ship.code}</td>
                    <td>{ship.name}</td>
                    <td>{ship.width}</td>
                    <td>{ship.length}</td>
                    <td>
                        <button type='button' onClick={(e)=> editShip(ship.id)} className='btn btn-sm btn-primary margin-right-5'>Edit</button>
                        <button type='button' onClick={(e)=> deleteShip(ship.id)} className='btn btn-sm btn-danger'>Delete</button>
                    </td>
                </tr>)
              })}
            </tbody>
        </table>
      );
}




export default ShipList;