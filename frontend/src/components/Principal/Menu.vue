<template>
    <v-navigation-drawer
        :value="drawer"
        @input="ocultarMenuInput($event)"
        v-bind:style="{ backgroundColor: $colorMenu}"
        app
    >
        <v-toolbar flat class="transparent">
        <v-list class="pa-0">
            <v-list-tile avatar router @click="redireccionar(subItemHome)">
            <v-list-tile-avatar>
                <img src="@/assets/images/logo.png">
            </v-list-tile-avatar>
            <v-list-tile-content>
                <v-list-tile-title class="white--text">Giancarlo Zevallos</v-list-tile-title>
            </v-list-tile-content>
            </v-list-tile>
        </v-list>
        </v-toolbar>

        <v-list class="pt-0" dense>
            <v-divider></v-divider>
            <v-list-group
                v-for="item in Modulos"
                :key="item.name"
                v-model="item.active"
                no-action
            >
                <template v-slot:activator>
                <v-list-tile> 
                    <v-list-tile-action>
                        <v-img :src="urlActual.split('/')[1] == item.path.toLowerCase() ? 
                                `${require('@/assets/svg/'+ item.icon +'-active.svg')}`:
                                `${require('@/assets/svg/'+ item.icon +'.svg')}`" 
                                max-width="30">
                        </v-img>
                    </v-list-tile-action>
                    <v-list-tile-content>
                        <v-list-tile-title 
                            :class=" urlActual.split('/')[1] == item.path.toLowerCase() ? 'warning--text' : 'white--text'">
                            {{ item.name }}
                        </v-list-tile-title>
                    </v-list-tile-content>
                </v-list-tile>
                </template>

                <v-list-tile
                v-for="subItem in item.submodules"
                :key="subItem.name"
                router @click="redireccionar(subItem)"
                :class=" urlActual == `/${subItem.path}` ? 'warning--text' : 'white--text'"
                >
                <v-list-tile-content>
                    <v-list-tile-title>{{ subItem.name }}</v-list-tile-title>
                </v-list-tile-content>

                </v-list-tile>
            </v-list-group>
        </v-list>
    </v-navigation-drawer>
</template>

<script>
    import { mapState, mapMutations, mapActions } from 'vuex'
    import json from '../../../public/menu.json'
    export default {
        name: 'Menu',
        data () {
            return {
                right: null,
                urlActual: '',
                Modulos: [],
                subItemHome: {
                    path: '',
                }
            }
        },
        methods: {
            ...mapMutations(['ocultarMenu']),
            ...mapActions(['ObtenerMenu']),
            ocultarMenuInput(event){
                if(event != this.drawer){
                    this.ocultarMenu()
                }
            },
            redireccionar(subItem){
                this.$router.push({ path: `/${subItem.path}` })
            }
        },
        computed: {
            ...mapState(['drawer']),
        },
        async created(){
            this.urlActual = this.$router.currentRoute.path != null ? this.$router.currentRoute.path : ''
            this.Modulos = json
        },
    }
</script>