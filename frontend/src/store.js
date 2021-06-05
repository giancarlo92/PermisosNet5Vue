import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import router from '@/router'

Vue.use(Vuex)

export default new Vuex.Store({
	state: {
		drawer: true,
		loading: {
			titulo: '',
			estado: false,
			color: 'primary'
		},
		notificacion: {
			color: null,
			snackbar: false,
			mensaje: null
		},
		listTipoPermisos: []
	},
	mutations: {
		mostrarLoading(state, payload) {
			state.loading.titulo = payload.titulo,
				state.loading.color = payload.color,
				state.loading.estado = true
		},
		ocultarLoading(state) {
			state.loading.estado = false
		},
		mostrarNotificacion(state, atributos) {
			// warning
			// error
			// check-circle
			state.notificacion.mensaje = atributos.mensaje
			state.notificacion.color = atributos.color
			state.notificacion.icon = atributos.icon
			state.notificacion.snackbar = true
		},
		destroySession(state, payload) {
			Vue.prototype.$session.destroy()
			router.push({ name: 'login' })
		},
		ocultarMenu(state) {
			state.drawer = !state.drawer
		},
		setearCombo(state, payload) {
			state[payload.nombre] = payload.data
		}
	},
	actions: {
		async ListarTipoPermisos({ commit }){
			try {
				let tipoPermiso = await axios.get(`${Vue.prototype.$urlApi}TipoPermiso`, {
					headers: { 
						'Content-Type': 'application/json',
					}
				})
				commit("setearCombo", { nombre: 'listTipoPermisos', data: tipoPermiso.data })
			} catch (error) {
				console.log(error.message)
			}
		}
	}
})
