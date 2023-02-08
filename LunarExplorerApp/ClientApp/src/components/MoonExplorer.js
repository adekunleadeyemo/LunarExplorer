import React, { Component } from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";


export class MoonExplorer extends Component {

    //state = { plateau: [{ height: 100, width: 100 }], rovers: [{ x: 1, y: 3, orient: "N", d: "LLLL" }], loadRover: false, loadPlateau:false};
  
    constructor(props){
        super(props);

        this.state = { plateau: [], rovers: [], loadRover: true, loadPlateau: true };
    }

    componentDidMount() {
        this.getRovers();
        this.getPlateau();
    }



    render() {
        let roverContents = this.state.loadRover
            ? <p><em>Loading...</em></p>
            : MoonExplorer.renderRovers(this.state.rovers);
        let plateauContents = this.state.loadPlateau
            ? <p><em>Loading...</em></p>
            : MoonExplorer.renderPlateau(this.state.plateau[0]);

       return(
           <div>
               {plateauContents}
               {roverContents}
        </div>
       )
    }
    static renderPlateau(plateau) {

        return (
            <div>
                <div>
                 <div className="row hd">
                <div className="col-sm-3">
                    <p><strong>Plateau</strong></p>
                    <Link className="bt-in" to={"/plateau"}>Edit Plateau</Link>
                </div>
                
                </div>
                <ul>
                    <li>Height: {plateau.length}</li>
                    <li>Width: {plateau.breadth}</li>
                </ul>
                
             </div>
        </div>
        );
    }


    static renderRovers(rovers) {
        function refreshPage() {
            window.location.reload(false);
        }
        return (
            <div>
             <div className="row hd">
                <div className="col-sm-3">
                <p><strong>Rovers</strong></p>
                    <Link className="bt-in" to={"/rover"}>Add Rover</Link>
                </div>
               
                </div>
                <ul>
                    {rovers.map((rover, idx) => 
                    (
                            <li> Rover {idx + 1}
                                <button onClick={(() => { fetch(`weatherforecast/rovers/${rover.id}`, { method: 'DELETE' }); refreshPage(); })}>remove</button>
                            <ul>
                                <li>x: {rover.xCord}</li>
                                <li>y: {rover.yCord}</li>
                                <li>orient: {rover.orient}</li>
                                <li>directions: {rover.directions}</li>
                            </ul>
                        </li>
                    )
                    )}
                </ul>
                <Link className="bt" to={"/"}>Go Back</Link>
                <Link className="bt" to={"/result"}>explore</Link>
            </div>
        );
    }

    async getRovers() {
        const response = await fetch('weatherforecast/rovers');
        const data = await response.json();
        this.setState({ ...this.state, rovers: data, loadRover: false });
    }
    async getPlateau() {
        const response = await fetch('weatherforecast/plateau');
        const data = await response.json();
        this.setState({ ...this.state, plateau: data, loadPlateau: false });
    }
}