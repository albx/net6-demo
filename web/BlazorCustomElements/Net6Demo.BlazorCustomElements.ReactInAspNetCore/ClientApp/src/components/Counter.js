import React, { Component } from 'react';

export class Counter extends Component {
  increment = 10;
  render() {
    return (
      <div>
        <my-blazor-counter increment={this.increment}></my-blazor-counter>
      </div>
    );
  }
}
