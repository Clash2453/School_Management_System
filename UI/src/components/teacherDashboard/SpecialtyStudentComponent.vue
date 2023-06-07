<template>
  <div
    class="container"
    v-for="(specialty, index) in specialtyWithStudents.specialties"
    :key="index"
  >
    <h3 class="subtitle">specialty.name</h3>
    <ul>
      <li v-for="(student, i) in specialtyWithStudents[specialty]" :key="i">{{ student.name }}</li>
    </ul>
  </div>
</template>
<script setup>
const props = defineProps(['specialtyWithStudents'])
</script>
<style scoped></style>
