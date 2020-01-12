/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from "react";
import Book from "../HomePage/Book";

class ListBook extends Component {
  render() {
    return (
      <div className="container">
        <h2>highly recommendes books</h2>
        <div className="recomended-sec">
          <div className="row">
            <Book />
            <Book />
          </div>
        </div>
      </div>
    );
  }
}

export default ListBook;
