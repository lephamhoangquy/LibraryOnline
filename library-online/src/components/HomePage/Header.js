/* eslint-disable jsx-a11y/anchor-is-valid */
import React, { Component } from "react";
import { Link } from "react-router-dom";

class Header extends Component {
  render() {
    const username = localStorage.getItem("email");
    return (
      <header>
        <div className="header-top">
          <div className="container">
            <div className="row">
              <div className="col-md-3">
                <a href="#" className="web-url">
                  www.elib.com
                </a>
              </div>
              <div className="col-md-6">
                <h5>ELib - Modern library for you</h5>
              </div>
              <div className="col-md-3">
                <span className="ph-number">Call : 800 1234 5678</span>
              </div>
            </div>
          </div>
        </div>
        <div className="main-menu">
          <div className="container">
            <nav className="navbar navbar-expand-lg navbar-light">
              <a className="navbar-brand" href="/">
                <img src="images/logo.png" alt="logo" />
              </a>
              <button
                className="navbar-toggler"
                type="button"
                data-toggle="collapse"
                data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent"
                aria-expanded="false"
                aria-label="Toggle navigation"
              >
                <span className="navbar-toggler-icon"></span>
              </button>
              <div
                className="collapse navbar-collapse"
                id="navbarSupportedContent"
              >
                <ul className="navbar-nav ml-auto">
                  <li className="navbar-item active">
                    <Link to="/" className="nav-link">
                      Home
                    </Link>
                  </li>
                  <li className="navbar-item active">
                    <Link to="/books" className="nav-link">
                      Books
                    </Link>
                  </li>
                  {username && (
                    <li className="navbar-item active">
                      <Link to="/" className="nav-link">
                        User: {username}
                      </Link>
                    </li>
                  )}
                  {!username && (
                    <li className="navbar-item active">
                      <Link to="/login" className="nav-link">
                        Login
                      </Link>
                    </li>
                  )}
                </ul>
                <div className="cart my-2 my-lg-0">
                  <span>
                    <i className="fa fa-shopping-cart" aria-hidden="true"></i>
                  </span>
                  <span className="quntity">3</span>
                </div>
                <form className="form-inline my-2 my-lg-0">
                  <input
                    className="form-control mr-sm-2"
                    type="search"
                    placeholder="Search here..."
                    aria-label="Search"
                  />
                  <span className="fa fa-search"></span>
                </form>
              </div>
            </nav>
          </div>
        </div>
      </header>
    );
  }
}

export default Header;
