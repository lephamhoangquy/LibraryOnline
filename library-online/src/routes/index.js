import HomePage from "../Containers/HomePage";
import BookDetail from "../Containers/BookDetail";
import ListBookPage from "../Containers/ListBookPage";
import Login from "../Containers/Login";

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
    path: "/book/:id",
    exact: true,
    component: BookDetail
  },
  {
    path: "/login",
    exact: true,
    component: Login
  }
];

export default routes;
