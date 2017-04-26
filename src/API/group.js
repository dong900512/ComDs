import * as http from 'superagent'
import { baseUrl } from './url'
const url = baseUrl + "/api/group"
const group = {
    get: () => http.get(url)
}
export { group }