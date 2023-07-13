<script setup lang="ts">
import { onMounted, ref } from 'vue'
import OverviewCardComponent from '../../components/userDashboard/OverviewCardComponent.vue'
import StudentList from '../../components/teacherDashboard/StudentListComponent.vue'
import axios from 'axios'
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
    <OverviewCardComponent :card-data="options" />
    <StudentList :students="students" :subjects="subjects" />
  </section>
</template>
<style scoped>
.section-container {
  width: 100%;

  display: flex;
  padding: 1rem;
  gap: 1rem;
}
</style>
