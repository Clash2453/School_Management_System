<script setup>
import Sidebar from '../components/userDashboard/SidebarComponent.vue'
</script>
<template>
  <main class="flex">
    <Sidebar></Sidebar>
    <router-view></router-view>
  </main>
</template>
<style>
.flex {
  flex: 1;
}
#stats {
  width: 100%;
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-wrap: wrap;
  flex-grow: 0;
  gap: 2rem;
  padding: 1rem;
}
#table-section {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
