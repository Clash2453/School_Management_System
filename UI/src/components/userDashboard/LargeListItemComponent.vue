<template>
  <li class="list-item" :class="{ expanded: expandTrigger }">
    <div class="header-section">
      <div class="wrapper">
        <h2 class="subtitle">{{ options.firstContent }}</h2>
        <p class="text">{{ options.firstSubContent }}</p>
      </div>
      <div class="wrapper">
        <h2 class="subtitle">{{ options.secondContent }}</h2>
        <p class="text">{{ options.secondSubContent }}</p>
      </div>
      <div class="wrapper">
        <button class="expand-button add-button" @click="expandTrigger = !expandTrigger">Expand</button>
      </div>
    </div>
    <div class="expanded-section" v-if="expandTrigger"></div>
  </li>
</template>
<script setup>
import { ref } from 'vue'
const props = defineProps(['options'])
const expandTrigger = ref(false)
</script>
<style scoped>
.list-item {
  color: white;
  background-color: var(--component-selected-blue);

  width: 100%;
  height: 10em;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: space-between;
  margin-left: 0;
  gap: 1rem;
  padding: 1rem;
  border-radius: 15px;
  box-shadow: rgba(0, 0, 0, 0.05) 0px 0px 0px 1px;
}
.header-section {
  color: white;

  width: 100%;
  display: flex;
  align-items: flex-start;
  justify-content: space-between;
}
.expanded {
  min-height: 15rem;
  align-items: flex-start;
}
.wrapper {
  height: 100%;
  min-height: 3.25rem;
  flex-direction: column;
  display: flex;
  align-items: center;
  justify-content: center; 
}
.expand-button {
  padding: 0.35rem;
  border-radius: 5px;
  font-family: 'Roboto', sans-serif;
}
.text {
  font-family: 'Lato', sans-serif;
  text-align: left;
  width: 100%;
}
</style>
