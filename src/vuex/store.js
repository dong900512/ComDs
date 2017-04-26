import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)
import * as mutations from './mutations-types'
import * as getters from './getters'
import * as actions from './actions'
import user from './modules/user'
export default new Vuex.Store({
    getters,
    mutations,
    actions,
    modules:{
        user:user,
    }
})