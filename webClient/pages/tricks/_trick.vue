<template>
    <div class="d-flex justify-center align-start">
        <div class="mx-2" v-if="submissions">
            <div v v-for="x in 20" :key="x.Id">
                <div v-for="s in submissions" :key="s.Id">
                    {{s.id}} - {{s.description}} - {{s.trickId}}
                    <div>
                    <video width="400" controls :src="`http://localhost:5000/api/videos/${s.video}`"></video>
                    </div>
                </div>
            </div>
        </div>

        <div class="mx-2 sticky">
            Trick: {{$route.params.trick}}
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