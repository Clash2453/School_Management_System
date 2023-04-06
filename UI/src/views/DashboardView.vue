<script setup>
import Sidebar from '../components/userDashboard/SidebarComponent.vue'
import OverviewCardComponent from '../components/userDashboard/OverviewCardComponent.vue'
let state = 'Overview'
const averageGrade = 'Average Grade: 5.35'
const lowestGrade = 'Lowest Grade: 5.35'
const highestGrade = 'Highest Grade: 5.35'
const allAverage = 'Average Grade: 5.35'
const allLowest = 'Lowest Grade: 5.35'
const allHighest = 'Highest Grade: 5.35'
const yourAbsence = 'Total absence: 5.35'
const lowestAbsence = 'Lowest absence: 5.35'
const highestAbsence = 'Highest absence: 5.35'
</script>
<template>
  <main class="flex">
    <Sidebar :state="state"></Sidebar>
    <section class="stats">
      <OverviewCardComponent
        :mainContent="averageGrade"
        :firstArgument="lowestGrade"
        :secondArgument="highestGrade"
      ></OverviewCardComponent>
      <OverviewCardComponent
        :mainContent="allAverage"
        :firstArgument="allLowest"
        :secondArgument="allHighest"
      ></OverviewCardComponent>
      <OverviewCardComponent
        :mainContent="yourAbsence"
        :firstArgument="lowestAbsence"
        :secondArgument="highestAbsence"
      ></OverviewCardComponent>
    </section>
    <section id="table-section"></section>
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
#table-section {
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
