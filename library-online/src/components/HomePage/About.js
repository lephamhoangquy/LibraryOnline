/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable react/style-prop-object */
import React, { Component } from "react";

class About extends Component {
  render() {
    return (
      <section className="about-sec">
        <div className="about-img">
          <figure>
            <img src="images/about-img.jpg" />
          </figure>
        </div>
        <div className="about-content">
          <h2>About ELib,</h2>
          <p>
            Lorem Ipsum is simply dummy text of the printing and typesetting
            industry. Lorem Ipsum has been the industry's printer took a galley
            of type and Scrambled it to make a type and typesetting industry.
            Lorem Ipsum has been the book.
          </p>
          <p>
            It has survived not only fiveLorem Ipsum is simply dummy text of the
            printing and typesetting industry. Lorem Ipsum has been the
            industry's printer took a galley of type and
          </p>
          <div className="btn-sec">
            <a href="shop.html" className="btn yellow">
              shop books
            </a>
            <a href="login.html" className="btn black">
              subscriptions
            </a>
          </div>
        </div>
      </section>
    );
  }
}

export default About;
