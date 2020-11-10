const initState = () => ({
    submissions: []
})

export const state = initState

export const mutations = {
    setSubmissions(state, { submissions }) {
        state.submissions = submissions
    },
    reset(state) {
        Object.assign(state, initState())
    }
}

export const actions = {
    async fetchSubmissionsForTrick({ commit }, { id }) {
        const submissions = await this.$axios.$get(`/api/tricks/${id}/submissions`);
        commit("setSubmissions", { submissions })
    }
}