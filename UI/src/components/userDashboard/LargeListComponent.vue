<template>
  <ul class="list shadow">
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
  /* background: url('/images/form-background.svg') no-repeat; */
  background-color: var(--component-dark-blue);
  background-size: cover;
  background-position: center;
  border-radius: 15px;
  max-width: 50rem;
  max-height: 40rem;
  overflow-y: auto;
}
</style>
