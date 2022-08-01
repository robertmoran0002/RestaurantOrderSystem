import React, { Component } from 'react';
import '../NavMenu.css';
import { Link } from 'react-router-dom';
import ReactDOM from 'react';

export class Order extends Component {

    static displayName = Order.name;
    constructor(props) {
        super(props);
        this.state = { orders: [], loading: true };
        var axios = require('axios');
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Order.renderOrdersTable(this.state.orders);

        return (
            <div>
                <h1>Orders</h1>
                {contents }
                <p>
                    <button className="btn btn-primary" tag={Link} className="text-white" to="/placeOrder">Place New Order</button>                </p>

            </div>
        );
    }
    componentDidMount() {
        this.populateOrderData();
    }
    async populateOrderData() {
        const response = await fetch('api/OrderMains');
        const data = await response.json();
        this.setState({ orders: data, loading: false });
    }

    static renderOrdersTable(orders) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Order ID</th>
                        <th>Order Number</th>
                        <th>Item</th>
                        <th>Quantity</th>
                        <th>Date Placed</th>
                        <th>Date Complete</th>
                        <th>Order Status</th>

                    </tr>
                </thead>
                <tbody>
                    {orders.map(orderx =>
                        <tr key={orderx.orderId}>
                            <td>{orderx.orderNumber}</td>
                            <td>{orderx.itemId}</td>
                            <td>{orderx.quantity}</td>
                            <td>{orderx.dateTimePlaced}</td>
                            <td>{orderx.dateTimeComplete}</td>
                            <td>{orderx.orderStatus}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}