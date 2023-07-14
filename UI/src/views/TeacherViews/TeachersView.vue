<script setup lang="ts">
import { onMounted, ref } from 'vue'
import OverviewCardComponent from '../../components/userDashboard/OverviewCardComponent.vue'
import StudentList from '../../components/teacherDashboard/StudentListComponent.vue'
import axios from 'axios'
import DoughnutChartComponent from '../../components/userDashboard/DoughnutChartComponent.vue'

const options = ref({
  mainContent: `Your teacher ID is: `,
  firstArgument: ``,
  secondArgument: ``,
  displayedValue: 5,
  backColor: '#33b864',
  loaderNeeded: false,
  cardTitle: `Welcome `
})

const students = ref({})
const subjects = ref([])
onMounted(async () => {
  const teacherData = await fetchTeacherData()
  options.value.mainContent = `Your teacher ID is: ${teacherData.id}`
  options.value.cardTitle = `Welcome ${teacherData.name}`
  students.value = teacherData.students
  subjects.value = Object.keys(students.value)
  console.log(subjects.value)
})
async function fetchTeacherData() {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/teachers`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    console.log(result.data)
    return result.data
  } catch (e) {
    console.log(e)
  }
}
</script>
<template>
  <section class="section-container">
    <div class="grid-item" id="chart-container">
      <DoughnutChartComponent />
    </div>
    <div class="grid-item" id="welcome-container">
      <OverviewCardComponent :card-data="options" />
    </div>
    <div class="grid-item" id="list-container">
      <StudentList :students="students" :subjects="subjects" />
    </div>
  </section>
</template>
<style scoped>
.section-container {
  width: 100%;

  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-rows: 15rem 1fr 1fr;
  padding: 1rem;
  gap: 1rem;
}

#chart-container {
  grid-row: 2/ span 3;
  grid-column: 1;
}

#welcome-container {
  grid-row: 1;
  grid-column: 1;
}

#list-container {
  grid-row: 1 / span 3;
  grid-column: 2;
}

.grid-item {
  width: 100%;
  height: 100%;
}

@media (max-width: 1500px) {
  .section-container {
    grid-template-columns: 1fr;
    grid-template-rows: 17rem minmax(20rem, 1fr) 1fr;
  }

  #chart-container {
    grid-row: 2;
    grid-column: 1;
  }

  #welcome-container {
    grid-row: 1;
    grid-column: 1;
  }

  #list-container {
    grid-row: 3;
    grid-column: 1;
  }
}

@media (max-width: 650px) {
  .section-container {
    display: inline-grid;
    grid-template-columns: 1fr;
    grid-template-rows: repeat(3, minmax(0, 1fr))
  }
}
</style>
