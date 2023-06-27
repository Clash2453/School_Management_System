<template>
  <section class="container">
    <WaitList></WaitList>
    <ValidationFormComponent :faculties="faculties" :groups="groups" :specialties="specialties" />
    <SubjectFormComponent
      :subjects="subjects"
      :faculties="faculties"
      :teachers="teachers"
      :specialties="specialties"
    />
    <LargeList :options="sortedUsers" v-if="dataFetched" />
  </section>
</template>

<script setup>
import { ref, onMounted, defineAsyncComponent, inject } from 'vue'
import ErrorComponent from '../../components/general/ErrorComponent.vue'
import LoadingComponent from '../../components/general/LoadingComponent.vue'
import ValidationFormComponent from '../../components/adminDashboard/ValidationFormComponent.vue'
import DoughnutDiagram from '../../components/userDashboard/DoughnutDiagramComponent.vue'
import RadarChart from '../../components/userDashboard/RadarChartComponent.vue'
import axios from 'axios'
import LargeList from '../../components/userDashboard/LargeListComponent.vue'
import RadarChartComponent from '../../components/userDashboard/RadarChartComponent.vue'

import { fetchAdmins, fetchTeachers, fetchFaculties, fetchSpecialties, fetchSubjects, fetchStudents } from '../../api/apiService'

const emitter = inject('emitter')

const WaitList = defineAsyncComponent({
  // the loader function
  loader: () => import('../../components/adminDashboard/WaitListComponent.vue'),

  // A component to use while the async component is loading
  loadingComponent: LoadingComponent,
  // Delay before showing the loading component. Default: 200ms.
  delay: 200,

  // A component to use if the load fails
  errorComponent: ErrorComponent,
  // The error component will be displayed if a timeout is
  // provided and exceeded. Default: Infinity.
  timeout: 3000
})
const sortedUsers = ref({
  categories: ['Students, Teachers, Admins'],
  itemLists: []
})
const teachers = ref([])
const subjects = ref([])
const specialties = ref([])
const faculties = ref([])
const admins = ref([])
const students = ref([])
const groups = ref([76, 77])
const dataFetched = ref(false)
onMounted(async () => {
  teachers.value = await fetchTeachers()
  subjects.value = await fetchSubjects()
  faculties.value = await fetchFaculties()
  specialties.value = await fetchSpecialties()
  admins.value = await fetchAdmins()
  students.value = await fetchStudents()

  sortedUsers.value.itemLists.push(students.value)
  sortedUsers.value.itemLists.push(teachers.value)
  sortedUsers.value.itemLists.push(admins.value)

  dataFetched.value = true
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

</script>

<style scoped>
.container {
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
@media (max-width: 1550px) {
  .container {
    flex-direction: column;
  }
}
</style>
