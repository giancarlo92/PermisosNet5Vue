<template>
    <v-app>
        <BarraNavegacion />
        <Menu />
        <Formulario :datamodel="{}" />
        <Footer/>
    </v-app>
</template>

<script>
import Menu from '@/components/Principal/Menu'
import BarraNavegacion from '@/components/Principal/BarraNavegacion'
import Footer from '@/components/Principal/Footer'
import Formulario from '@/components/Permisos/FormPermisos'
import {mapMutations} from 'vuex'
  export default {
    components: {
      Menu,
      BarraNavegacion,
      Formulario,
      Footer
    },
  }
</script>