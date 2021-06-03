<template>
  <v-app>
    <v-content>
      <!-- NOTIFICACION -->
      <Notificacion />

      <!-- LOADING -->
      <Loading />

      <router-view/>
    </v-content>
  </v-app>
</template>

<script>
import Loading from '@/components/Comunes/Loading'
import Notificacion from '@/components/Comunes/Notificacion'

export default {
	name: 'App',
	components: {
		Loading,
		Notificacion,
	},
}
</script>
