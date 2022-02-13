import http from "../http-common";
class ShipDataService {
  getAll() {
    return http.get("/ship");
  }
  get(id) {
    return http.get(`/ship/${id}`);
  }
  create(data) {
    return http.post("/ship", data);
  }
  update(id, data) {
    return http.put(`/ship/${id}`, data);
  }
  delete(id) {
    return http.delete(`/ship/${id}`);
  }
}
export default new ShipDataService();