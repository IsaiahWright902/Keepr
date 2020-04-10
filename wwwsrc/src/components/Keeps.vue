<template>
  <div class="col-3">
    <div class="card" style="width: 18rem;">
      <img class="card-img-top" :src="keepData.img" alt="Card image cap" />
      <div class="card-body">
        <h5 class="card-title">{{keepData.name}}</h5>
        <p class="card-text"></p>

        <p>{{keepData.description}}</p>
        <p>{{keepData.keeps}}</p>

        <div class="dropdown show">
          <a
            class="btn btn-sm btn-info dropdown-toggle"
            href="#"
            role="button"
            id="dropdownMenuLink"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >Add To Vault</a>

          <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
            <div>
              <a
                v-for="vault in vaults"
                :key="vault.name"
                class="dropdown-item"
                href="#"
                @click="addToVault(vault.id)"
              >{{vault.name}}</a>
            </div>
          </div>
        </div>
        <button class="btn btn-sm btn-danger" @click="deleteKeep">Delete</button>
      </div>
    </div>
  </div>
</template>

<script>
import vault from "../components/Vaults";
export default {
  name: "keep",
  props: ["keepData", "vaultData"],
  data() {
    return {};
  },
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepData.id);
    },
    addToVault(vaultId) {
      let newVaultKeep = { keepId: this.keepData.id, vaultId: vaultId };
      this.$store.dispatch("addToVault", newVaultKeep);
      this.$store.dispatch("addToKeepCount", this.keepdata.id);
    }
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  componets: {
    vault
  }
};
</script>

<style>
</style>