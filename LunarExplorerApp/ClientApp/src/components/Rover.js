import React, { Component } from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink, useNavigate} from "react-router-dom";

export class Rover extends Component {
   
    state = {
        xCord: 0,
        yCord: 0,
        orient: "",
        directions:""
    }

    onChange = e => {
        this.setState({ ...this.state, [e.target.name]:e.target.value })
    }

     options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    };
    onSubmit = e => {
        e.preventDefault();

        fetch('weatherforecast/rovers', { ...this.options, body: JSON.stringify(this.state) })

        this.setState({
            xCord: 0,
            yCord: 0,
            orient: "",
            directions: ""
        })
        
        this.props.navigate("/moonexplorer")
        this.refreshPage();
    }
  

    render() {
        const { xCord, yCord, orient, directions } = this.state;
    return (
     <div>
     <h4>Enter Rover Details</h4>
     <form onSubmit={this.onSubmit}>
        <label for="xCord">x: </label>
        <input className="h-ip" type="number" id="xCord" name="xCord" onChange={this.onChange}/><br/>
        <label for="yCord">y:</label>
        <input className="h-ip" type="number" id="yCord" name="yCord" onChange={this.onChange} /><br/>
        <label for="orient">orient:</label>
        <input className="h-ip" type="text" id="orient" name="orient" onChange={this.onChange} /><br/>
        <label for="directions">directions:</label>
        <input className="h-ip" type="text" id="directions" name="directions" onChange={this.onChange} /><br/>
        <button type="submit">submit</button>
     </form>
     
     <Link className="bt" to={"/moonexplorer"}>Go Back</Link>
      </div>
    );
  }
}

export function RoverWithRouter(props) {
    const navigate = useNavigate()
    return (<Rover navigate={navigate}></Rover>)
}