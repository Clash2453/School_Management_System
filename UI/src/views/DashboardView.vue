<script setup lang="ts">
import Sidebar from '../components/userDashboard/SidebarComponent.vue'
</script>
<template>
  <main class="flex">
    <Sidebar></Sidebar>
    <router-view></router-view>
  </main>
</template>
<style scoped>
.flex {
  flex: 1;
  background-color: var(--background-color);
  background-size: cover;
}
#table-section {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
