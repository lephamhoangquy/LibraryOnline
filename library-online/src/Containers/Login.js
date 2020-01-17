import React, { Component } from "react";
import LoginForm from "../components/Form/LoginForm";
import Header from "../components/HomePage/Header";
import BreadCrumb from "../components/BookDetails/BreadCrumb";
import Footer from "../components/HomePage/Footer";
import callApi from "../utils/apiCaller";
import { AUTH_API_URL, API_URL } from "../config";

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      passWord: ""
    };
  }

  handleChange = event => {
    var name = event.target.name;
    var value = event.target.value;
    this.setState({
      [name]: value
    });
  };

  handleSubmit = e => {
    e.preventDefault();
    const { email, passWord } = this.state;
    const body = { email, passWord };
    callApi(AUTH_API_URL, "authentication", "POST", null, body).then(res => {
      const { token, email } = res.data.data;
      const headers = {
        authorization: `${token}`
      };
      return callApi(API_URL, "role", "GET", headers, null).then(res => {
        const { permission } = res.data.data;
        if (permission === 1) {
          localStorage.setItem("token", token);
          localStorage.setItem("email", email);
          window.location.href = "/";
        }
      });
    });
  };

  render() {
    return (
      <div>
        <Header />
        <BreadCrumb />
        <section className="static about-sec">
          <div className="container">
            <h1>My Account / Login</h1>
            <div className="form">
              <LoginForm
                handleChange={this.handleChange}
                handleSubmit={this.handleSubmit}
              />
            </div>
          </div>
        </section>
        <Footer />
      </div>
    );
  }
}

export default Login;
