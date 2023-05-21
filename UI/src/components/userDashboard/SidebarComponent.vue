<script setup>
import { ref, onMounted, onUnmounted } from 'vue'
import { inject } from 'vue'

const emitter = inject('emitter')
let hidden = ref(false)

onMounted(() => {
  emitter.on('toggle-mobile', (state) => {
    hidden.value = state
    console.log(state)
  })
})
function toggleExtra() {
  if (window.innerWidth < 600) {
    hidden.value = true
    emitter.emit('toggle-extra', hidden)
  }
}
toggleExtra()
window.addEventListener('resize', toggleExtra())
</script>
<template>
  <section class="container" v-if="!hidden">
    <h1 class="main-title">{{ state }}</h1>
    <ul class="action-list">
      <li class="action-card">
        <router-link to="overview" class="action-button subtitle">Overview</router-link>
      </li>
      <li class="action-card">
        <router-link to="/dashboard/grades" class="action-button subtitle">Grades</router-link>
      </li>
      <li class="action-card">
        <router-link to="/dashboard/absence" class="action-button subtitle">Absence</router-link>
      </li>
      <li class="action-card">
        <router-link to="/dashboard/teachers" class="action-button subtitle">Teachers</router-link>
      </li>
    </ul>
  </section>
</template>
<style scoped>
.container {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  gap: 1rem;
  padding: 1rem;

  width: 100%;
  height: 100vh;
  max-width: 15rem;
  min-height: calc(100vh - 7rem);
  background-color: #2a619b;
  color: white;
}
.action-list {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  gap: 1rem;
  position: sticky;
  top: 6.5rem;
  left: 0;
}
.action-button {
  text-align: left;
}
</style>
