/* eslint-disable jsx-a11y/anchor-is-valid */
/* eslint-disable jsx-a11y/alt-text */
import React, { Component } from "react";
import PropTypes from "prop-types";

class Book extends Component {
  render() {
    const { book } = this.props;
    return (
      <section className="product-sec">
        <div className="container">
          <h1>{book.title}</h1>
          <div className="row">
            <div className="col-md-6 slider-sec">
              <div id="myCarousel" className="carousel slide">
                <div className="carousel-inner">
                  <div
                    className="active item carousel-item"
                    data-slide-number="0"
                  >
                    <img
                      src={`data:image/jpeg;base64,${book.picture}`}
                      className="img-fluid"
                    ></img>
                  </div>
                </div>
              </div>
            </div>
            <div className="col-md-6 slider-content">
              <p>{book.aboutBook}</p>
              <ul>
                <li>
                  <span className="name">Quantity</span>
                  <span className="clm">:</span>
                  <span className="price final">{book.qty}</span>
                </li>
                <li>
                  <span className="name"> Price</span>
                  <span className="clm">:</span>
                  <span className="price final">
                    {book && `${book.price} VND`}
                  </span>
                </li>
              </ul>
              <div className="btn-sec">
                <button className="btn ">Add To cart</button>
                <button className="btn black">Buy Now</button>
              </div>
            </div>
          </div>
        </div>
      </section>
    );
  }
}

Book.propTypes = {
  book: PropTypes.object
};

export default Book;
