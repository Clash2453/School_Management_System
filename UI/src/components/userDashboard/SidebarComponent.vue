<script setup>
import { ref, onMounted } from 'vue'
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
      <li class="action-button">
        <router-link to="overview" class="action-button action-card subtitle">Overview</router-link>
      </li>
      <li class="action-button">
        <router-link to="/dashboard/student/grades" class="action-card action-button subtitle"
          >Grades</router-link
        >
      </li>
      <li class="action-button">
        <router-link to="/dashboard/absence" class="action-card action-button subtitle"
          >Absence</router-link
        >
      </li>
      <li class="action-button">
        <router-link to="/dashboard/teachers" class="action-card action-button subtitle"
          >Teachers</router-link
        >
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
  min-width: 15rem;
  flex-grow: 1;
  min-height: calc(100vh - 7rem);
  background-color: #062d55;
  color: white;
}
.action-list {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  gap: 1rem;
  width: 100%;
  position: sticky;
  top: 6.5rem;
  left: 0;
}
.action-button:hover {
  background-color: #0a4988;
}
.action-button {
  text-align: left;
  width: 100%;
  display: block;
  padding: 0.5rem;
}
</style>
