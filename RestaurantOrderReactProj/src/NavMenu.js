import 'bootstrap/dist/css/bootstrap.css';
import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
            <Navbar className="navbar navbar-dark navbar-expand-lg bg-dark border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to="/">Restaurant Order System</NavbarBrand>
          <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-white" to="/home">Home</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-white" to="/orders">Orders</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-white" to="/menu">Menu</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-white" to="/locations">Locations</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-white" to="/categories">Categories</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-white" to="/regions">Regions</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-white" to="/countries">Countries</NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Navbar>
      </header>
    );
  }
}
