/* eslint-disable jsx-a11y/anchor-is-valid */
/* eslint-disable jsx-a11y/alt-text */
import React, { Component } from "react";

class BookDetail extends Component {
  render() {
    return (
      <section class="product-sec">
        <div class="container">
          <h1>7 Day Self publish How to Write a Book</h1>
          <div class="row">
            <div class="col-md-6 slider-sec">
              <div id="myCarousel" class="carousel slide">
                <div class="carousel-inner">
                  <div class="active item carousel-item" data-slide-number="0">
                    <img src="images/product1.jpg" class="img-fluid"></img>
                  </div>
                  <div class="item carousel-item" data-slide-number="1">
                    <img src="images/product2.jpg" class="img-fluid"></img>
                  </div>
                  <div class="item carousel-item" data-slide-number="2">
                    <img src="images/product3.jpg" class="img-fluid"></img>
                  </div>
                </div>

                <ul class="carousel-indicators list-inline">
                  <li class="list-inline-item active">
                    <a
                      id="carousel-selector-0"
                      class="selected"
                      data-slide-to="0"
                      data-target="#myCarousel"
                    >
                      <img src="images/product1.jpg" class="img-fluid"></img>
                    </a>
                  </li>
                  <li class="list-inline-item">
                    <a
                      id="carousel-selector-1"
                      data-slide-to="1"
                      data-target="#myCarousel"
                    >
                      <img src="images/product2.jpg" class="img-fluid"></img>
                    </a>
                  </li>
                  <li class="list-inline-item">
                    <a
                      id="carousel-selector-2"
                      data-slide-to="2"
                      data-target="#myCarousel"
                    >
                      <img src="images/product3.jpg" class="img-fluid"></img>
                    </a>
                  </li>
                </ul>
              </div>
            </div>
            <div class="col-md-6 slider-content">
              <p>
                Lorem Ipsum is simply dummy text of the printing and typesetting
                industry. Lorem Ipsum has been the industry's printer took a
                galley of type and Scrambled it to make a type and typesetting
                industry. Lorem Ipsum has been the book.{" "}
              </p>
              <p>
                t has survived not only fiveLorem Ipsum is simply dummy text of
                the printing and typesetting industry. Lorem Ipsum has been the
                industry's printer took a galley of type and
              </p>
              <ul>
                <li>
                  <span class="name">Digital List Price</span>
                  <span class="clm">:</span>
                  <span class="price">$4.71</span>
                </li>
                <li>
                  <span class="name">Print List Price</span>
                  <span class="clm">:</span>
                  <span class="price">$10.99</span>
                </li>
                <li>
                  <span class="name">Kindle Price</span>
                  <span class="clm">:</span>
                  <span class="price final">$3.37</span>
                </li>
                <li>
                  <span class="save-cost">Save $7.62 (69%)</span>
                </li>
              </ul>
              <div class="btn-sec">
                <button class="btn ">Add To cart</button>
                <button class="btn black">Buy Now</button>
              </div>
            </div>
          </div>
        </div>
      </section>
    );
  }
}

export default BookDetail;
