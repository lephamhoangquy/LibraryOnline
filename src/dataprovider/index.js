import callApi from "../utils/apiCaller";
import _ from "lodash";
import { API_URL } from "../config";

const ConvertToBase64 = file => {
  return new Promise((resolve, reject) => {
    if (file === null) return null;
    var reader = new FileReader();
    reader.readAsDataURL(file.rawFile);
    reader.onload = async e => {
      const picture_base64 = await e.target.result.split(",");
      return resolve(picture_base64[1]);
    };
  });
};

export default {
  getList: (resource, params) => {
    const { page, perPage } = params.pagination;
    const { field, order } = params.sort;
    const query = {
      sort: JSON.stringify([field, order]),
      range: JSON.stringify([(page - 1) * perPage, page * perPage - 1]),
      filter: JSON.stringify(params.filter)
    };
    const endpoint = `${resource}?${JSON.stringify(query)}`;
    return callApi(API_URL, endpoint, "GET", null, null).then(res => {
      const data = _.get(res.data, "data", []);
      data.forEach(item => {
        item.id = item.bookID;
      });
      return Promise.resolve({
        data,
        total: _.get(res.data, "total", 0)
      });
    });
  },
  getOne: (resource, params) => {
    return callApi(API_URL, resource, "GET", null, null).then(res => {
      const data = _.get(res.data, "data", {});
      _.set(data, "id", data.objectId);
      return Promise.resolve({ data });
    });
  },
  update: async (resource, params) => {
    var body = _.omit(params.data, [
      "id",
      "categoryID",
      "categoryName",
      "createdAt",
      "isDeleted"
    ]);
    let picture = _.get(body, "picture", null);
    const token = localStorage.getItem("token");
    const headers = {
      authorization: `${token}`
    };
    const picture_base64 = await ConvertToBase64(picture);
    _.set(body, "picture", picture_base64);
    return callApi(API_URL, "books", "PUT", headers, body).then(res => {
      return Promise.resolve(res);
    });
  },
  delete: (resource, params) => {
    const token = localStorage.getItem("token");
    const { id } = params;
    const headers = {
      authorization: `${token}`
    };
    return callApi(API_URL, `books/${id}`, "DELETE", headers, null).then(
      res => {
        return Promise.resolve(res);
      }
    );
  },
  create: async (resource, params) => {
    let picture = _.get(params.data, "picture", null);
    const token = localStorage.getItem("token");
    const headers = {
      authorization: `${token}`
    };
    const picture_base64 = await ConvertToBase64(picture);
    _.set(params.data, "picture", picture_base64);
    return callApi(API_URL, "books", "POST", headers, params.data).then(res => {
      var { data } = res.data;
      window.location.href = "/";
      return Promise.resolve({ data: { ...data, id: data.bookID } });
    });
  }
};
