import axios from "axios";

export default function callApi(URL, endPoint, method, headers, body) {
  return axios({
    method: method,
    url: `${URL}/${endPoint}`,
    headers: headers,
    data: body
  }).catch(err => console.log(err));
}