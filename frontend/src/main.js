import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import router from './router'
import store from './store'
import 'roboto-fontface/css/roboto/roboto-fontface.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import axios from 'axios'
import VueSession from 'vue-session'
import VueAxios from 'vue-axios'
import VeeValidate from 'vee-validate'
import VueSweetalert2 from 'vue-sweetalert2'
import json from '../public/config.json'
 
Vue.use(VueSweetalert2)
Vue.use(VueAxios, axios)
Vue.use(VueSession)
Vue.use(VeeValidate)

Vue.config.productionTip = false
Vue.prototype.$urlApi = json.urlApi
Vue.prototype.$urlDocuments = json.urlDocuments
Vue.prototype.$useLogin = json.useLogin
Vue.prototype.$colorMenu = json.colorMenu
Vue.prototype.$colorBarraYFooter = json.colorBarraYFooter

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app')