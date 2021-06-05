<template>
    <v-form ref="form"
        v-model="valid"
        lazy-validation>
        <v-card>
        <v-card-title>
            <span class="headline">{{ formTitle }}</span>
        </v-card-title>
        <v-card-text>
            <v-container grid-list-md>
            <v-layout wrap>
                <v-flex xs12 md6>
                    <v-text-field 
                        v-model="Permiso.nombreEmpleado" 
                        label="Nombres"
                        required
                        :rules="Reglas">
                    </v-text-field>
                </v-flex>
                <v-flex xs12 md6>
                    <v-text-field 
                        v-model="Permiso.apellidosEmpleado" 
                        label="Apellidos"
                        required
                        :rules="Reglas">
                    </v-text-field>
                </v-flex>
                <v-flex xs12 md6>
                  <v-combobox
                        v-model="TipoPermisoSelected"
                        :items="listTipoPermisos"
                        label="Tipo de Permiso"
                        item-value = "id"
                        item-text = "descripcion"
                        required
                        :rules="ReglasComboBox"
                        chips
                        small-chips
                      >
                  </v-combobox>
                </v-flex>
                <v-flex xs12 md6>
                    <v-menu
                        v-model="menu1"
                        :close-on-content-click="false"
                        :nudge-right="40"
                        lazy
                        transition="scale-transition"
                        offset-y
                        full-width
                        min-width="290px"
                    >
                    <template v-slot:activator="{ on }">
                        <v-text-field
                            v-model="FechaPermisoFormat"
                            label="Fecha de Permiso"
                            readonly
                            v-on="on"
                            required
                            :rules="Reglas"
                        ></v-text-field>
                    </template>
                    <v-date-picker 
                        v-model="Permiso.fechaPermiso" 
                        locale="es"
                        @input="menu1 = false">
                    </v-date-picker>
                    </v-menu>
                </v-flex>  
                
            </v-layout>
            </v-container>
        </v-card-text>

        <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="back">Back</v-btn>
            <v-btn color="blue darken-1" flat @click="save">Save</v-btn>
        </v-card-actions>
        </v-card>
    </v-form>
</template>

<script>
import { mapState, mapMutations, mapActions} from 'vuex'
var moment = require('moment')
import axios from 'axios'

export default {
    data() {
        return {
            valid: true,
            modal: false,
            menu1: null,
            TipoPermisoSelected: '<SELECT>',
            Permiso: {
                id: 0,
                nombreEmpleado: '',
                apellidosEmpleado: '',
                tipoPermisoId: 0,
                fechaPermiso: moment().format('YYYY-MM-DD'),
                createdBy: null,
                createdOn: null,
                updatedBy: null,
                updatedOn: null
            },
            Reglas: [
                v => !!v || "This field is required",
            ], 
            ReglasComboBox: [
                v => v.id > 0 || 'You must select an option other than SELECT'
            ],
        }
    },
    props: {
        datamodel : {
        type : Object,
        default : {}
      }
    },
    created () {
      this.ListarTipoPermisos()
    },
    watch: {
        TipoPermisoSelected(valor){
            if(valor.id != ''){
                this.Permiso.tipoPermisoId = valor.id
            }
        },
        datamodel(valor){
            if(valor.id > 0){
                valor.fechaPermiso = moment(valor.fechaPermiso).format('YYYY-MM-DD')
                this.Permiso = Object.assign({}, valor)
                this.TipoPermisoSelected =  Object.assign({}, valor.tipoPermiso)
            }
        }
    },
    computed: {
        ...mapState(['listTipoPermisos']),
        formTitle () {
            return this.Permiso.id === 0 ? 'Nuevo usuario' : 'Editar usuario'
        },
        FechaPermisoFormat(){
            return moment(this.Permiso.fechaPermiso).format('DD/MM/YYYY')
        },
    },
    methods: {
        ...mapMutations(['mostrarLoading', 'ocultarLoading']),
        ...mapActions(['ListarTipoPermisos']),
        back() {
            this.$router.push({ name: 'Permisos' })
        },
        async save(){
            if (this.$refs.form.validate()) {
                if(this.Permiso.id === 0){
                    this.Permiso.createdBy = 'gzevallos'
                    this.Permiso.createdOn = moment().format('YYYY-MM-DD')
                    await this.AddPermiso()
                } else {
                    this.Permiso.updatedBy = 'gzevallos'
                    this.Permiso.updatedOn = moment().format('YYYY-MM-DD')
                    await this.EditPermiso()
                }
                this.back()
            }
        },
        async AddPermiso(){
            this.mostrarLoading({titulo: 'Accediendo a la información', color: 'secondary'})
            try {
                let permiso = await axios.post(`${this.$urlApi}Permiso`, this.Permiso, {
                    headers: { 
                        'Content-Type': 'application/json', 
                    }
                })
            } catch (error) {
                console.log(error.message)
            } finally{
                this.ocultarLoading()
            }
        },
        async EditPermiso(){
            this.mostrarLoading({titulo: 'Accediendo a la información', color: 'secondary'})
            try {
                let permiso = await axios.put(`${this.$urlApi}Permiso`, this.Permiso, {
                    headers: { 
                        'Content-Type': 'application/json', 
                    }
                })
            } catch (error) {
                console.log(error.message)
            } finally{
                this.ocultarLoading()
            }
        }
    }
}
</script>