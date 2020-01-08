import React, { Component } from "react";
import Book from "./Book";

class ListBook extends Component {
  render() {
    return (
      <section className="recomended-sec">
        <div className="container">
          <div className="title">
            <h2>highly recommendes books</h2>
            <hr />
          </div>
          <div className="row">
            <Book />
            <Book />
            <Book />
            <Book />
          </div>
        </div>
      </section>
    );
  }
}

export default ListBook;
