<template>
  <div>
    <div v-if="tricks">
      <div v-for="trick in tricks" :key="trick.name">
        <div>
        {{trick.name}}
          <video width="400" controls :src="`http://localhost:5000/api/videos/${trick.video}`"></video>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
import {mapState} from 'vuex'

export default {
  computed: {
    ...mapState('tricks', ['tricks']),
  },
}
</script>
