<script setup lang="ts">
import OverviewCardComponent from '../../components/userDashboard/OverviewCardComponent.vue'
import LineChart from '../../components/userDashboard/LineChartComponent.vue'
import RadarChartComponent from '../../components/userDashboard/RadarChartComponent.vue'
import { onMounted, ref } from 'vue'
import axios from 'axios'

const colors = [
  'rgba(255, 99, 132, 1)',
  'rgba(255, 159, 64, 1)',
  'rgba(255, 205, 86, 1)',
  'rgba(75, 192, 192, 1)',
  'rgba(54, 162, 235, 1)',
  'rgba(153, 102, 255, 1)'
]
const chartDataObjects = ref([])
const gradeCardData = ref()
const absenceCardData = ref()
const welcomeCardData = ref()
const gradeDataFetched = ref()
async function getStudentData() {
  try {
    const response = await axios({
      method: 'GET',
      url: `https://localhost:7080/student`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })

    return response.data
  }
  catch (e) {
    console.log(e)
  }

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
onMounted(async () => {
  const studentData = await getStudentData()
  const gradeData = await getGradeData()
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
    backColor: '#42a0ef',
    loaderNeeded: false,
    cardTitle: `Welcome ${studentData.name}`
  }
  gradeCardData.value = {
    mainContent: `Average Grade: ${studentData.avgGrade.toFixed(2)}`,
    firstArgument: `Your weakest subject is ${studentData.lowestAvgSubject
      }: ${studentData.lowestAvg.toFixed(2)}`,
    secondArgument: `Your strongest subject is ${studentData.highestAvgSubject
      }: ${studentData.highestAvg.toFixed(2)}`,
    displayedValue: studentData.avgGrade.toFixed(2),
    backColor: '#33b864',
    loaderNeeded: true,
    cardTitle: 'Your Grades:'
  }
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
    chartDataObjects.value.push({
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
})
</script>
<template>  
  <div class="flex-container">
    <div class="grid-container">
      <div class="card-container" id="gpi-chart">
        <RadarChartComponent />
      </div>
      <div class="card-container" id="welcome-container">
        <OverviewCardComponent :card-data="welcomeCardData" v-if="gradeDataFetched" />
      </div>
      <div class="card-container" id="grade-container">
        <OverviewCardComponent :card-data="gradeCardData" v-if="gradeDataFetched" />
      </div>
      <div class="card-container" id="absence-container">
        <OverviewCardComponent :card-data="absenceCardData" v-if="gradeDataFetched" />
      </div>
    </div>
    <section id="chart-section" v-if="gradeDataFetched">
      <h1 class="main-title">
        <strong> Your Subjects </strong>
      </h1>
      <LineChart class="chart" v-for="chartDataObject in chartDataObjects" :chartData="chartDataObject"
        :key="chartDataObject.datasets[0].label"></LineChart>
    </section>
  </div>
</template>
<style scoped>
.flex-container {
  min-height: fit-content;
  width: 100%;
  padding: 1rem;
  /* height: 100%; */
  min-height: 100%;
  flex-grow: 1;
}

.card-container {
  width: 90%;
  height: 100%;
  display: flex;
  align-self: center;
  justify-self: center;
}

#gpi-chart {
  grid-column: 1 / span 2;
  grid-row: 1 / span 3;
  justify-self: start;
}

#welcome-container {
  grid-column: 3 / span 4;
  grid-row: 1;
}

#grade-container {
  grid-column: 3 / span 4;
  grid-row: 2;
}

#absence-container {
  grid-column: 3 / span 4;
  grid-row: 3;
}

.grid-container {
  width: 100%;
  display: grid;
  grid-template-rows: 15rem 15rem 15rem;
  grid-template-columns: 1fr 1fr 1fr 1fr;
  gap: 1rem;
  padding: 1rem;
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
  justify-content: space-between;
}

#chart-section {
  flex-wrap: wrap;
  padding: 1rem;
  width: 100%;
  justify-content: flex-start;
  align-items: center;
  gap: 2rem;
  color: var(--component-font-color);
  text-align: center;

}

.subjects-section {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  width: 100%;
  height: 100%;
  padding: 1rem;
}

.main-title {
  text-align: left;
  font-size: 2rem;
}

@media (max-width: 1500px) {
  #stats {
    flex-direction: column;
  }

  .grid-container {
    width: 100%;
    grid-template-rows: 25rem 1fr 1fr 1fr;
    grid-template-columns: 1fr;
  }

  #gpi-chart {
    grid-column: 1;
    grid-row: 1;
    justify-self: center;
  }

  #welcome-container {
    grid-column: 1;
    grid-row: 2;
  }

  #grade-container {
    grid-column: 1;
    grid-row: 3;
  }

  #absence-container {
    grid-column: 1;
    grid-row: 4;
  }
  /* .card-container {
    width: 100%;
  } */
}

@media (max-width: 450px){
  .grid-container {
    width: 100%;
    grid-template-rows: 2fr 2fr 2fr 2fr;
    grid-template-columns: 1fr;
    padding: 0.5rem;
    /* overflow: hidden; */
  }
  .flex-container {
    padding: 0;
  }
  .card-container {
    width: 100%;
  }
}

@media (max-width: 320px){
  .card-container {
    max-width: 305px;
  }
}
</style>
