import React, { Component } from 'react';
import '../NavMenu.css';
import ReactDOM from 'react';

export class PlaceOrder extends Component {
    static displayName = PlaceOrder.name;

    constructor(props) {
        super(props);
        this.state = { menus: [], loading: true, choice: '', quant: '' };
        this.handleSubmit.bind(this);
        this.handleChange.bind(this);
    }

    componentDidMount(){
        this.populateInfo();
    }
    handleSubmit(event){
        event.preventDefault();
    }
    handleChange(event){
        var value= event.target.value;
        this.setState({
            ...this.state,
            [event.target.name]: value})
    }

    render() {
        let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : PlaceOrder.renderOrderForm(this.state.menus);

        return (
            <div>
                <h1 className="text-center">Place New Order</h1>
                {contents }

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
        .then(data=>{ this.setState({ menus: data, loading: false});})
        .catch((error) => {console.log(error)});


    }

    static renderOrderForm(menus){
        return (
            <div className="text-center container d-flex align-items-center justify-content-center">
                <form onSubmit={this.handleSubmit}>
                    <label>Menu Item</label>
                    <select name="choice" id="choice" onChange={event=>this.handleChange(event)}>
                        <option value="" key="def">Choose an item from the list</option>
                        {menus.map(menux=> (
                            <option key={menux.itemId} value={menux.itemId}>
                                {menux.name}
                            </option>
                        ))}
                    </select>
                    <p></p>
                    <label>Quanitity</label>
                    <input id="quantity" type="number" onChange={event=>this.handleChange(event)}/>
                    <p></p>
                    <button type="submit">Submit Order</button>
                </form>
            </div>
        );
    }
}