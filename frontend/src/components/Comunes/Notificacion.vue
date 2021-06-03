<template>
    <div>
        <v-snackbar
          :color="notificacion.color"
          :bottom="false"
          :top="true"
          :left="false"
          :right="true"
          v-model="notificacion.snackbar"
          dark
        >
          <v-icon
            color="white"
            class="mr-3"
          >
            {{ notificacion.icon }}
          </v-icon>
          <div class="pr-5">{{ notificacion.mensaje }}</div>
          <v-icon
            size="16"
            @click="notificacion.snackbar = false"
          >
            mdi-close-circle
          </v-icon>
        </v-snackbar>
    </div>
</template>

<script>
import { mapState } from 'vuex'
export default {
    name: 'Notificacion',
    computed: {
        ...mapState(['notificacion'])
    },
}
</script>