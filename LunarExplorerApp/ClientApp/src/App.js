import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
      return (
          <div className="container d-flex justify-content-center d-flex align-items-center">
            <Routes>
                {AppRoutes.map((route, index) => {
                    const { element, ...rest } = route;
                    return <Route key={index} {...rest} element={element} />;
                })}
            </Routes>
        </div>
        
    );
  }
}
