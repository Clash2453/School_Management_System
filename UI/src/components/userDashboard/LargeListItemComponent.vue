<template>
  <li class="list-item" :class="{ expanded: expandTrigger }">
    <div class="header-section">
      <div class="wrapper">
        <h2 class="subtitle">{{ options.firstContent }}</h2>
      </div>
      <div class="wrapper">
        <h2 class="subtitle">{{ options.secondContent }}</h2>
      </div>
      <div class="wrapper">
        <v-icon
          name="bi-arrow-down-circle"
          scale="2"
          fill="white"
          class="icon-button"
          @click="expandTrigger = !expandTrigger"
        ></v-icon>
      </div>
    </div>
    <div class="expanded-section" v-if="expandTrigger">
      <div class="wrapper">
        <h2 class="subtitle">
          <v-icon name="hi-solid-mail-open" scale="1.45" fill="white"></v-icon>
          {{ options.firstField }}
        </h2>
      </div>
      <div class="wrapper">
        <v-icon name="fa-university" scale="1.45" fill="white"></v-icon>
        <h2 class="subtitle">{{ options.secondField }}</h2>
      </div>
      <div class="wrapper" v-if="!(options.thirdField === '')">
        <v-icon name="fa-user-graduate" scale="1.45" fill="white"></v-icon>
        <h2 class="subtitle">{{ options.thirdField }}</h2>
      </div>
    </div>
  </li>
</template>
<script setup lang="ts">
import { ref } from 'vue'
const props = defineProps(['options'])
const expandTrigger = ref(false)
</script>
<style scoped>
.list-item {
  color: white;
  background-color: var(--component-selected-blue);

  width: 100%;
  height: 5;
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
  padding: 0 0.5rem;
}
.expanded {
  min-height: 10rem;
  align-items: flex-start;
}
.wrapper {
  height: 100%;
  width: 100%;
  /* max-width: 5rem; */
  min-height: 3.25rem;
  min-width: fit-content;
  gap: 0.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: left;

}
.text {
  font-family: 'Lato', sans-serif;
  text-align: left;
  width: 100%;
}
.subtitle {
  width: 100%;
  text-overflow: ellipsis;
}
.expanded-section {
  width: 100%;
  display: flex;
  align-items: flex-start;
  justify-content: space-between;
  gap: 2rem;
  background-color: var(--component-light-blue);
  border-radius: 5px;
  padding: 0 0.5rem;
  animation: fade-in 0.5s;
  overflow-x: auto;
}
@keyframes fade-in {
  0% {
    opacity: 0%;
  }
  100% {
    opacity: 100%;
  }
}
.icon-button {
  cursor: pointer;
}
</style>
