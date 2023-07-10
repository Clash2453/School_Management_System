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
<script setup lang="ts" >
import SubjectFormComponent from '../../components/adminDashboard/SubjectFormComponent.vue'
import type {Teacher} from '../../interfaces/Teacher'
import type {Subject} from '../../interfaces/Subject'
import { ref, inject, onMounted} from 'vue'
import{ Emitter } from 'mitt';
import { fetchTeachers, fetchFaculties, fetchSpecialties, fetchSubjects } from '../../api/apiService'
import { Specialty } from '../../interfaces/Specialty';

type RenewEvent = {
  renewSpecialties?:string,
  renewSubjects?:string,
  renewFaculties?:string,
}

const emitter:Emitter<RenewEvent> = inject('emitter')
const teachers = ref<Teacher[]>()
const subjects = ref<Subject[]>()
const specialties = ref<Specialty[]>()
const faculties = ref([]) 
onMounted(async () => { 
  teachers.value = await fetchTeachers()
  subjects.value = await fetchSubjects()
  faculties.value = await fetchFaculties()
  specialties.value = await fetchSpecialties()
  if(emitter == undefined){
    console.log('emitter error')
  }else{
    emitter.on('renewSubjects', async () => {
    subjects.value = await fetchSubjects()
  })
  emitter.on('renewSpecialties', async () => {
    specialties.value = await fetchSpecialties()
  })
  emitter.on('renewFaculties', async () => {
    faculties.value = await fetchFaculties()
  })
  }
})
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
