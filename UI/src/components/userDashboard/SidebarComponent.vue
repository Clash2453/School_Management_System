<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { inject } from 'vue'
import { useUserStore } from '../../stores/UserStore'

const emitter = inject('emitter')
const hidden = ref(false)
const store = useUserStore()
const dynamicLinks = {
  Admin: [
    {
      path: '/dashboard/teacher/overview',
      icon: 'hi-solid-chart-pie',
      text: 'Overview'
    },
    {
      path: '/dashboard/student/subjects',
      icon: 'bi-calendar2-week',
      text: 'Subjects'
    },
    {
      path: '/dashboard/settings',
      icon: 'fa-cog',
      text: 'Settings'
    }
  ],
  Teacher: [
    {
      path: '/dashboard/student/overview',
      icon: 'hi-solid-chart-pie',
      text: 'Overview'
    },
    {
      path: '/dashboard/student/absence',
      icon: 'md-stickynote2-outlined',
      text: 'Absence'
    },
    {
      path: '/dashboard/settings',
      icon: 'fa-cog',
      text: 'Settings'
    }
  ],
  Student: [
    {
      path: '/dashboard/student/overview',
      icon: 'hi-solid-chart-pie',
      text: 'Overview'
    },
    {
      path: '/dashboard/student/grades',
      icon: 'bi-table',
      text: 'Grades'
    },
    {
      path: '/dashboard/student/teachers ',
      icon: 'fa-chalkboard-teacher',
      text: 'Teachers'
    },
    {
      path: '/dashboard/settings',
      icon: 'fa-cog',
      text: 'Settings'
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
  background-color: var(--primary-color);
  color: var(--font-color-primary);
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
  background-color: var(--accent-color);
}
.action-button {
  text-align: left;
  width: 100%;
  display: block;
  padding: 0.5rem;
}
</style>
