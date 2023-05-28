<script setup>
import OverviewCardComponent from '../components/userDashboard/OverviewCardComponent.vue'
import LineChart from '../components/userDashboard/LineChartComponent.vue'
import GlobalStats from '../components/userDashboard/GlobalStatsCardComponent.vue'
import axios from 'axios'
import { onMounted, ref } from 'vue'

let studentData = {}
let gradeData = {}
let chartData = {}
let gradesFetched = false
let averageGrade = ref('')
let lowestAvgGrade = ref('')
let highestAvgGrade = ref('')
let gradeValue = ref(-1)
let yourAbsence = ref()
let excusedAbsence = ref('')
let unexcusedAbsence = ref('')
let gradeCardColor = '#33b864'
let absenceCardColor = '#b63e36'

onMounted(async () => {
  studentData = await getStudentData()

  gradeData = await getGradeData()
  console.log(gradeData)
  averageGrade.value = `Average Grade: ${studentData.avgGrade}`

  lowestAvgGrade.value = `Lowest Average: ${studentData.lowestAvgSubject}, ${studentData.lowestAvg}`

  highestAvgGrade.value = `Highest Average: ${studentData.highestAvgSubject}, ${studentData.highestAvg}`

  gradeValue.value = studentData.avgGrade

  yourAbsence.value = studentData.totalAbsence

  excusedAbsence.value = `Excused absence: ${studentData.excusedAbsence}`

  unexcusedAbsence.value = `Unexcused absence ${studentData.unExcusedAbsence}`

  console.log(studentData)

  const gradeValues = gradeData.grades.map((g) => {
    return g.value
  })
  const gradeDates = gradeData.grades.map((g) => {
    const dateObject = new Date(g.date)

    const day = dateObject.getDate()
    const month = dateObject.getMonth() + 1
    const year = dateObject.getFullYear()

    return new Date(year, month - 1, day)
  })
  const subjects = [
    ...new Set(
      gradeData.grades.map((g) => {
        return g.subject
      })
    )
  ]
  chartData = {
    labels: subjects,
    datasets: [{ data: gradeValues }]
  }
  gradesFetched = true
})

async function getStudentData() {
  const response = await axios({
    method: 'GET',
    url: `https://localhost:7080/student`,
    headers: {
      'Content-Type': 'application/json'
    },
    withCredentials: true
  }).catch((e) => console.log(e))
  return response.data
}
async function getGradeData() {
  try {
    const response = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Grade/student`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    return response.data
  } catch (e) {
    console.log(e)
  }
}
</script>
<template>
  <div class="flex-container">
    <section id="stats">
      <OverviewCardComponent
        :mainContent="averageGrade"
        :firstArgument="lowestAvgGrade"
        :secondArgument="highestAvgGrade"
        :displayedValue="gradeValue"
        :backColor="gradeCardColor"
        :loaderNeeded="true"
        :cardTitle="'Your Grades:'"
      ></OverviewCardComponent>
      <GlobalStats></GlobalStats>
      <OverviewCardComponent
        :mainContent="`Your absence: ${yourAbsence}`"
        :firstArgument="excusedAbsence"
        :secondArgument="unexcusedAbsence"
        :displayedValue="yourAbsence"
        :backColor="absenceCardColor"
        :loaderNeeded="false"
        :cardTitle="'Absence'"
      ></OverviewCardComponent>
    </section>
    <section id="chart-section">
      <LineChart v-if="gradesFetched" :chartData="chartData"></LineChart>
    </section>
  </div>
</template>
<style scoped>
.flex-container {
  min-height: fit-content;
  width: 100%;
}
#stats,
#chart-section {
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: space-between;
}
#stats {
  width: 100%;
  gap: 2rem;
  padding: 1rem;
}
@media (max-width: 1200px) {
  #stats {
    flex-direction: column;
  }
}
</style>
