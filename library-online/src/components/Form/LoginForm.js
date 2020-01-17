import React, { Component } from "react";
import PropTypes from "prop-types";

class LoginForm extends Component {
  render() {
    return (
      <form onSubmit={this.props.handleSubmit}>
        <div className="row">
          <div className="col-md-5">
            <input
              onChange={this.props.handleChange}
              placeholder="Enter User Name"
              required
              name="email"
            />
            <span className="required-star">*</span>
          </div>
          <div className="col-md-5">
            <input
              onChange={this.props.handleChange}
              type="password"
              placeholder="Enter password"
              required
              name="passWord"
            />
            <span className="required-star">*</span>
          </div>
          <div className="col-lg-8 col-md-12">
            <button type="submit" className="btn black">
              Login
            </button>
            <h5>
              not Registered? <a href="register.html">Register here</a>
            </h5>
          </div>
        </div>
      </form>
    );
  }
}

LoginForm.propTypes = {
  handleChange: PropTypes.func,
  handleSubmit: PropTypes.func
};

export default LoginForm;
