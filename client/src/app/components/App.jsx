import React from "react";
import PropTypes from "prop-types";
import { Route, Redirect, Switch, withRouter } from "react-router-dom";
import { connect } from "react-redux";
import Home from "./Home/Home";
import BoardContainer from "./Board/BoardContainer";
import LandingPage from "./LandingPage/LandingPage";
import "./App.scss";

const App = () => {
  // Serve different pages depending on if user is logged in or not
    return (
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/b/:boardId" component={BoardContainer} />
        <Redirect to="/" />
      </Switch>
    );
};

// Use withRouter to prevent strange glitch where other components
// lower down in the component tree wouldn't update from URL changes
export default withRouter(App);
