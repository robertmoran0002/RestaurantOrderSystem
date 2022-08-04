import React, { Component } from 'react';
import './Home.css';

export class Home extends Component {
  static displayName = Home.name;


  render() {
    return (
        <div id="intro" className="bg-image shadow-2-strong container d-flex align-items-center justify-content-center text-center">
            <div className="text-white"> 
                <h3 className="display-4">Welcome</h3>
                <h5>Please select a category from the navigation bar.</h5>
            </div>
        </div>
    );
  }
}
