import React, { Component } from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";


export class Result extends Component {

    //state = { plateau: [{ height: 100, width: 100 }], rovers: [{ x: 1, y: 3, orient: "N", d: "LLLL" }], loadRover: false, loadPlateau:false};

    constructor(props) {
        super(props);

        this.state = { result: [], loading: true };
    }

    componentDidMount() {
        this.getResult();  
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Result.renderResult(this.state.result);

        return (
            <div>
                {contents}
            </div>
        )
    }

    static renderResult(result) {
        return (
            <div>
                <div className="row hd">
                    <div className="col-sm-3">
                        <p><strong>Rovers</strong></p>

                    </div>
              
                </div>
                <ul>
                    {result.map((rslt, idx) =>
                        (
                            <li> Rover {idx + 1}
                                <ul>
                                    <li>New Position: {rslt}</li>
                                </ul>
                            </li>
                        )
                    )}
                </ul>
                <Link className="bt" to={"/moonexplorer"}>Go Back</Link>
            </div>
        );
    }


    async getResult() {
        const response = await fetch('weatherforecast/explore');
        const data = await response.json();
        this.setState({ result:data, loading: false });
    }
}
