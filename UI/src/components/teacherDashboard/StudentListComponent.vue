<template>
  <div class="list-container shadow">
    <h1 class="main-title align-c">Your students</h1>
    <ul class="list">
      <li class="list-item" v-for="(subject, index) in subjects" :key="index">
        <SpecialtyStudentComponent :students="students" :subject="subject" />
      </li>
    </ul>
  </div>
</template>
<script setup>
import SpecialtyStudentComponent from './SpecialtyStudentComponent.vue';

const props = defineProps(['subjects', 'students'])

console.log(props.subjects)
console.log(props.students.value)
</script>
<style scoped>
.list-item {
  width: 100%;
}
</style>
