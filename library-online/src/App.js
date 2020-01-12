import React, { Component } from "react";
import routes from "./routes/index";
import { Switch, Route, BrowserRouter as Router } from "react-router-dom";

class App extends Component {
  render() {
    return (
      <Router>
        <Switch>
          {routes.length > 0 &&
            routes.map((route, index) => {
              return (
                <Route
                  key={index}
                  path={route.path}
                  exact={route.exact}
                  component={route.component}
                />
              );
            })}
        </Switch>
      </Router>
    );
  }
}

export default App;
