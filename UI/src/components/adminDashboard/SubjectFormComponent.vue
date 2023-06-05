<template>
  <div class="form-container">
    <div class="tab-container">
      <button
        class="subtitle tab-button"
        @click="swapActiveTab('subject')"
        :class="{ 'active-tab': activeTab === 'subject' }"
      >
        Subject
      </button>
      <button
        class="subtitle tab-button"
        @click="swapActiveTab('specialty')"
        :class="{ 'active-tab': activeTab === 'specialty' }"
      >
        Specialty
      </button>
      <button
        class="subtitle tab-button"
        @click="swapActiveTab('faculty')"
        :class="{ 'active-tab': activeTab === 'faculty' }"
      >
        Faculty
      </button>
    </div>
    <form
      action=""
      id="student-form"
      class="form"
      v-on:submit.prevent="onSubmit"
      v-if="activeTab === 'subject'"
    >
      <div class="input-wrapper">
        <label for="title-input">Name:</label>
        <input type="text" name="title" id="subject-name" class="input-field" />
      </div>
      <div class="input-wrapper">
        <label for="subjects-input">Teachers</label>
        <div class="select-wrapper">
          <v-select class="style-chooser" :options="teachers" id="group-input" multiple></v-select>
        </div>
      </div>
      <button class="submit-button add-button">Add</button>
    </form>
    <form
      action=""
      id="student-form"
      class="form"
      v-on:submit.prevent="onSubmit"
      v-if="activeTab === 'specialty'"
    >
      <div class="input-wrapper">
        <label for="faculty-input">Name:</label>
        <div class="select-wrapper">
          <input type="text" name="title" id="specialty-name" class="input-field" />
        </div>
      </div>
      <div class="input-wrapper">
        <label for="subjects-input">Subjects:</label>
        <div class="select-wrapper">
          <v-select class="style-chooser" :options="data" id="group-input"></v-select>
        </div>
      </div>
      <div class="input-wrapper">
        <ul class="selection-list"></ul>
      </div>
      <button class="submit-button add-button">Add</button>
    </form>
    <form
      action=""
      id="student-form"
      class="form"
      v-on:submit.prevent="onSubmit"
      v-if="activeTab === 'faculty'"
    >
      <div class="input-wrapper">
        <label for="faculty-input">Name:</label>
        <div class="select-wrapper">
          <input type="text" name="title" id="faculty-name" class="input-field" />
        </div>
      </div>
      <div class="input-wrapper">
        <label for="group-input">Specialties:</label>
        <div class="select-wrapper">
          <v-select class="style-chooser" :options="data" id="specialties-input"></v-select>
        </div>
      </div>
      <div class="input-wrapper">
        <ul class="selection-list">
          <li class="selection-item"></li>
        </ul>
      </div>
      <button class="submit-button add-button">Add</button>
    </form>
  </div>
</template>
<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'
const activeTab = ref('subject')
const data = ['Pomosht', ' Vasko']
const teachers = ref([])
onMounted(async () => {
  teachers.value = await fetchTeachers()
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
    console.log(result.data.map((teacher) => teacher.name))
    return result.data.map((teacher) => teacher.name)
  } catch (e) {
    console.log(e)
  }
}
function swapActiveTab(tab) {
  activeTab.value = tab
}
</script>
<style scoped>
.form-container {
  flex-direction: column;
}
.tab-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 0.5rem;
  color: white;
}
.tab-button {
  padding: 1rem;
  background-color: #0865b1;
  border-radius: 15px;
}
.submit-button {
  width: 4rem;
  font-size: 1.2rem;
  text-align: center;
}
.active-tab {
  background-color: #4ca0e7;
}
</style>
