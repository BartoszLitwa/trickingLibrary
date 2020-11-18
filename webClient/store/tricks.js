const initState = () => ({
  tricks: [],
  categories: [],
  difficulties: [],
})

export const state = initState

export const getters = {
  trickItems: state => state.tricks.map(x => ({
    text: x.name,
    value: x.id,
  })),
  categoryItems: state => state.categories.map(x => ({
    text: x.name,
    value: x.id,
  })),
  difficultyItems: state => state.difficulties.map(x => ({
    text: x.name,
    value: x.id,
  }))
}

export const mutations = {
  setTricks(state, {tricks, difficulties, categories}) {
    state.tricks = tricks;
    state.difficulties = difficulties;
    state.categories = categories;
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  async fetchTricks({commit}) {
    const tricks = await this.$axios.$get("/api/tricks");
    const categories = await this.$axios.$get("/api/categories");
    const difficulties = await this.$axios.$get("/api/difficulties");
    commit("setTricks", {tricks, difficulties, categories})
  },
  createTrick({state, commit, dispatch}, {form}) {
    return this.$axios.$post("/api/tricks", form);
  }
}
