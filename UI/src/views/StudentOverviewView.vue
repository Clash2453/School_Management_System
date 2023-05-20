<script setup>
import OverviewCardComponent from '../components/userDashboard/OverviewCardComponent.vue'
import BarChart from '../components/userDashboard/BarChartComponent.vue'
import GlobalStats from '../components/userDashboard/GlobalStatsCardComponent.vue'
import axios from 'axios'
let state = 'Overview'

const averageGrade = 'Average Grade: 5.35'
const lowestGrade = 'Lowest Grade: 5.35'
const highestGrade = 'Highest Grade: 5.35'
const yourAbsence = 'Total absence: 5.35'
const lowestAbsence = 'Lowest absence: 5.35'
const highestAbsence = 'Highest absence: 5.35'
</script>
<template>
  <section id="stats">
    <OverviewCardComponent
      :mainContent="averageGrade"
      :firstArgument="lowestGrade"
      :secondArgument="highestGrade"
    ></OverviewCardComponent>
    <GlobalStats></GlobalStats>
    <OverviewCardComponent
      :mainContent="yourAbsence"
      :firstArgument="lowestAbsence"
      :secondArgument="highestAbsence"
    ></OverviewCardComponent>
  </section>
  <section id="table-section"></section>
</template>
<style scoped>
#stats {
  width: 100%;
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-wrap: wrap;
  flex-grow: 0;
  gap: 2rem;
  padding: 1rem;
}
</style>
