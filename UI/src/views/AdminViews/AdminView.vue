<template>
  <section class="container">
    <WaitList></WaitList>
    <ValidationFormComponent :faculties="faculties" :groups="groups" :specialties="specialties" />
    <LargeList :options="sortedUsers" v-if="dataFetched" />
  </section>
</template>

<script setup lang="ts">
import { ref, onMounted, defineAsyncComponent, inject, Ref } from 'vue'
import ErrorComponent from '../../components/general/ErrorComponent.vue'
import LoadingComponent from '../../components/general/LoadingComponent.vue'
import ValidationFormComponent from '../../components/adminDashboard/ValidationFormComponent.vue'
import LargeList from '../../components/userDashboard/LargeListComponent.vue'
import { fetchAdmins, fetchTeachers, fetchFaculties, fetchSpecialties, fetchSubjects, fetchStudents } from '../../api/apiService'
import type { Teacher } from '../../interfaces/Teacher'
import { Admin } from '../../interfaces/Admin'
import { Student } from '../../interfaces/Student'
import { Subject } from '../../interfaces/Subject'
import { ErrorHandlingService } from '../../services/ErrorHandlingService'
import { Emitter} from 'mitt'

type RenewEvent = {
  renewSpecialties?:string,
  renewSubjects?:string,
  renewFaculties?:string, 
}

const emitter:Emitter<RenewEvent> = inject('emitter')
const errHandler:ErrorHandlingService = inject('errorHandler')

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
const teachers: Ref<Teacher[]> = ref()
const subjects:Ref<Subject[]> = ref()
const specialties = ref([])
const faculties = ref([])
const admins: Ref<Admin[]> = ref()
const students: Ref<Student[]> = ref()
const groups = ref([76, 77])
const dataFetched = ref(false)
onMounted(async () => {
  try {
    teachers.value = await fetchTeachers()
    subjects.value = await fetchSubjects()
    faculties.value = await fetchFaculties()
    specialties.value = await fetchSpecialties()
    admins.value = await fetchAdmins()
    students.value = await fetchStudents()
  }catch(e:unknown ){
    if(errHandler.isAxiosError(e)){
      console.error(e)
    }
    if(errHandler.isError(e)){
      console.error(e)
    }
      console.error(new Error(`Non typed error:\n ${e}`))
  }

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
