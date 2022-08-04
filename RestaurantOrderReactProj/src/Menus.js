import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './Layout';

export class Menus extends Component {
    static displayName = Menus.name;
    constructor(props) {
        super(props);
        this.state = { menuItems: [], loading: true };
    }
    render() {
        let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : Menus.renderMenuTable(this.state.menuItems);

    return (
        <div>
            <h1 className="text-center">Menu</h1>
            {contents }

        </div>
    );
    }
    componentDidMount() {
        this.populateMenuData();
    }
    populateMenuData() {
        fetch('https://localhost:7011/api/Menus', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(response =>  response.json())
        .then(data=>{ this.setState({ menuItems: data, loading: false });})
        .catch((error) => {console.log(error)});
       
    }

    static renderMenuTable(menuItems) {
        return (
            <table className='table' aria-labelledby="tabelLabel">
                <thead className="table-dark">
                    <tr>
                        <th>Item ID</th>
                        <th>Item Name</th>
                        <th>Description</th>
                        <th>Notes</th>
                        <th>Category</th>
                        <th>Price</th>

                    </tr>
                </thead>
                <tbody>
                    {menuItems.map(menux =>
                        <tr key={menux.itemId}>
                            <td>{menux.itemId}</td>
                            <td>{menux.name}</td>
                            <td>{menux.description}</td>
                            <td>{menux.notes}</td>
                            <td>{menux.categoryId}</td>
                            <td>{menux.price}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}