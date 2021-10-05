import React, { Component } from 'react';

export class FetchData extends Component {
  viewSize = 5;

  render() {
    return (
      <div>
        <fetch-data view-size={this.viewSize}></fetch-data>
      </div>
    );
  }
}
