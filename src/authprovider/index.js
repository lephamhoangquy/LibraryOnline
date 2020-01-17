import { AUTH_LOGIN, AUTH_LOGOUT, AUTH_ERROR, AUTH_CHECK } from "react-admin";
import callApi from "../utils/apiCaller";
import { AUTH_API_URL, API_URL } from "../config";

export default (type, params) => {
  if (type === AUTH_LOGIN) {
    const { username, password } = params;
    var email = username;
    var passWord = password;
    return callApi(AUTH_API_URL, "authentication", "POST", null, {
      email,
      passWord
    }).then(res => {
      const { token } = res.data.data;
      const headers = {
        authorization: `${token}`
      };
      return callApi(API_URL, "role", "GET", headers, null).then(res => {
        const { permission } = res.data.data;
        if (permission === 2) {
          localStorage.setItem("token", token);
          return Promise.resolve();
        }
      });
    });
  }

  if (type === AUTH_LOGOUT) {
    localStorage.removeItem("token");
    return Promise.resolve();
  }

  if (type === AUTH_ERROR) {
    const { status } = params;
    if (
      status === 401 ||
      status === 403 ||
      status === "F" ||
      status === "NotAuthorized"
    ) {
      localStorage.removeItem("token");
      return Promise.reject();
    }
    return Promise.resolve();
  }

  if (type === AUTH_CHECK) {
    return localStorage.getItem("token") ? Promise.resolve() : Promise.reject();
  }

  return Promise.reject("Unknown method");
};
