import HomePage from "../Containers/HomePage";
import BookDetail from "../Containers/BookDetail";
import ListBookPage from "../Containers/ListBookPage";
import Login from "../Containers/Login";
import OrderBookPage from "../Containers/OrderBookPage";

const routes = [
  {
    path: "/",
    exact: true,
    component: HomePage
  },
  {
    path: "/books",
    exact: true,
    component: ListBookPage
  },
  {
    path: "/book/:bookID",
    exact: true,
    component: BookDetail
  },
  {
    path: "/login",
    exact: true,
    component: Login
  },
  {
    path: "/book/buy/:bookID",
    exact: true,
    component: OrderBookPage
  }
];

export default routes;
