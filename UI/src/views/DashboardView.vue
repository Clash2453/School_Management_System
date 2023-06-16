<script setup>
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
  /* background-color: #0b2239; */
  /* background: url('/images/dashboard-background.svg') no-repeat; */
  background-color: var(--dashboard-background-blue);
  /* background-image: linear-gradient(to right, #141e30, #243b55); */
  background-size: cover;
}
#table-section {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
