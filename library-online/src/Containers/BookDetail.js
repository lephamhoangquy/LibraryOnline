import React, { Component } from "react";
import Header from "../components/HomePage/Header";
import BreadCrumb from "../components/BookDetails/BreadCrumb";
import Book from "../components/BookDetails/Book";
import Footer from "../components/HomePage/Footer";
import callApi from "../utils/apiCaller";

class BookDetail extends Component {
  constructor(props) {
    super(props);
    this.state = {
      book: {}
    };
  }

  componentDidMount() {
    const { id } = this.props.match.params;
    callApi(`books/${id}`, "GET", null).then(res =>
      this.setState({
        book: res.data
      })
    );
  }

  render() {
    const { book } = this.state;
    return (
      <div>
        <Header />
        <BreadCrumb />
        <Book book={book} />
        <Footer />
      </div>
    );
  }
}

export default BookDetail;
