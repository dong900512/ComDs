import * as http from 'superagent'
import { baseUrl } from './url'
const url = baseUrl + "/api/user"
const user = {
    login: (user) => http.post(url).send(user),
}
export { user }