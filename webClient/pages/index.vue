<template>
  <div>
    <div v-if="tricks">
      <div v-for="trick in tricks" :key="trick">
        <div>
        {{trick.name}}
          <video width="400" controls :src="`http://localhost:5000/api/videos/${trick.video}`"></video>
        </div>
      </div>
    </div>

    <v-stepper v-model="step">
      <v-stepper-header>
        <v-stepper-step
          :complete="step > 1"
          step="1"
        >
          Upload Video
        </v-stepper-step>
  
        <v-divider></v-divider>
  
        <v-stepper-step
          :complete="step > 2"
          step="2"
        >
          Trick Information
        </v-stepper-step>
  
        <v-divider></v-divider>
  
        <v-stepper-step step="3">
          Confirmation
        </v-stepper-step>
      </v-stepper-header>
  
      <v-stepper-items>
        <v-stepper-content step="1">
          <v-card
            class="mb-12"
            color="grey lighten-1"
            height="200px"
          >
              <v-file-input accept="video/*" @change="handleFile"/>
          </v-card>
  
          <v-btn
            color="primary"
            @click="step = 2"
          >
            Continue
          </v-btn>
        </v-stepper-content>
  
        <v-stepper-content step="2">
          <v-card
            class="mb-12"
            color="grey lighten-1"
            height="200px"
          >
          <div>
            <v-text-field label="Tricking Name" v-model="trickName"></v-text-field>
            <v-btn @click="saveTrick">Save Trick</v-btn>
          </div>
          </v-card>
  
          <v-btn
            color="primary"
            @click="step = 3"
          >
            Continue
          </v-btn>
        </v-stepper-content>
  
        <v-stepper-content step="3">
          <v-card
            class="mb-12"
            color="grey lighten-1"
            height="200px"
          >
          <div>Success</div>
          </v-card>
  
          <v-btn
            color="primary"
            @click="step = 1"
          >
            Continue
          </v-btn>
        </v-stepper-content>
      </v-stepper-items>
    </v-stepper>
  </div>
</template>

<script>
import {mapState, mapActions, mapMutations} from 'vuex'

export default {
  components: {
  },
  data: () => ({
    trickName: "",
    step: 1,
  }),
  computed: {
      ...mapState('tricks', ['tricks']),
      ...mapState('videos', ['uploadPromise']),
    },
    methods: {
    ...mapMutations('videos', {
      resetVideos: 'reset'
    }),
    ...mapActions('tricks', ['createTrick']),
    ...mapActions('videos', ['startVideoUpload']),

    async handleFile(file) {
        if (!file) return;

        const form = new FormData();
        form.append("video", file)
        this.startVideoUpload({form});
        this.step++;
      },

    async saveTrick() {
      if(!this.uploadPromise) {
        console.log("Upload Promise is null");
        return;
      }

      const video = await this.uploadPromise;
      await this.createTrick({trick: {name: this.trickName, video}});
      this.trickName = "";
      this.step++;
      this.resetVideos();
    },
  }
}
</script>
