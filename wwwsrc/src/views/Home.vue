<template>
  <div class="home">
    <div class="contianer-fluid text-center">
      <div class="row">
        <img src="../assets/keepr.png" />
      </div>
      <button v-if="!keepForm" @click="keepForm = true" class="btn btn-info">Create New Keep</button>
      <button v-else @click="keepForm = false" class="btn btn-danger">Cancel</button>
    </div>
    <div class="col-12">
      <create-keep v-if="keepForm" />
    </div>
    <div class="row">
      <keep v-for="keep in keeps " :key="keep.id" :keepData="keep" />
    </div>
  </div>
</template>

<script>
import keep from "../components/Keeps";
import CreateKeep from "../components/CreateKeep";

export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  data() {
    return {
      keepForm: false
    };
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps;
    },
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    keep,
    CreateKeep
  }
};
</script>
