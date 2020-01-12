import React, { Component } from "react";
import Header from "../components/HomePage/Header";
import BreadCrumb from "../components/BookDetails/BreadCrumb";
import Book from "../components/BookDetails/Book";
import Footer from "../components/HomePage/Footer";

class BookDetail extends Component {
  render() {
    return (
      <div>
        <Header />
        <BreadCrumb />
        <Book />
        <Footer />
      </div>
    );
  }
}

export default BookDetail;
