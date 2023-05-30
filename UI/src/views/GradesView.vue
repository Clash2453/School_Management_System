<script setup>
import axios from 'axios'
import DataGrid from '../components/userDashboard/DataGridComponent.vue'
import { onMounted, ref } from 'vue'
let grades = ref({})
let dataFetched = ref(false)
onMounted(async () => {
  const data = await getGradesPerSubject()
  console.log(data)
  grades.value = {
    headers: ['Subjects', 'First Term', 'Term Grade', 'Second Term', 'Term Grade', 'Year Grade'],
    subjects: Object.keys(data),
    grades: data
  }
  console.log(grades.value)
  dataFetched.value = true
})
async function getGradesPerSubject() {
  try {
    const response = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Grade/subjects-with-grades`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    console.log(response.data)
    return response.data
  } catch (e) {
    console.log(e)
  }
}
</script>
<template>
  <section id="grade-section">
    <DataGrid :options="grades" v-if="dataFetched"></DataGrid>
  </section>
</template>
<style scoped>
#grade-section {
  width: 100%;
  height: 100%;

  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
