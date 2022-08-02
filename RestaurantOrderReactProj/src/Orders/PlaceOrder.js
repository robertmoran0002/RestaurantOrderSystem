import React, { Component } from 'react';
import '../NavMenu.css';
import ReactDOM from 'react';

export class PlaceOrder extends Component {
    static displayName = PlaceOrder.name;
    constructor(props) {
        super(props);
        this.state = { orders: [], loading: true };
        var axios = require('axios');
    }

    render() {

        return (
            <div>
                <p>Placeholder</p>
            </div>
        );
    }
}