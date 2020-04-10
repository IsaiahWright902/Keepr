<template>
  <div class="dashboard">
    <div class="contianer-fluid text-center">
      <div class="row">
        <!-- <h1>WELCOME TO THE DASHBOARD</h1>
        public {{ publicKeeps }} user {{ userKeeps }}-->
      </div>
      <button v-if="!vaultForm" @click="vaultForm = true" class="btn btn-info">Create New Vault</button>
      <button v-else @click="vaultForm = false" class="btn btn-danger">Cancel</button>
    </div>
    <div class="col-12">
      <create-vault v-if="vaultForm" />
    </div>
    <div class="row">
      <vault v-for="vault in vaults " :key="vault.id" :vaultData="vault" />
    </div>
  </div>
</template>

<script>
import vault from "../components/Vaults";
import CreateVault from "../components/CreateVault";
import { onAuth } from "@bcwdev/auth0-vue";
export default {
  async mounted() {
    await onAuth();
    this.$store.dispatch("setBearer", this.$auth.bearer);
    this.$store.dispatch("getVaults");
  },
  data() {
    return {
      vaultForm: false
    };
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  components: {
    vault,
    CreateVault
  }
};
</script>

<style></style>
