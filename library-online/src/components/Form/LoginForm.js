import React from "react";
import { Link } from "react-router-dom";
import { Field, reduxForm } from "redux-form";

let LoginForm = props => {
  const { handleSubmit } = props;
  return (
    <form onSubmit={handleSubmit}>
      <div className="row">
        <div className="col-md-5">
          <Field name="username" component="input" type="text" />
          <span className="required-star">*</span>
        </div>
        <div className="col-md-5">
          <Field name="password" component="input" type="password" />
          <span className="required-star">*</span>
        </div>
        <div className="col-lg-8 col-md-12">
          <button className="btn black">Login</button>
          <h5>
            not Registered?
            <Link to="/register">Register here</Link>
          </h5>
        </div>
      </div>
    </form>
  );
};

LoginForm = reduxForm({
  form: "Login"
})(LoginForm);

export default LoginForm;
