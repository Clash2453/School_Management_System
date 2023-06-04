<script setup>
import { ref } from 'vue'
const isTeacher = ref(false)
</script>
<template>
  <div>
    <form action="" id="student-form" class="form" v-on:submit.prevent="onSubmit" v-if="isTeacher">
      <div class="input-wrapper">
        <label for="title-input">Title:</label>
        <input type="text" name="title" id="title-input" class="input-field" />
      </div>
    </form>
    <form action="" id="student-form" class="form" v-on:submit.prevent="onSubmit" v-if="!isTeacher">
      <div class="input-wrapper">
        <label for="faculty-input">Faculty</label>
        <input type="text" name="faculty" id="faculty-input" class="input-field" />
      </div>
      <div class="input-wrapper">
        <label for="group-input">Group</label>
        <input type="text" name="group" id="group-input" class="input-field" />
      </div>
      <div class="input-wrapper">
        <label for="specialty-input">Specialty</label>
        <input type="text" name="specialty" id="specialty-input" class="input-field" />
      </div>
      <button class="submit-button">Approve</button>
    </form>
  </div>
</template>
<style scoped>
.form {
  width: 100%;
  height: 80%;

  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;

  padding: 1rem;
  color: white;
}
.input-field {
  background-color: rgba(11, 53, 89, 0.4);
  font-size: 1rem;
  padding: 0.5rem;
  color: inherit;
}
.submit-button {
  
}
</style>
