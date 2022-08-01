import React, { Component } from 'react';
import './NavMenu.css';
import ReactDOM from 'react';

export class Order extends Component {
    constructor(props) {
        super(props);
        this.state = { Orders: [], loading: true };
        var axios = require('axios');
    }

    render() {
        return (
            <div>
                <h1>New Order</h1>

                <p></p>

            </div>
        );
    }
}