import React, { Component } from "react";
import Header from "../components/HomePage/Header";
import SlideBar from "../components/HomePage/SlideBar";
import ListBook from "../components/HomePage/ListBook";
import About from "../components/HomePage/About";
import Footer from "../components/HomePage/Footer";
import callApi from "../utils/apiCaller";
import _ from "lodash";
import { API_URL } from "../config";

class HomePage extends Component {
  constructor(props) {
    super(props);
    this.state = { books: [] };
  }

  componentDidMount() {
    callApi(API_URL, "books", "GET", null, null).then(res => {
      this.setState({
        books: res.data.data
      });
    });
  }

  render() {
    var { books } = this.state;
    books = _.slice(books, 0, 8);
    const title = "Recommend Book";
    return (
      <div>
        <Header />
        <SlideBar />
        <ListBook books={books} title={title} />
        <About />
        <Footer />
      </div>
    );
  }
}

export default HomePage;
