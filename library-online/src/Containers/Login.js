import React, { Component } from "react";
import LoginForm from "../components/Form/LoginForm";
import Header from "../components/HomePage/Header";
import BreadCrumb from "../components/BookDetails/BreadCrumb";
import Footer from "../components/HomePage/Footer";

class Login extends Component {
  render() {
    return (
      <div>
        <Header />
        <BreadCrumb />
        <section className="static about-sec">
          <div className="container">
            <h1>My Account / Login</h1>
            <div className="form">
              <LoginForm />
            </div>
          </div>
        </section>
        <Footer />
      </div>
    );
  }
}

export default Login;
