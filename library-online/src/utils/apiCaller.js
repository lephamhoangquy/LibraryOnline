import axios from "axios";
import { API_URL } from "../config";

export default function callApi(endPoint, method, body) {
  return axios({
    method: method,
    url: `${API_URL}/${endPoint}`,
    data: body
  }).catch(err => console.log(err));
}
