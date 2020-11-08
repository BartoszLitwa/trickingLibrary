<template>
  <v-app dark>
    <v-app-bar app>
      <v-toolbar-title>Tricking Library</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn depressed @click="toggleActivity">
        Upload
      </v-btn>

    </v-app-bar>

    <video-upload/>

    <v-main>
        <nuxt />
    </v-main>
  </v-app>
</template>

<script>
import VideoUpload from '../components/video-upload.vue'
import {mapMutations} from 'vuex'

export default {
  components: {
    VideoUpload,
  },
  methods: mapMutations('video-upload', ['toggleActivity']),
}
</script>
