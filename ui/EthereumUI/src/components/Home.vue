<template>
  <div class="home">
    <h4>Search Etherium Block</h4>
    <form class="mui-form--inline" v-on:submit.prevent="searchBlock">
      <div class="mui-textfield mui-textfield--float-label">
        <input type="text" v-model="blockNumber" /> 
        <label>Block Number e.g:123456</label>
      </div>
      <div class="mui-textfield mui-textfield--float-label"> 
        <input type="text" v-model="address"   /> 
        <label>Address e.g: 0xffffffffffffffffffffffffffffff</label>
      </div>
      <button class="mui-btn"  >submit</button>  
    </form>
    <div v-if="searching">
				<i>Searching...</i>
			</div>
      <div v-if="noResults">
				Sorry, but no results were found.
			</div>
       <div v-if="error">
				An error occured. Please try again.
			</div>
    <br/>
    <Transactions :records=results />
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Transactions from "../components/Transactions.vue";

@Component({
  components: {
    Transactions
  } 
})
export default class Home extends Vue {
  blockNumber = "8754823";
  address = "0xc55eddadeeb47fcde0b3b6f25bd47d745ba7e7fa";

  searching = false;
  noResults = false;
  error = false;
  results=[];

  searchBlock(){
    this.searching = true;
    this.error = false;
    fetch(`https://localhost:44388/api/Transactions/${encodeURIComponent(this.blockNumber)}/${encodeURIComponent(this.address)}`)
			.then(res => res.json())
			.then(res => { 
				this.searching = false;
				this.results = res;
				this.noResults = this.results.length === 0;
      }).catch( err => {
        this.error = true;
        this.searching = false;
      });
  } 
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
