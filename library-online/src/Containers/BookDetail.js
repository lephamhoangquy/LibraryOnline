import React, { Component } from "react";
import Header from "../components/HomePage/Header";
import BreadCrumb from "../components/BookDetails/BreadCrumb";
import Book from "../components/BookDetails/Book";
import Footer from "../components/HomePage/Footer";
import callApi from "../utils/apiCaller";
import { API_URL } from "../config";

class BookDetail extends Component {
  constructor(props) {
    super(props);
    this.state = {
      book: {}
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
