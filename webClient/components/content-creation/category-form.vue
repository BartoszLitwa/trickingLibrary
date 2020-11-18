<template>
  <v-card>
    <v-card-title>Create Category</v-card-title>
    <v-card-text>
      <v-text-field v-model="form.name" label="Name"></v-text-field>
      <v-text-field v-model="form.description" label="Description"></v-text-field>
    </v-card-text>
    <v-card-actions>
      <v-btn @click="save">Save</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
const initState = () => ({
  form: {
    name: "",
    description: "",
  },
})

export default {
  name: "category-form",
  data: initState,
  computed: {
  },
  methods: {
    save() {
      this.$axios.post("/api/categories", this.form);
    }
  }
}
</script>
