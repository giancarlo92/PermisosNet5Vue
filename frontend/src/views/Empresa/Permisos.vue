<template>
    <v-app>
        <BarraNavegacion />
        <Menu />
        <DataPermisos />
        <Footer/>
    </v-app>
</template>

<script>
import Menu from '@/components/Principal/Menu'
import BarraNavegacion from '@/components/Principal/BarraNavegacion'
import Footer from '@/components/Principal/Footer'
import DataPermisos from '@/components/Permisos/DataPermisos'
  
  export default {
    components: {
      Menu,
      BarraNavegacion,
      DataPermisos,
      Footer
    },
  }
</script>