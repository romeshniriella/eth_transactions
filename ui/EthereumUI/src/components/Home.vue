<template>
  <div class="home">
    <h4>{{ msg }}</h4>
    <form class="mui-form--inline">
      <div class="mui-textfield mui-textfield--float-label">
        <input type="text" /> // bind to these inputs - props
        <label>Block Number</label>
      </div>
      <div class="mui-textfield mui-textfield--float-label"> 
        <input type="text" value /> // bind to these inputs - props
        <label>Address e.g: 0xffffffffffffffffffffffffffffff</label>
      </div>
      <button class="mui-btn">submit</button> // click this button - event handler
    </form>
    <br/>
    <Transactions />
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
  @Prop() private msg!: string;
  // submit event handler
  // props to bind to search inputs
  // method to get data from server
  // logic to put data in transactions component
  //    Transactions component -> render data when I pass in data
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
