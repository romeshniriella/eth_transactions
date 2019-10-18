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
    <tr>
      <td>Cell 1-1</td>
      <td>Cell 1-2</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>Cell 2-1</td>
      <td>Cell 2-2</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
  </tbody>
    </table>
</template>
<script lang="ts">
  import { Component, Vue } from 'vue-property-decorator';

  @Component
  export default class Transactions extends Vue {
      
  }
</script>