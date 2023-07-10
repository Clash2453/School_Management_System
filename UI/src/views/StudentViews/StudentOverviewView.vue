<script lang="ts">
import OverviewCardComponent from '../../components/userDashboard/OverviewCardComponent.vue'
import LineChart from '../../components/userDashboard/LineChartComponent.vue'
import { defineComponent } from 'vue'
import axios from 'axios'

const colors = [
  'rgba(255, 99, 132, 1)',
  'rgba(255, 159, 64, 1)',
  'rgba(255, 205, 86, 1)',
  'rgba(75, 192, 192, 1)',
  'rgba(54, 162, 235, 1)',
  'rgba(153, 102, 255, 1)'
]

export default defineComponent({
  async setup() {
    const studentData = await getStudentData()
    const gradeData = await getGradeData()

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

    return {
      studentData,
      gradeData
    }
  },
  props: {
    name: String,
    msg: { type: String, required: true }
  },
  data() {
    return {
      chartDataObjects:  [],
      gradeCardData:  {},
      absenceCardData:  {},
      welcomeCardData:  {},
      gradeDataFetched:  false
    }
  },
  components: {
    OverviewCardComponent,
    LineChart,
  },
  mounted() {
    this.absenceCardData.value = {
      mainContent: `Your absence: ${this.studentData.totalAbsence}`,
      firstArgument: `Excused absence: ${this.studentData.excusedAbsence}`,
      secondArgument: `Unexcused absence ${this.studentData.unExcusedAbsence}`,
      displayedValue: this.studentData.totalAbsence,
      backColor: '#b63e36',
      loaderNeeded: false,
      cardTitle: 'Absence'
    }
    this.welcomeCardData.value = {
      mainContent: `Your student ID is: ${this.studentData.studentId}`,
      firstArgument: `Your group number is ${this.studentData.group}`,
      secondArgument: ``,
      displayedValue: this.studentData.avgGrade,
      backColor: '#42a0ef',
      loaderNeeded: false,
      cardTitle: `Welcome ${this.studentData.name}`
    }
    this.gradeCardData.value = {
      mainContent: `Average Grade: ${this.studentData.avgGrade.toFixed(2)}`,
      firstArgument: `Your weakest subject is ${this.studentData.lowestAvgSubject
        }: ${this.studentData.lowestAvg.toFixed(2)}`,
      secondArgument: `Your strongest subject is ${this.studentData.highestAvgSubject
        }: ${this.studentData.highestAvg.toFixed(2)}`,
      displayedValue: this.studentData.avgGrade.toFixed(2),
      backColor: '#33b864',
      loaderNeeded: true,
      cardTitle: 'Your Grades:'
    }
    console.log(this.studentData)
    const subjects = Object.keys(this.gradeData)
    for (let i = 0; i < subjects.length; i++) {
      const row = this.gradeData[subjects[i]]
      const subject = row[0].subject
      const gradeValues = row.map((g) => {
        return g.value
      })
      const gradeDates = row.map((g) => {
        return g.date.split('T')[0]
      })
      console.log(gradeValues)
      this.chartDataObjects.push({
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
    this.gradeDataFetched = true
  }
})


</script>
<template>
  <div class="flex-container">
    <section id="stats">
      <OverviewCardComponent :card-data="welcomeCardData" v-if="gradeDataFetched"></OverviewCardComponent>
      <OverviewCardComponent :card-data="gradeCardData" v-if="gradeDataFetched"></OverviewCardComponent>
      <OverviewCardComponent :card-data="absenceCardData" v-if="gradeDataFetched"></OverviewCardComponent>
    </section>
    <section id="chart-section" v-if="gradeDataFetched">
      <h1 class="main-title">
        <strong> Your Subjects </strong>
      </h1>
      <div class="subjects-section">
        <LineChart class="chart" v-for="chartDataObject in chartDataObjects" :chartData="chartDataObject"
          :key="chartDataObject.datasets[0].label"></LineChart>
      </div>
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

.grid-container {
  display: grid;
  grid-template-rows: 1fr 0.5fr 1.5fr;
  grid-template-columns: 1fr 1fr 1fr;
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
  color: white;
  text-align: center;

}

@media (max-width: 1500px) {
  #stats {
    flex-direction: column;
  }
}

.subjects-section {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
  width: 100%;
  height: 100%;
  /* height: 100%; */
  /* padding: 1rem 3rem; */
  /* background-color: var(--component-light-blue); */
}

.main-title {
  text-align: left;
  font-size: 2rem;
}
</style>
