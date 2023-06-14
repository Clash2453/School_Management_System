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
.list {
  display: flex;
  gap: 1rem;
  padding: 1rem;
  background-color: #00499b;
  background: url('/images/form-background.svg') no-repeat;
  background-size: cover;
  background-position: center;
  border-radius: 15px;
  max-width: 50rem;
}
</style>
