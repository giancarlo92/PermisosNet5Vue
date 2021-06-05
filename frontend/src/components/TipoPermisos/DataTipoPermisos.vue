<template>
  <v-container v-bind:style="{ backgroundColor: '#E3F2FD'}" fluid grid-list-md>
        <v-layout row wrap>
            <v-flex :class="{'pr-0': $vuetify.breakpoint.smAndDown, 'pr-3': $vuetify.breakpoint.mdAndUp}" xs12 sm12>
            <div>
                <v-toolbar flat color="white">
                <v-toolbar-title>Tipo de Permisos</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-text-field
                    v-model="search"
                    append-icon="search"
                    label="Buscar"
                    single-line
                    hide-details
                    ></v-text-field>
                </v-toolbar>

                <v-data-table
                :headers="headers"
                :items="listTipoPermisos"
                :search="search"
                item-key="descripcion"
                class="elevation-1"
                >
                <template slot="items" slot-scope="props">
                    <td>{{ props.item.descripcion}}</td>
                </template>
                <template v-slot:no-data>
                    <v-btn color="primary" @click="ListarTipoPermisos">Buscar Nuevamente</v-btn>
                </template>
                </v-data-table>
            </div>
            </v-flex>
        </v-layout>
  </v-container>
</template>

<script>
import { mapState, mapMutations, mapActions} from 'vuex'

  export default {
    data: () => ({
      search: '', 
      listaTipoPermisos:[],
      headers: [
        {
          text: 'Descripción',
          align: 'left',
          sortable: false,
          value: 'descripcion'
        } 
      ]
    }),

    created () {
      this.ListarTipoPermisos()
    },
    computed: {
      ...mapState(['listTipoPermisos'])
    },
    methods: {
      ...mapMutations(['mostrarLoading', 'ocultarLoading']),
      ...mapActions(['ListarTipoPermisos'])
    }
  }
</script>

