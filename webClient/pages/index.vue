<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
      <div class="text-center">
        <logo />
        <vuetify-logo />
      </div>

      <div v-if="tricks">
        <p v-for="trick in tricks">
          {{trick.name}}
        </p>
      </div>

      <div>
        <v-text-field label="Tricking Name" v-model="trickName"></v-text-field>
        <v-btn @click="saveTrick">Save Trick</v-btn>

      </div>

      {{message}}
      <v-btn @click="reset">Reset Message</v-btn>
      <v-btn @click="resetTricks">Reset Tricks</v-btn>

    </v-col>
  </v-row>
</template>

<script>
import Logo from '~/components/Logo.vue'
import VuetifyLogo from '~/components/VuetifyLogo.vue'
import Axios from 'axios'
import {mapState, mapActions, mapMutations} from 'vuex'

export default {
  components: {
    Logo,
    VuetifyLogo
  },
  data: () => ({
    trickName: ""
  }),
  computed: {
      ...mapState({
        message: state => state.message
      }),
      ...mapState('tricks', {
        tricks: state => state.tricks
      })
    },
    methods: {
    ...mapMutations([
      'reset'
    ]),
    ...mapMutations('tricks', {
      resetTricks: 'reset'
    }),
    ...mapActions('tricks', ['createTrick']),
    async saveTrick() {
      await this.createTrick({trick: {name: this.trickName}});
      this.trickName = ""
    }
  },
  // async fetch() {
  //   await this.$store.dispatch('fetchMessage');
  // },
}
</script>
