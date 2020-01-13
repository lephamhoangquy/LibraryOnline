/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from "react";
import PropTypes from "prop-types";

class Book extends Component {
  render() {
    const { book } = this.props;
    return (
      <div className="col-lg-3 col-md-6">
        <div className="item">
          <img src={book.picture} alt="img" />
          <h3>{book.title}</h3>
          <h6>
            <span className="price">{book && `${book.price} VND`}</span> /{" "}
            <a href="#">Buy Now</a>
          </h6>
          <div className="hover">
            <a href="product-single.html">
              <span>
                <i className="fa fa-long-arrow-right" aria-hidden="true"></i>
              </span>
            </a>
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
