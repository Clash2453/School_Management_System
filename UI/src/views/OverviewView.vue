<script setup>
import OverviewCardComponent from '../components/userDashboard/OverviewCardComponent.vue'
import BarChart from '../components/userDashboard/BarChartComponent.vue'
import axios from 'axios'
let state = 'Overview'
async function test() {
  console.log(this.userEmail)
  const data = {
    email: 'wafflepunisher@gmail.com',
    password: 'neli2'
  }
  const token = await axios({
    method: 'PUT',
    withCredentials: true,
    url: 'https://localhost:7080/api/User/update',
    data: data,
    headers: {
      'Content-Type': 'application/json'
    }
  }).catch((e) => console.log(e))
  console.log(token)
}

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
  <section id="stats">
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
  <section id="table-section">
    <button class="main-button" @click="test()">ClickMe</button>
  </section>
</template>
<style></style>
