<template>
  <div class="create-vault">
    <form @submit.prevent="createVault">
      <input type="text" name="name" placeholder="Name..." v-model="newVault.name" required />
      <input
        type="text"
        name="description"
        placeholder="Description..."
        v-model="newVault.Description"
        required
      />
      <button type="submit" class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "CreateVault",
  data() {
    return {
      newVault: {
        title: "",
        descripton: ""
      }
    };
  },
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.newVault);
      this.newKeep = { title: "", description: "" };
      this.form = false;
    }
  }
};
</script>

<style></style>
