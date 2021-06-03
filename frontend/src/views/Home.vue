<template>
    <v-app>
        <BarraNavegacion />
        <Menu />
        <Dashboard />
        <Footer/>
    </v-app>
</template>

<script>
    import Dashboard from '@/components/Principal/Dashboard'
    import Menu from '@/components/Principal/Menu'
    import BarraNavegacion from '@/components/Principal/BarraNavegacion'
    import Footer from '@/components/Principal/Footer'
    import {mapMutations} from 'vuex'

  export default {
        name: 'Home',
        components: {
            Menu,
            BarraNavegacion,
            Dashboard,
            Footer
        },
        methods:{
            ...mapMutations(['mostrarNotificacion']),
        },
    }
</script>