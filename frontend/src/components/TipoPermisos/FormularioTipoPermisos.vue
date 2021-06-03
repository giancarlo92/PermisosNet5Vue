<template>
    <v-container class="ma-0 pa-0">
        <v-card>
            <v-card-title>
                <h2>Datos Generales</h2>
            </v-card-title>
            <v-card-text>
                <form>
                    <v-layout row wrap>
                        <v-flex xs12 md3 pr-4>
                            <v-combobox
                                v-model="selectedEstudio"
                                :items="listLawFirm"
                                small-chips
                                label="Estudio Asignado"
                                item-value="id"
                                item-text="description"
                                return-object 
                            ></v-combobox>
                        </v-flex>
                        <v-flex xs12 md3 pr-4>
                            <v-text-field
                                v-model="claim.FileNumber"
                                label="Número de Expediente"
                                type="number"
                            ></v-text-field>
                        </v-flex>
                        <v-flex xs12 sm3 pr-4>
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
                                    v-model="NotifyDateFormat"
                                    label="Fecha Notificación"
                                    prepend-icon="event"
                                    readonly
                                    v-on="on"
                                ></v-text-field>
                            </template>
                            <v-date-picker 
                                locale="es" 
                                v-model="claim.NotifyDate" 
                                @input="menu1 = false"></v-date-picker>
                            </v-menu>
                        </v-flex>
                        <v-flex xs12 sm3 pr-4>
                            <v-menu
                                v-model="menu2"
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
                                    v-model="DueDateFormat"
                                    label="Fecha Vencimiento"
                                    prepend-icon="event"
                                    readonly
                                    v-on="on"
                                ></v-text-field>
                            </template>
                            <v-date-picker 
                                locale="es" 
                                v-model="claim.DueDate" 
                                @input="menu2 = false"></v-date-picker>
                            </v-menu>
                        </v-flex>
                    </v-layout>
                    <v-layout row wrap>
                        <v-flex xs12 sm3 pr-4>
                            <v-menu
                                v-model="menu3"
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
                                    v-model="ReceptionDateFormat"
                                    label="Fecha Recepción"
                                    prepend-icon="event"
                                    readonly
                                    v-on="on"
                                ></v-text-field>
                            </template>
                            <v-date-picker 
                                locale="es" 
                                v-model="claim.ReceptionDate" 
                                @input="menu3 = false"></v-date-picker>
                            </v-menu>
                        </v-flex>
                    </v-layout>
                    <v-layout row wrap>
                        <v-flex xs12 pr-4>
                            <v-textarea
                                v-model="claim.FactsSummary"
                                label="Resumen de los hechos"
                            ></v-textarea>
                        </v-flex>
                    </v-layout>
                </form>
                
            </v-card-text>
            <v-card-actions>
                <v-btn color="primary" @click="GuardarCasoFormulario">Guardar Caso</v-btn>
            </v-card-actions>
        </v-card>
    </v-container>
</template>

<script>
import { mapMutations, mapState, mapActions } from 'vuex'
var moment = require('moment')

export default {
    data() {
        return {
            selectedEstudio: '<SELECCIONAR>',
            claim: {
                IDLawFirm: '',
                IDLawFirm: '',
                FileNumber: '',
                NotifyDate: moment().format('YYYY-MM-DD'),
                DueDate: moment().format('YYYY-MM-DD'),
                IDAgency: '',
                ReceptionDate: moment().format('YYYY-MM-DD'),
                IDCity: '',
                IDProcessType: '',
                IDTypology: '',
                IDDefenceAssessment: '',
                IDLegalPosition: '',
                FactsSummary: '',
                Amount: 0,
                Status: '',
                Validity: false,
            }
        }
    },
    created(){
        this.ListarCombo('listLawFirm')
    },
    computed: {
        ...mapState(['listLawFirm']),
        NotifyDateFormat(){
            return moment(this.claim.NotifyDate).format('DD/MM/YYYY')
        },
        DueDateFormat(){
            return moment(this.claim.DueDate).format('DD/MM/YYYY')
        },
        ReceptionDateFormat(){
            return moment(this.claim.ReceptionDate).format('DD/MM/YYYY')
        }
    },
    watch: {
        selectedEstudio(valor){
            if(valor.id != ''){
                this.claim.IDLawFirm = valor.id
            }
        }
    },
    methods: {
        ...mapActions(['ListarCombo']),
        GuardarCasoFormulario(){
            this.dataModel = {
                Claim: this.claim,
                Claimer: this.claimer,
                IdsDefendants: this.selectedDemandado.map(x => x.id).join('|'),
                Document: this.document,
                IdUser: this.$session.get('token').idUser
            }
            console.log(this.dataModel);
            console.log(this.document.FileName)
        }
    }
}