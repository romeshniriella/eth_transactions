<template>
    <table class="mui-table mui-table--bordered">
<thead>
    <tr>
      <th>Block Hash</th>
      <th>Block Number</th>
      <th>Gas</th>
      <th>Hash</th>
      <th>From</th>
      <th>To</th>
      <th>Value</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="transaction in records" v-bind:key="transaction.hash">
      <td>{{transaction.blockHash}}</td>
      <td>{{transaction.blockNumberValue}}</td>
      <td>{{transaction.gas}}</td>
      <td>{{transaction.hash}}</td>
      <td>{{transaction.from}}</td>
      <td>{{transaction.to}}</td>
      <td>{{transaction.transactionValue}}</td>
    </tr> 
  </tbody>
    </table>
</template>
<script lang="ts">
  import { Component, Prop, Vue } from 'vue-property-decorator';

  @Component
  export default class Transactions extends Vue { 
      @Prop()
      records = [];
  }
</script>