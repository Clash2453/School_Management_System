<script setup>
import { ref } from 'vue'
const isStudent = ref('true')
const isTeacher = ref('false')
</script>
<template>
  <div>
    <form action="" id="studentForm" v-if="isTeacher">
      <div class="input-wrapper">
        <label></label>
        <input type="text" name="" id="" />
      </div>
    </form>
    <form action="" id="student-form" v-if="isStudent">
      <div class="input-wrapper">
        <label for=""></label>
        <input type="text" name="" id="" />
      </div>
      <div class="input-wrapper">
        <label for=""></label>
        <input type="text" name="" id="" />
      </div>
      <div class="input-wrapper">
        <label for=""></label>
        <input type="text" name="" id="" />
      </div>
      <div class="input-wrapper">
        <label for=""></label>
        <input type="text" name="" id="" />
      </div>
      <button class="submit-button"></button>
    </form>
  </div>
</template>
<style scoped></style>
