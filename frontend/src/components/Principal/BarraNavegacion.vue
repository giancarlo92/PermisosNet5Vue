<template >
    <nav>
        <v-toolbar v-bind:style="{ backgroundColor: $colorBarraYFooter}" flat app>
        <v-toolbar-side-icon  @click="ocultarMenu" class="white--text"></v-toolbar-side-icon>
        <v-toolbar-title class="text-uppercase white--text">
            <span class="font-weigth-light">Empresa de permisos</span>
        </v-toolbar-title>
        <v-spacer></v-spacer>
        <v-btn flat color="white" @click="cerrarSesion">
            <span>Logout</span>
            <v-icon right>exit_to_app</v-icon>
        </v-btn>
        </v-toolbar>
    </nav>
</template>

<script>
import { mapMutations } from 'vuex'
    export default {
        name: 'BarraNavegacion',
        methods: {
            ...mapMutations(['ocultarMenu','destroySession']),
            cerrarSesion(){
                this.destroySession()
            }
        },
    }
</script>