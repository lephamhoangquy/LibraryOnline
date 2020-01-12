import { combineReducers } from "redux";
import { reducer as formReducer } from "redux-form";

const appReducers = combineReducers({
  form: formReducer
});

export default appReducers;
