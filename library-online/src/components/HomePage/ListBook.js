/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from "react";
import Book from "../HomePage/Book";

class ListBook extends Component {
  render() {
    return (
      <section className="recomended-sec">
        <div className="container">
          <div className="title">
            <h2>highly recommendes books</h2>
            <hr />
          </div>
          <div className="recomended-sec">
            <div className="row">
              <Book />
              <Book />
            </div>
          </div>
        </div>
      </section>
    );
  }
}

export default ListBook;
