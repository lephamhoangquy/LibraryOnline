import React, { Component } from "react";

class BreadCrumb extends Component {
  render() {
    return (
      <div className="breadcrumb">
        <div className="container">
          <a className="breadcrumb-item" href="index.html">
            Home
          </a>
          <span className="breadcrumb-item active">Terms and Condition</span>
        </div>
      </div>
    );
  }
}

export default BreadCrumb;
