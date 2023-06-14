<template>
  <li class="list-item">
    <div class="wrapper">
      <h2 class="subtitle">{{ options.firstContent }}</h2>
      <p class="text">{{ options.firstSubContent }}</p>
    </div>
    <div class="wrapper">
      <h2 class="subtitle">{{ options.secondContent }}</h2>
      <p class="text">{{ options.secondSubContent }}</p>
    </div>
    <div class="wrapper">
      <button class="expand-button">Expand</button>
    </div>
  </li>
</template>
<script setup>
const props = defineProps(['options'])
</script>
<style scoped>
.list-item {
  color: white;
  background-color: #002d53;

  width: 100%;
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 1rem;
  padding: 1rem;
  border-radius: 15px;
}
</style>
