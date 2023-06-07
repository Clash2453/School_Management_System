<script setup>
import { onMounted, ref } from 'vue'
import OverviewCardComponent from '../components/userDashboard/OverviewCardComponent.vue'
import StudentList from '../components/teacherDashboard/StudentListComponent.vue'
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
onMounted(async () => {
  const teacherData = await fetchTeacherData()
  options.value.mainContent = `Your teacher ID is: ${teacherData.id}`
  options.value.cardTitle = `Welcome ${teacherData.name}`
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
    <StudentList />
  </section>
</template>
<style scoped>
.section-container {
  width: 100%;
  height: 100%;

  display: flex;
  padding: 1rem;
  gap: 1rem;
}
</style>
