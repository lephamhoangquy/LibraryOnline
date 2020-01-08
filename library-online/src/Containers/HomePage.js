import React, { Component } from "react";
import Header from "../components/HomePage/Header";
import SlideBar from "../components/HomePage/SlideBar";
import ListBook from "../components/HomePage/ListBook";
import About from "../components/HomePage/About";
import Footer from "../components/HomePage/Footer";

class HomePage extends Component {
  render() {
    return (
      <div>
        <Header />
        <SlideBar />
        <ListBook />
        <About />
        <Footer />
      </div>
    );
  }
}

export default HomePage;
