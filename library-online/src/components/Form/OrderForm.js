import React, { Component } from "react";
import PropTypes from "prop-types";

class OrderForm extends Component {
  render() {
    var { total } = this.props;
    return (
      <form onSubmit={this.props.handleSubmit}>
        <div className="row">
          <div className="col-md-5">
            <input
              onChange={this.props.handleChange}
              placeholder="Enter Address"
              required
              name="address"
            />
            <span className="required-star">*</span>
          </div>
          <div className="col-md-5">
            <input
              onChange={this.props.handleChange}
              type="number"
              placeholder="Enter quantity"
              required
              name="qty"
            />
            <span className="required-star">*</span>
          </div>
          <div className="col-md-5">
            <h3>Total</h3>
            <div
              onChange={() => {
                this.props.totalPrice();
              }}
            >
              {`${total} VND`}
            </div>
          </div>
          <div className="col-lg-8 col-md-12">
            <button type="submit" className="btn black">
              Order
            </button>
          </div>
        </div>
      </form>
    );
  }
}

OrderForm.propTypes = {
  handleChange: PropTypes.func,
  handleSubmit: PropTypes.func
};

export default OrderForm;
