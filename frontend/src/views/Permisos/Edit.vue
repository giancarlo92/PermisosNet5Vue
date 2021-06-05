<template>
    <v-app>
        <BarraNavegacion />
        <Menu />
        <Formulario :datamodel="Permiso" />
        <Footer/>
    </v-app>
</template>

<script>
import Menu from '@/components/Principal/Menu'
import BarraNavegacion from '@/components/Principal/BarraNavegacion'
import Footer from '@/components/Principal/Footer'
import Formulario from '@/components/Permisos/FormPermisos'
import axios from 'axios'
import {mapMutations} from 'vuex'

  export default {
    components: {
      Menu,
      BarraNavegacion,
      Formulario,
      Footer
    },
    created() {
      this.GetPermisoById();
    },
    data() {
      return {
        Permiso: {}
      }
    },
    methods: {
      ...mapMutations(['mostrarLoading', 'ocultarLoading']),
      async GetPermisoById(){
        this.mostrarLoading({titulo: 'Accediendo a la información', color: 'secondary'})
        try {
            let permisoId = this.$route.params.id
            let permiso = await axios.get(`${this.$urlApi}Permiso/${permisoId}`, {
                headers: { 
                    'Content-Type': 'application/json',
                }
            })
            this.Permiso = permiso.data
        } catch (error) {
            console.log(error.message)
        }finally{
            this.ocultarLoading()
        }
      }
    },
  }
</script>