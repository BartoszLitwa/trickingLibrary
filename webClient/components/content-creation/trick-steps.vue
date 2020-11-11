<template>
  <v-stepper v-model="step">
    <v-stepper-header>
      <v-stepper-step :complete="step > 1" step="1">Trick Information</v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step step="2">Review</v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>

      <v-stepper-content step="1">
        <div>
          <v-text-field v-model="form.name" label="Tricking Name"></v-text-field>
          <v-btn @click="step++">Next</v-btn>
        </div>
      </v-stepper-content>

      <v-stepper-content step="2">
        <div>
          <v-btn @click="save">Save</v-btn>
        </div>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>
</template>

<script>
import {mapActions, mapMutations, mapState} from 'vuex';

const initState = () => ({
  step: 1,
  form: {
    name: "",
  }
})

export default {
  name: "trick-steps",
  data: initState,
  watch: {
    'activate': function (newVal) {
      if (!newVal) {
        Object.assign(this.$data, initState());
      }
    }
  },
  computed: {
    ...mapState('video-upload', ['active']),
  },
  methods: {
    ...mapMutations('video-upload', ['reset']),
    ...mapActions('tricks', ['createTrick']),
    async save() {
      await this.createTrick({form: this.form});
      this.reset();
      // Reset component state
      Object.assign(this.$data, initState);
    }
  }
}
</script>
