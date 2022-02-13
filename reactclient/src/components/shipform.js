
import React from "react";
import ShipDataService from '../services/ship.service';

export default class ShipForm extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            name: '',
            code: '',
            width: 0,
            length: 0,
            errors: []
        }
        this.setCode = this.setCode.bind(this);
        this.setName = this.setName.bind(this);
        this.setWidth = this.setWidth.bind(this);
        this.setLength = this.setLength.bind(this);
        this.setErrors = this.setErrors.bind(this);


        this.handleSubmit = this.handleSubmit.bind(this);
        this.navigate  = this.props.navigate;
        
        this.setErrors = this.setErrors.bind(this);
        if(this.props.loadShip === true){
            ShipDataService.get(this.props.id).then(res=>{
                if(res.status === 200){
                    this.setState(res.data.data)
                }
              })
        }
    }


    setErrors(errors){
        this.setState({
            errors: errors
        })
    }

    setCode(e){
        this.setState({
            code: e.target.value
        })
    }

    setName(e){
        this.setState({
            name: e.target.value
        })
    }

    setWidth(e){
        this.setState({
            width: e.target.value
        })
    }

    setLength(e){
        this.setState({
            length: e.target.value
        })
    }

    handleSubmit(event){
        event.preventDefault();
        if(this.props.loadShip == true){
            ShipDataService.update(this.props.id,this.state).then(res=>{
                if(res.status == 200){
                    if(res.data.isSuccess){
                        this.navigate("/");
                    }else{
                        alert(res.data.message);
                    }
                } else{
                    window.alert('Unable to update ship');
                }
            }).catch((error)=>{
                this.setErrors(error.response.data);
            });
        }else{
            ShipDataService.create(this.state).then(res=>{
                if(res.status == 200){
                    if(res.data.isSuccess){
                        this.navigate("/");
                    }else{
                        alert(res.data.message);
                    }
                }else{
                    window.alert('Unable to add new ship');
                }
            }).catch((error)=>{
                this.setErrors(error.response.data);
            });
        }
    }

    render(){
        return (
            <form className="form-horizontal" onSubmit={this.handleSubmit}>
                <ul className="text-danger">
                {this.state.errors.map(s=>{
                    return (
                        <li>{s}</li>
                    )
                })}
                </ul>
                <div className="form-group">
                    <label htmlFor="inputEmail3" className="col-sm-2 control-label">Code</label>
                    <div className="col-sm-10">
                    <input type="text" value={this.state.code} onChange={this.setCode} className="form-control" id="inputEmail3" placeholder="Code" />
                    </div>
                </div>
                <div className="form-group">
                    <label htmlFor="inputEmail3" className="col-sm-2 control-label">Name</label>
                    <div className="col-sm-10">
                    <input type="text" value={this.state.name} onChange={this.setName} className="form-control" id="inputEmail3" placeholder="Name" />
                    </div>
                </div>
                <div className="form-group">
                    <label htmlFor="inputEmail3" className="col-sm-2 control-label">Width (mm)</label>
                    <div className="col-sm-10">
                    <input type="number" value={this.state.width} onChange={this.setWidth} className="form-control" id="inputEmail3" placeholder="Width (mm)" />
                    </div>
                </div>
                <div className="form-group">
                    <label htmlFor="inputEmail3" className="col-sm-2 control-label">Length (mm)</label>
                    <div className="col-sm-10">
                    <input type="number" value={this.state.length} onChange={this.setLength} className="form-control" id="inputEmail3" placeholder="Length (mm)" />
                    </div>
                </div>
                <div className="form-group">
                    <div className="col-sm-offset-2 col-sm-10">
                    <button type="submit" className="btn btn-primary">Save</button>
                    <button type="reset" className="btn btn-danger">Clear</button>
                    </div>
                </div>
            </form>
        );
    }
}

// function ShipForm(props){



//     const [name, setName] = useState(props.name);
//     const [code, setCode] = useState(props.code);
//     const [width, setWidth] = useState(props.width);
//     const [length, setLength] = useState(props.length);

//     const navigate = useNavigate();

//     const handleSubmit = (event) => {
//         event.preventDefault();
//         ShipDataService.create({
//             name: name,
//             code: code,
//             width: width,
//             length: length
//         }).then(res=>{
//             if(res.status == 200){
//                 navigate("/");
//             }else{
//                 window.alert('Unable to add new ship');
//             }
//         })
//       }
// }
