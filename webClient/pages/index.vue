<template>
  <div>
    <v-file-input accept="video/*" @change="handleFile">

    </v-file-input>

    <div v-if="tricks">
      <p v-for="trick in tricks" :key="trick.name">
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
  </div>
</template>

<script>
import Axios from 'axios'
import {mapState, mapActions, mapMutations} from 'vuex'

export default {
  components: {
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
    },
    async handleFile(file) {
      if(!file) return;

      const form = new FormData();
      form.append("video", file);

      const result = await Axios.post("http://localhost:5000/api/videos", form);
      console.log("Result: ", result);
    }
  },
}
</script>
