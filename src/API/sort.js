import * as http from 'superagent'
import { baseUrl } from './url'
const url = baseUrl + "/api/sort/"
const sort = {
    getSortByGroupID: (id) => {
        return http.get(url + "group/" + id)
    },
    getSortByUserID: () => {
        return http.get(url + "school").set("Authorization", "Bearer " + sessionStorage.getItem("token"))
    },
    produceRandom: (id) => {
        return http.post(url + id).set("Authorization", "Bearer " + sessionStorage.getItem("token"))
    }
}
export { sort }