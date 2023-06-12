<template>
  <ul class="list">
    <LargeListItemComponent :options="data" />
    <LargeListItemComponent :options="data" />
    <LargeListItemComponent :options="data" />
    <LargeListItemComponent :options="data" />
    <LargeListItemComponent :options="data" />
  </ul>
</template>
<script setup>
import LargeListItemComponent from './LargeListItemComponent.vue'
const data = {
  firstContent: 'FirstContent',
  firstSubContent: 'firstSubContent',
  secondContent: 'secondContent',
  secondSubContent: 'secondSubContent'
}
</script>
<style scoped>

</style>
