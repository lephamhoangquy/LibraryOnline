import React, { Component } from "react";
import Header from "../components/HomePage/Header";
import BreadCrumb from "../components/BookDetails/BreadCrumb";
import Footer from "../components/HomePage/Footer";
import ListBook from "../components/HomePage/ListBook";
import callApi from "../utils/apiCaller";

class ListBookPage extends Component {
  constructor(props) {
    super(props);
    this.state = { books: [] };
  }

  componentDidMount() {
    callApi("books", "GET", null).then(res => {
      this.setState({
        books: res.data
      });
    });
  }

  render() {
    const { books } = this.state;
    const title = "All Books";
    return (
      <div>
        <Header />
        <BreadCrumb />
        <ListBook books={books} title={title} />
        <Footer />
      </div>
    );
  }
}

export default ListBookPage;
