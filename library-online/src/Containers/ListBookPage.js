import React, { Component } from "react";
import Header from "../components/HomePage/Header";
import BreadCrumb from "../components/BookDetails/BreadCrumb";
import Footer from "../components/HomePage/Footer";
import ListBook from "../components/HomePage/ListBook";

class ListBookPage extends Component {
  render() {
    return (
      <div>
        <Header />
        <BreadCrumb />
        <ListBook />
        <Footer />
      </div>
    );
  }
}

export default ListBookPage;
