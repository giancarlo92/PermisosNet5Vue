import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    /////////PRINCIPAL/////////
    {
      path: '/',
      name: 'home',
      component: () => import(/* webpackChunkName: "home" */ '@/views/Home.vue'),
      meta: { requiresAuth: true }
    },
    {
      path: '/iniciar-sesion',
      name: 'login',
      component: () => import(/* webpackChunkName: "login" */ '@/views/Login.vue')
    },
    /////////PRINCIPAL/////////

    /////////PERMISOS/////////
    {
      path: '/permisos/insert',
      name: 'InsertP',
      component: () => import(/* webpackChunkName: "insert" */ '@/views/Permisos/Insert.vue'),
      meta: { requiresAuth: true }
    },
    {
      path: '/permisos/edit',
      name: 'EditP',
      component: () => import(/* webpackChunkName: "edit" */ '@/views/Permisos/Edit.vue'),
      meta: { requiresAuth: true }
    },
    /////////PERMISOS////////

    /////////TIPO PERMISOS/////////
    {
      path: '/tipo-permisos/insert',
      name: 'InsertT',
      component: () => import(/* webpackChunkName: "insert" */ '@/views/TipoPermisos/Insert.vue'),
      meta: { requiresAuth: true }
    },
    {
      path: '/tipo-permisos/edit',
      name: 'EditT',
      component: () => import(/* webpackChunkName: "edit" */ '@/views/TipoPermisos/Edit.vue'),
      meta: { requiresAuth: true }
    },
    /////////PERMISOS////////
  ]
})

router.beforeEach((to, from, next) => {
    const authorize = to.matched.some(record => record.meta.requiresAuth)
    if( !Vue.prototype.$session.exists() && authorize){
        next({name: 'login'})
    }
    else {
        next()
    }
})


export default router