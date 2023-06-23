<template>
  <section class="main-container">
    <SubjectFormComponent
      :subjects="subjects"
      :faculties="faculties"
      :teachers="teachers"
      :specialties="specialties"
    />
  </section>
</template>
<script setup>
import SubjectFormComponent from '../../components/adminDashboard/SubjectFormComponent.vue'
import axios from 'axios'
import { ref, inject, onMounted } from 'vue'
const emitter = inject('emitter')
const teachers = ref([])
const subjects = ref([])
const specialties = ref([])
const faculties = ref([])
onMounted(async () => {
  teachers.value = await fetchTeachers()
  subjects.value = await fetchSubjects()
  faculties.value = await fetchFaculties()
  specialties.value = await fetchSpecialties()

  emitter.on('renewSubjects', async () => {
    subjects.value = await fetchSubjects()
  })
  emitter.on('renewSpecialties', async () => {
    specialties.value = await fetchSpecialties()
  })
  emitter.on('renewFaculties', async () => {
    faculties.value = await fetchFaculties()
  })
})

async function fetchTeachers() {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Admin/fetch/teachers`,
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

async function fetchSpecialties() {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Subject/get-specialties`,
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

async function fetchFaculties() {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Subject/get-faculties`,
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

async function fetchSubjects() {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Subject/get-subjects`,
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
<style scoped>
.main-container {
  display: flex;
  flex-wrap: nowrap;
  justify-content: space-evenly;
  align-items: center;
  width: 100%;
  min-height: 100%;
  padding: 1rem;
  gap: 1rem;
  overflow: hidden;
}
</style>
