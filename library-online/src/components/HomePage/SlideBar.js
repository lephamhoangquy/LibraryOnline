/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from "react";

class SlideBar extends Component {
  render() {
    return (
      <section className="slider">
        <div className="container">
          <div id="owl-demo" className="owl-carousel owl-theme">
            <div className="item">
              <div className="slide">
                <img src="images/slide1.jpg" alt="slide1" />
                <div className="content">
                  <div className="title">
                    <h3>welcome to elib</h3>
                    <h5>Discover the best books online with us</h5>
                    <a href="#" className="btn">
                      shop books
                    </a>
                  </div>
                </div>
              </div>
            </div>
            <div className="item">
              <div className="slide">
                <img src="images/slide2.jpg" alt="slide1" />
                <div className="content">
                  <div className="title">
                    <h3>welcome to elib</h3>
                    <h5>Discover the best books online with us</h5>
                    <a href="#" className="btn">
                      shop books
                    </a>
                  </div>
                </div>
              </div>
            </div>
            <div className="item">
              <div className="slide">
                <img src="images/slide3.jpg" alt="slide1" />
                <div className="content">
                  <div className="title">
                    <h3>welcome to elib</h3>
                    <h5>Discover the best books online with us</h5>
                    <a href="#" className="btn">
                      shop books
                    </a>
                  </div>
                </div>
              </div>
            </div>
            <div className="item">
              <div className="slide">
                <img src="images/slide4.jpg" alt="slide1" />
                <div className="content">
                  <div className="title">
                    <h3>welcome to elib</h3>
                    <h5>Discover the best books online with us</h5>
                    <a href="#" className="btn">
                      shop books
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    );
  }
}

export default SlideBar;
