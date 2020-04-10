<template>
  <div class="vault-details">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12 text-center">
          <h1>Your Vault</h1>
        </div>
      </div>

      <div class="row">
        <keep v-for="keep in keeps " :key="keep.id" :keepData="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/Keeps";
export default {
  name: "VaultDetails",
  props: ["vaultData"],
  data: {
    return: {}
  },
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
  },
  data() {
    return {};
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    keeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {},
  components: {
    keep
  }
};
</script>

<style></style>
