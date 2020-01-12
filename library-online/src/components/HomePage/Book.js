/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from "react";

class Book extends Component {
  render() {
    return (
      <div className="col-lg-3 col-md-6">
        <div className="item">
          <img src="images/img1.jpg" alt="img" />
          <h3>how to be a bwase</h3>
          <h6>
            <span className="price">$49</span> / <a href="#">Buy Now</a>
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

export default Book;
