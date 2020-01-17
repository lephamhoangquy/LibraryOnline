import React, { Component } from "react";
import { Admin, Resource } from "react-admin";
import { BookList } from "./containers/BookList";
import { BookEdit } from "./containers/BookEdit";
import { BookCreate } from "./containers/BookCreate";
import BookIcon from "@material-ui/icons/Book";
import dataProvider from "./dataprovider/index";
import authProvider from "./authprovider/index";

class App extends Component {
  render() {
    return (
      <Admin authProvider={authProvider} dataProvider={dataProvider}>
        <Resource
          name="books"
          list={BookList}
          icon={BookIcon}
          edit={BookEdit}
          create={BookCreate}
        />
      </Admin>
    );
  }
}

export default App;
