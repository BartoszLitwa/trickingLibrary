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
          <v-text-field v-model="form.name" label="Name"></v-text-field>
          <v-text-field v-model="form.description" label="Description"></v-text-field>
          <v-select v-model="form.difficulty" :items="difficultyItems" label="Difficulty"></v-select>
          <v-select v-model="form.prerequisites" :items="trickItems" chips
                    deletable-chips label="Prerequisites" multiple small-chips></v-select>
          <v-select v-model="form.progressions" :items="trickItems" chips
                    deletable-chips label="Progressions" multiple small-chips></v-select>
          <v-select v-model="form.categories" :items="categoryItems" chips
                    deletable-chips label="Categories" multiple small-chips></v-select>
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
import {mapActions, mapGetters, mapMutations, mapState} from 'vuex';

const initState = () => ({
  step: 1,
  form: {
    name: "",
    description: "",
    difficulty: "",
    prerequisites: [],
    progressions: [],
    categories: [],
  },
  testData: [
    {text: "foo", value: 1},
    {text: "bar", value: 2},
    {text: "zoo", value: 3},
  ]
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
    ...mapGetters('tricks', ['trickItems', 'categoryItems', 'difficultyItems']),
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
