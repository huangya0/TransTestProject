import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld
    },
    {
        path: '/userinfo1',
        name: 'userinfo1',
        component: () => import('../components/UserInfo.vue')
      }
  ]
})
