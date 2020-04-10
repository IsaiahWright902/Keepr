<template>
  <div class="col-3">
    <div class="card" style="width: 18rem;">
      <div class="card-body">
        <h5 class="card-title">{{vaultData.name}}</h5>
        <p class="card-text"></p>

        <p>{{vaultData.description}}</p>

        <button class="btn btn-sm btn-danger" @click="deleteVault">Delete</button>
        <router-link :to="{name:'VaultDetails', params:{vaultId: this.vaultData.id}}">
          <button class="btn btn-sm btn-info">Open Vault</button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vault",
  props: ["vaultData"],
  data() {
    return {};
  },
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultData.id);
    }
  },
  computed: {}
};
</script>

<style>
</style>