/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from "react";
import Book from "../HomePage/Book";
import PropTypes from "prop-types";

class ListBook extends Component {
  render() {
    const { books, title } = this.props;
    return (
      <section className="recomended-sec">
        <div className="container">
          <div className="title">
            <h2>{title}</h2>
            <hr />
          </div>
          <div className="recomended-sec">
            <div className="row">
              {Array.isArray(books) &&
                books.length > 0 &&
                books.map((book, index) => <Book key={index} book={book} />)}
            </div>
          </div>
        </div>
      </section>
    );
  }
}

ListBook.propTypes = {
  books: PropTypes.array,
  title: PropTypes.string
};

export default ListBook;
