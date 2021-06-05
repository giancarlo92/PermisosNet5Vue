<template>
  <v-container v-bind:style="{ backgroundColor: '#E3F2FD'}" fluid grid-list-md>
        <v-layout row wrap>
            <v-flex :class="{'pr-0': $vuetify.breakpoint.smAndDown, 'pr-3': $vuetify.breakpoint.mdAndUp}" xs12 sm12>
            <div>
                <v-toolbar flat color="white">
                <v-toolbar-title>Permisos</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-text-field
                    v-model="search"
                    append-icon="search"
                    label="Buscar"
                    single-line
                    hide-details
                    ></v-text-field>
                <v-spacer></v-spacer>
                <v-btn color="success" dark class="mb-2" @click="$router.push('/empresa/permisos/insert')">Nuevo Permiso</v-btn>
                </v-toolbar>

                <v-data-table
                :headers="headers"
                :items="listaPermisos"
                :search="search"
                item-key="nombreEmpleado"
                class="elevation-1"
                >
                <template slot="items" slot-scope="props">
                    
                    <td>{{ props.item.nombreEmpleado}}</td>
                    <td>{{ props.item.apellidosEmpleado}}</td>
                    <td>{{ props.item.tipoPermiso.descripcion}}</td>
                    <td>{{ formatDate(props.item.fechaPermiso)}}</td>
                    <td class="align-center justify-center layout px-0">
                    <v-icon
                        medium
                        @click="$router.push(`/empresa/permisos/edit/${props.item.id}`)"
                    >
                        edit
                    </v-icon>
                    <v-icon
                        medium
                        @click="deleteItem(props.item)"
                    >
                        delete
                    </v-icon>
                    </td>
                    
                </template>
                <template v-slot:no-data>
                    <v-btn color="primary" @click="ListarPermisos">Buscar Nuevamente</v-btn>
                </template>
                </v-data-table>
            </div>
            </v-flex>
        </v-layout>
  </v-container>
</template>

<script>
import axios from 'axios'
import { mapState, mapMutations} from 'vuex'
var moment = require('moment')

  export default {
    data: () => ({
      search: '', 
      listaPermisos:[],
      ReglasRol: [
        v => !!v || "Este campo es necesario"
      ], 
      headers: [
        {
          text: 'Nombres',
          align: 'left',
          sortable: false,
          value: 'nombreEmpleado'
        },
        {
          text: 'Apellidos',
          align: 'left',
          sortable: false,
          value: 'apellidosEmpleado'
        },
        {
          text: 'Tipo de Permiso',
          align: 'left',
          sortable: false,
          value: 'tipoPermiso'
        },
        {
          text: 'Fecha de Permiso',
          align: 'left',
          sortable: false,
          value: 'fechaPermiso'
        },
        { 
            text: 'Opciones',
            sortable: false,
            align: 'center', 
            value: 'IdRol', 
        }  
      ]
    }),

    created () {
      this.ListarPermisos()
    },

    methods: {
      ...mapMutations(['mostrarLoading', 'ocultarLoading']),
      formatDate(date) {
        return moment(new Date(date)).format("DD/MM/YYYY")
      },
      async deleteItem (item) {
        this.editedIndex = this.listaPermisos.indexOf(item)
        let alerta = await this.$swal({
              title: `Are you sure to delete the record?`,
              text: `${item.nombreEmpleado}`,
              type: 'warning',
              showCancelButton: true,
              confirmButtonColor: '#3085d6',
              cancelButtonColor: '#d33',
              confirmButtonText: 'Yes',
              cancelButtonText: 'Cancel'
          })
          if(alerta.value){
            await this.DeletePermiso(item.id)
            await this.ListarPermisos()
          }
      },
      async DeletePermiso(PermisoId){
        this.mostrarLoading({titulo: 'Accediendo a la información', color: 'secondary'})
        try {
            let permiso = await axios.delete(`${this.$urlApi}Permiso/${PermisoId}`, {
                headers: { 
                    'Content-Type': 'application/json', 
                }
            })
            console.log(permiso.data)
        } catch (error) {
            console.log(error.message)
        } finally{
            this.ocultarLoading()
        }
      },
      async ListarPermisos(){
        this.mostrarLoading({titulo: 'Accediendo a la información', color: 'secondary'})
        try {
            let permiso = await axios.get(`${this.$urlApi}Permiso`, {
                headers: { 
                    'Content-Type': 'application/json',
                }
            })
            this.listaPermisos = permiso.data
        } catch (error) {
            console.log(error.message)
        }finally{
            this.ocultarLoading()
        }
      }
    }
  }
</script>

