/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

class Book extends Component {
  render() {
    const { book } = this.props;
    return (
      <div className="col-lg-3 col-md-6">
        <div className="item">
          <img src={`data:image/jpeg;base64,${book.picture}`} alt="img" />
          <h3>{book.title}</h3>
          <h6>
            <span className="price">{book && `${book.price} VND`}</span> /{" "}
            <Link to={`/book/buy/${book.bookID}`}>Buy Now</Link>
          </h6>
          <div className="hover">
            <Link to={`/book/${book.bookID}`}>
              <span>
                <i className="fa fa-long-arrow-right" aria-hidden="true"></i>
              </span>
            </Link>
          </div>
        </div>
      </div>
    );
  }
}

Book.propTypes = {
  book: PropTypes.object
};

export default Book;
