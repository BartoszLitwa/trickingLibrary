<template>
  <div class="d-flex justify-center align-start">
    <div v-if="submissions" class="mx-2">
      <div v-for="s in submissions" :key="s.Id">
        {{ s.id }} - {{ s.description }} - {{ s.trickId }}
        <div>
          <video :src="`http://localhost:5000/api/videos/${s.video}`" controls width="400"></video>
        </div>
      </div>
    </div>

    <div class="mx-2 sticky">
      Trick: {{ $route.params.trick }}
    </div>
  </div>
</template>

<script>
import {mapState} from 'vuex'

export default {
  computed: {
    ...mapState('submissions', ['submissions'])
  },
  async fetch() {
    const id = this.$route.params.trick;
    await this.$store.dispatch("submissions/fetchSubmissionsForTrick", {id}, {root: true});
  }
}
</script>

<style>
.sticky {
  position: -webkit-sticky;
  position: sticky;
  top: 56px;
}
</style>
