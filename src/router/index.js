import Vue from 'vue'
import Router from 'vue-router'
import store from '@/vuex/store'
import index from '@/components/index'
import groupDetail from '@/components/groupDetail'
import school from '@/components/school'
import person from '@/components/person'
import error from '@/components/error'
import login from '@/components/login'
Vue.use(Router)

export default new Router({
    routes: [{
            path: '/',
            name: 'index',
            component: index,
        }, {
            path: '/groupDetail/:id',
            name: 'groupDetail',
            component: groupDetail
        }, {
            path: '/school',
            name: 'school',
            component: school,
            beforeEnter: (to, from, next) => {
                let user = store.state.user.userInfo
                let path = to.path
                if (user)
                    next()
                else
                    next({ name: 'login', params: { path: path } })
            }
        }, {
            path: '/person',
            name: 'person',
            component: person
        }, {
            path: '/login',
            name: 'login',
            component: login
        },
        {
            path: '*',
            component: error
        }
    ]
})