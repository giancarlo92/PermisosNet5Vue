<template>
    <v-footer class="pa-2" v-bind:style="{ backgroundColor: $colorBarraYFooter, color: 'white'}">
        <div >
            <h3>&copy; {{ new Date().getFullYear() }} - Empresa de permisos</h3>
        </div> 
        <v-spacer></v-spacer>
        <div>
            <h3>Versión 2.5.1</h3>
        </div>       
  </v-footer>
</template>

<script>
export default {
    
}
</script>