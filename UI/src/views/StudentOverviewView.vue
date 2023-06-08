<script setup>
import OverviewCardComponent from '../components/userDashboard/OverviewCardComponent.vue'
import LineChart from '../components/userDashboard/LineChartComponent.vue'
import axios from 'axios'
import { onMounted, ref } from 'vue'
let chartDataObjects = []
let gradeCardData = ref({})
let absenceCardData = ref({})
let welcomeCardData = ref({})
let gradeDataFetched = ref(false)
const colors = [
  'rgba(255, 99, 132, 1)',
  'rgba(255, 159, 64, 1)',
  'rgba(255, 205, 86, 1)',
  'rgba(75, 192, 192, 1)',
  'rgba(54, 162, 235, 1)',
  'rgba(153, 102, 255, 1)'
]

onMounted(async () => {
  const studentData = await getStudentData()
  const gradeData = await getGradeData()
  // console.log(gradeData)

  absenceCardData.value = {
    mainContent: `Your absence: ${studentData.totalAbsence}`,
    firstArgument: `Excused absence: ${studentData.excusedAbsence}`,
    secondArgument: `Unexcused absence ${studentData.unExcusedAbsence}`,
    displayedValue: studentData.totalAbsence,
    backColor: '#b63e36',
    loaderNeeded: false,
    cardTitle: 'Absence'
  }
  welcomeCardData.value = {
    mainContent: `Your student ID is: ${studentData.studentId}`,
    firstArgument: `Your group number is ${studentData.group}`,
    secondArgument: ``,
    displayedValue: studentData.avgGrade,
    backColor: '#33b864',
    loaderNeeded: false,
    cardTitle: `Welcome ${studentData.name}`
  }
  gradeCardData.value = {
    mainContent: `Average Grade: ${studentData.avgGrade.toFixed(2)}`,
    firstArgument: `Your weakest subject is ${
      studentData.lowestAvgSubject
    }: ${studentData.lowestAvg.toFixed(2)}`,
    secondArgument: `Your strongest subject is ${
      studentData.highestAvgSubject
    }: ${studentData.highestAvg.toFixed(2)}`,
    displayedValue: studentData.avgGrade.toFixed(2),
    backColor: '#33b864',
    loaderNeeded: true,
    cardTitle: 'Your Grades:'
  }
  console.log(studentData)
  const subjects = Object.keys(gradeData)
  for (let i = 0; i < subjects.length; i++) {
    const row = gradeData[subjects[i]]
    const subject = row[0].subject
    const gradeValues = row.map((g) => {
      return g.value
    })
    const gradeDates = row.map((g) => {
      return g.date.split('T')[0]
    })
    console.log(gradeValues)
    chartDataObjects.push({
      labels: gradeDates,
      datasets: [
        {
          label: subject,
          data: gradeValues,
          borderColor: colors[Math.floor(Math.random() * colors.length)]
        }
      ]
    })
  }
  gradeDataFetched.value = true
  // console.log(chartDataObjects)
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
    // console.log(response.data.grades)
    const grades = response.data.grades[0]
    if (grades === undefined) return {}
    const groups = grades.reduce((groups, item) => {
      const group = groups[item.subject] || []
      group.push(item)
      groups[item.subject] = group
      return groups
    }, {})

    return groups
  } catch (e) {
    console.log(e)
  }
}
</script>
<template>
  <div class="flex-container">
    <section id="stats">
      <OverviewCardComponent
        :card-data="welcomeCardData"
        v-if="gradeDataFetched"
      ></OverviewCardComponent>
      <OverviewCardComponent
        :card-data="gradeCardData"
        v-if="gradeDataFetched"
      ></OverviewCardComponent>
      <OverviewCardComponent
        :card-data="absenceCardData"
        v-if="gradeDataFetched"
      ></OverviewCardComponent>
    </section>
    <section id="chart-section" v-if="gradeDataFetched">
      <h1 class="main-title">
        <strong> Your Subjects </strong>
      </h1>
      <LineChart
        class="chart"
        v-for="chartDataObject in chartDataObjects"
        :chartData="chartDataObject"
        :key="chartDataObject.datasets[0].label"
      ></LineChart>
    </section>
  </div>
</template>
<style scoped>
.flex-container {
  min-height: fit-content;
  width: 100%;
  height: 100%;
  flex-grow: 1;
}
#stats,
#chart-section {
  width: 100%;
  display: flex;
  align-items: center;
}
#stats {
  width: 100%;
  gap: 2rem;
  padding: 1rem;
  justify-content: center;
}
#chart-section {
  flex-wrap: wrap;
  height: 100%;
  margin-bottom: 0 auto;
  padding: 1rem;
  /* background-color: #0b2239; */
  justify-content: center;
  align-items: center;
  gap: 2rem;
  color: white;
  text-align: center;
}
@media (max-width: 1200px) {
  #stats {
    flex-direction: column;
  }
}
</style>
