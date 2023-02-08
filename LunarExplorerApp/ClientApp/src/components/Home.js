import React, { Component } from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";

export class Home extends Component {
  render() {
    return (
     <div>
     <h1>Welcome!</h1>
     <Link className="" to={"/plateau"}>Start New Moon Exploration</Link>
      </div>
    );
  }
}
