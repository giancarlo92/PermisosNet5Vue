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

    /////////EMPRESA/////////
    {
      path: '/empresa/permisos',
      name: 'Permisos',
      component: () => import(/* webpackChunkName: "permisos" */ '@/views/Empresa/Permisos.vue'),
      meta: { requiresAuth: true }
    },
    {
      path: '/empresa/tipo-permisos',
      name: 'TipoPermisos',
      component: () => import(/* webpackChunkName: "tipo-permisos" */ '@/views/Empresa/TipoPermisos.vue'),
      meta: { requiresAuth: true }
    },
    /////////EMPRESA////////

    /////////PERMISOS/////////
    {
      path: '/empresa/permisos/insert',
      name: 'InsertP',
      component: () => import(/* webpackChunkName: "insert" */ '@/views/Permisos/Insert.vue'),
      meta: { requiresAuth: true }
    },
    {
      path: '/empresa/permisos/edit/:id',
      name: 'EditP',
      component: () => import(/* webpackChunkName: "edit" */ '@/views/Permisos/Edit.vue'),
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