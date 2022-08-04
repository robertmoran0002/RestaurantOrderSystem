import React, { Component } from 'react';
import '../NavMenu.css';
import ReactDOM from 'react';

export class PlaceOrder extends Component {
    static displayName = PlaceOrder.name;
    constructor(props) {
        super(props);
        this.state = { menus: [], categories:[], loading: true };
        var axios = require('axios');
    }

    render() {

        return (
            <div>
                <p>Placeholder</p>
            </div>
        );
    }

    populateInfo(){
        fetch('https://localhost:7011/api/Menus', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(response =>  response.json())
        .then(data=>{ this.setState({ menus: data});})
        .catch((error) => {console.log(error)});

        fetch('https://localhost:7011/api/Categories', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(response =>  response.json())
        .then(data=>{ this.setState({ categories: data, loading: false });})
        .catch((error) => {console.log(error)});
    }
}