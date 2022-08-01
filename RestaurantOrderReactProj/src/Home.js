import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
        <div class="text-center">
            <h3 class="display-4">Restaurant Database</h3>
            <p>Please select a category from the navigation bar.</p>
        </div>
    );
  }
}
