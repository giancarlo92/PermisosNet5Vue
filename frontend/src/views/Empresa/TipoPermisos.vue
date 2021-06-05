<template>
    <v-app>
        <BarraNavegacion />
        <Menu />
        <DataTipoPermisos />
        <Footer/>
    </v-app>
</template>

<script>
import Menu from '@/components/Principal/Menu'
import BarraNavegacion from '@/components/Principal/BarraNavegacion'
import Footer from '@/components/Principal/Footer'
import DataTipoPermisos from '@/components/TipoPermisos/DataTipoPermisos'
  export default {
    components: {
      Menu,
      BarraNavegacion,
      DataTipoPermisos,
      Footer
    },
  }
</script>