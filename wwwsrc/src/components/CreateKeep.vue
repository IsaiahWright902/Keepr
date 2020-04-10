<template>
  <div class="create-keep">
    <form @submit.prevent="createKeep">
      <input type="text" name="name" placeholder="Name..." v-model="newKeep.name" required />
      <input
        type="text"
        name="description"
        placeholder="Description..."
        v-model="newKeep.Description"
        required
      />
      <input type="text" name="imgUrl" placeholder="imgUrl..." v-model="newKeep.img" required />
      <button type="submit" class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "CreateKeep",
  data() {
    return {
      newKeep: {
        title: "",
        descripton: "",
        img: ""
      }
    };
  },
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
      this.newKeep = { title: "", description: "" };
      this.form = false;
    }
  }
};
</script>

<style></style>
