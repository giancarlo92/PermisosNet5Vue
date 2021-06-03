<template>
    <v-container fluid fill-height>
        <v-layout align-center justify-center>
			<v-flex xs12 sm8 md4>
				<v-card class="elevation-12">
				<v-toolbar color="primary" dark flat>
					<v-toolbar-title class="text-xs-center display-1"><b>Login</b></v-toolbar-title>
				</v-toolbar>
				<v-card-text>
					<v-form>
					<v-text-field prepend-icon="person"
							v-model="usuarioLogin.username"
							label="Usuario"
							type="text"
							v-on:keyup.enter="getCredenciales"
							v-validate="'required'"
							:error-messages="errors.collect('username')"
							data-vv-name="username"
							required>
					</v-text-field>

					<v-text-field prepend-icon="lock"
							v-model="usuarioLogin.password"
							label="Contraseña"
							type="password"
							v-on:keyup.enter="getCredenciales"
							v-validate="'required'"
							:error-messages="errors.collect('password')"
							data-vv-name="password"
							required>
					</v-text-field>
					</v-form>
				</v-card-text>
				<v-card-actions>
					<v-spacer></v-spacer>
					<v-btn round color="primary" @click="getCredenciales">Ingresar</v-btn>
				</v-card-actions>
				</v-card>
			</v-flex>
        </v-layout>
    </v-container>
</template>

<script>
export default {
  name: 'Login',
  $_veeValidate: {
    validator: 'new'
  },
  data () {
    return {
      usuarioLogin: {
        username: '',
        password: ''
      },
      validacion: {
        custom: {
            username: {
                required: 'Debe ingresar un nombre de usuario.'
            },
            password: {
                required: 'Se requiere un contraseña.'
            }
        }
        },
    }
  },
  props: ['config'],
  mounted () {
	this.$validator.localize('es', this.validacion)
  },
  methods:{
      async getCredenciales(){
		let validar = await this.$validator.validateAll()
        if(validar){
			this.$session.set('login', 'login')
			this.$router.push({ name: 'home' })
        }
      }
    }
}
</script>
