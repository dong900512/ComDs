import * as types from '../mutations-types'
const state = {
    userInfo: null,
    token: null,
}
if (sessionStorage.getItem("user") != null) {
    state.userInfo = sessionStorage.getItem("user")
    state.token = sessionStorage.getItem("token")
}
const getters = {
    getUserInfo: state => state.userInfo
}
const actions = {
    login({ commit }, userinfo) {
        commit(types.LOGIN, userinfo)
    },
    loginOut({ commit }) {
        commit(types.LOGINOUT)
    }
}
const mutations = {
    [types.LOGIN](state, user) {
        state.userInfo = user.name
        state.token = user.token
        sessionStorage.setItem("user", state.userInfo)
        sessionStorage.setItem("token", state.token)
    },
    [types.LOGINOUT](state) {
        state.userInfo = null
        state.token = null
        sessionStorage.clear()
    }
}
export default {
    state,
    getters,
    actions,
    mutations
}