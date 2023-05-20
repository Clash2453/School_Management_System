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
#table-section {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
