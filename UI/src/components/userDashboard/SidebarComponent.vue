<script setup>
import { ref, onMounted } from 'vue'
import { inject } from 'vue'
import { useUserStore } from '../../stores/UserStore.js'

const emitter = inject('emitter')
const hidden = ref(false)
const store = useUserStore()
const dynamicLinks = {
  Admin: [
    {
      path: 'overview',
      icon: 'hi-solid-chart-pie',
      text: 'Overview'
    },
    {
      path: 'subjects',
      icon: 'bi-calendar2-week',
      text: 'Subjects'
    }
  ],
  Teacher: [
    {
      path: 'overview',
      icon: 'hi-solid-chart-pie',
      text: 'Overview'
    },
    {
      path: 'absence',
      icon: 'md-stickynote2-outlined',
      text: 'Absence'
    }
  ],
  Student: [
    {
      path: 'overview',
      icon: 'hi-solid-chart-pie',
      text: 'Overview'
    },
    {
      path: 'grades',
      icon: 'bi-table',
      text: 'Grades'
    },
    {
      path: 'teachers ',
      icon: 'fa-chalkboard-teacher',
      text: 'Teachers'
    }
  ]
}
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
      <li
        v-for="(navLink, index) in dynamicLinks[store.getRole]"
        :key="index"
        class="action-button"
      >
        <router-link :to="navLink.path" class="action-button action-card subtitle">
          <v-icon :name="navLink.icon" scale="1.5" fill="white"></v-icon>
          {{ navLink.text }}</router-link
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
  background-color: var(--dashboard-background-light-blue);
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
  background-color: var(--component-selected-blue);
}
.action-button {
  text-align: left;
  width: 100%;
  display: block;
  padding: 0.5rem;
}
</style>
