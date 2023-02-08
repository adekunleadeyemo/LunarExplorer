import React, { Component } from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink, useNavigate } from "react-router-dom";

export class Plateau extends Component {
    state = {
        length: 0,
        breadth: 0
    }

    onChange = e => {
        this.setState({ ...this.state, [e.target.name]: e.target.value })
    }

    options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    };
    onSubmit = e => {
        e.preventDefault();

        fetch('weatherforecast/plateau', { ...this.options, body: JSON.stringify(this.state) })

        this.setState({
            length: 0,
            breadth: 0
        })
        this.props.navigate("/moonexplorer")
        this.refreshPage();
    }
  render() {
    return (
     <div>
        <h4>Enter Plateau Details</h4>
        <form onSubmit={this.onSubmit}>
        <label for="length">Length: </label>
        <input className="h-ip" type="number" id="length" name="length" onChange={this.onChange}/><br/>
        <label for="breadth">Breadth:</label>
        <input className="w-ip" type="number" id="breadth" name="breadth" onChange={this.onChange}/><br/>
         <button type="submit">submit</button>
         </form>
     <Link className="bt" to={"/moonexplorer"}>Go Back</Link>
      </div>
    );
  }
}

export function PlateauWithRouter(props) {
    const navigate = useNavigate()
    return (<Plateau navigate={navigate}></Plateau>)
}