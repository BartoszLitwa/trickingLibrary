<template>
  <v-stepper v-model="step">
    <v-stepper-header>
      <v-stepper-step :complete="step > 1" step="1">Upload Video</v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step :complete="step > 2" step="2">Select Type</v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step :complete="step > 3" step="3">Submission</v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step step="4">Review</v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>

      <v-stepper-content step="1">
        <div>
          <v-file-input accept="video/*" @change="handleFile"></v-file-input>
        </div>
      </v-stepper-content>

      <v-stepper-content step="2">
        <div>
          <v-select :items="trickItems" v-model="form.trickId" label="Select Trick"></v-select>
          <v-btn @click="step++">Next</v-btn>
        </div>
      </v-stepper-content>


      <v-stepper-content step="3">
        <div>
          <v-text-field v-model="form.description" label="Description"></v-text-field>
          <v-btn @click="step++">Save Submission</v-btn>
        </div>
      </v-stepper-content>

      <v-stepper-content step="4">
        <div>
          <v-btn @click="save">Save</v-btn>
        </div>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>
</template>

<script>
import {mapActions, mapGetters, mapMutations, mapState} from 'vuex';

const initState = () => ({
  step: 1,
  form: {
    trickId: "",
    video: "",
    description: ""
  }
})

export default {
  name: "submission-steps",
  data: initState,
  watch: {
    'activate': function (newVal) {
      if (!newVal) {
        Object.assign(this.$data, initState());
      }
    }
  },
  computed: {
    ...mapGetters('tricks', ['trickItems']),
    ...mapState('video-upload', ['active']),
  },
  methods: {
    ...mapMutations('video-upload', ['hide']),
    ...mapActions('video-upload', ['startVideoUpload', 'createSubmission']),
    async handleFile(file) {
      if (!file) return;

      const form = new FormData();
      form.append("video", file)
      this.startVideoUpload({form});
      this.step++;
    },
    save() {
      this.createSubmission({form: this.form});
      this.hide();
    },
  }
}
</script>
