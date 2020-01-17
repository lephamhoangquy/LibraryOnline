import React, { Component } from "react";
import Header from "../components/HomePage/Header";
import BreadCrumb from "../components/BookDetails/BreadCrumb";
import Book from "../components/BookDetails/Book";
import OrderForm from "../components/Form/OrderForm";
import Footer from "../components/HomePage/Footer";
import callApi from "../utils/apiCaller";
import { API_URL } from "../config";

class OrderBookPage extends Component {
  constructor(props) {
    super(props);
    this.state = {
      book: {},
      address: "",
      qty: 0,
      total: 0
    };
  }

  componentDidMount() {
    const { bookID } = this.props.match.params;
    callApi(API_URL, `books/${bookID}`, "GET", null, null).then(res => {
      this.setState({
        book: res.data.data
      });
    });
  }

  handleChange = event => {
    var name = event.target.name;
    var value = event.target.value;
    this.setState({
      [name]: value
    });
    this.totalPrice();
  };

  handleSubmit = e => {
    e.preventDefault();
    const { address, qty } = this.state;
    const token = localStorage.getItem("token");
    const email = localStorage.getItem("email");
    const { bookID } = this.props.match.params;
    const headers = {
      authorization: `${token}`
    };
    const body = {
      email,
      address,
      books: [
        {
          bookId: bookID,
          qty
        }
      ]
    };
    callApi(API_URL, "books/buy", "POST", headers, body).then(res => {
      alert("Success!");
      window.location.href = `/book/${bookID}`;
    });
  };

  totalPrice = () => {
    const { book, qty } = this.state;
    this.setState({
      total: book.price * qty
    });
  };
  render() {
    const { book, total } = this.state;
    return (
      <div>
        <Header />
        <BreadCrumb />
        <Book book={book} />
        <section className="static about-sec">
          <div className="container">
            <h1>Order Details</h1>
            <div className="form">
              <OrderForm
                handleChange={this.handleChange}
                handleSubmit={this.handleSubmit}
                totalPrice={this.totalPrice}
                total={total}
              />
            </div>
          </div>
        </section>
        <Footer />
      </div>
    );
  }
}

export default OrderBookPage;
