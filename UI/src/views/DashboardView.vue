<script setup>
import Sidebar from '../components/userDashboard/SidebarComponent.vue'
import OverviewCardComponent from '../components/userDashboard/OverviewCardComponent.vue'
let state = 'Overview'
</script>
<template>
  <main class="flex">
    <Sidebar :state="state"></Sidebar>
    <section class="stats">
      <OverviewCardComponent></OverviewCardComponent>
      <OverviewCardComponent></OverviewCardComponent>
      <OverviewCardComponent></OverviewCardComponent>
    </section>
    <section></section>
  </main>
</template>
<style>
.stats {
  width: 100%;
  height: 100%;
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  grid-template-rows: repeat(3, 1fr);
  gap: 2rem;
  padding: 1rem;
}
</style>
