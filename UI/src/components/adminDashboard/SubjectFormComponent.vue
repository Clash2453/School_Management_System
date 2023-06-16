<template>
  <div class="form-container shadow">
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
        <input
          type="text"
          name="title"
          id="subject-name"
          class="input-field"
          v-model="subject.name"
        />
      </div>
      <div class="input-wrapper">
        <label for="subjects-input">Teachers</label>
        <div class="select-wrapper">
          <v-select
            class="style-chooser"
            :options="teachers"
            :reduce="(teacher) => teacher.id"
            label="name"
            v-model="subject.teacherIds"
            id="teachers-input"
            multiple
          ></v-select>
        </div>
      </div>
      <button class="submit-button add-button" @click="addSubject">Add</button>
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
          <input
            type="text"
            name="title"
            id="specialty-name"
            class="input-field"
            v-model="specialty.name"
          />
        </div>
      </div>
      <div class="input-wrapper">
        <label for="subjects-input">Faculty:</label>
        <div class="select-wrapper">
          <v-select
            class="style-chooser"
            :options="faculties"
            label="name"
            id="faculty-input"
            :reduce="(faculty) => faculty.id"
            v-model="specialty.facultyId"
          ></v-select>
        </div>
      </div>
      <div class="input-wrapper">
        <label for="subjects-input">Subjects:</label>
        <div class="select-wrapper">
          <v-select
            class="style-chooser"
            :options="subjects"
            label="name"
            :reduce="(subject) => subject.id"
            id="subjects-input"
            v-model="specialty.subjectIds"
            multiple
          ></v-select>
        </div>
      </div>
      <button class="submit-button add-button" @click="addSpecialty">Add</button>
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
          <input
            type="text"
            name="title"
            id="faculty-name"
            class="input-field"
            v-model="faculty.name"
          />
        </div>
      </div>
      <div class="input-wrapper">
        <label for="group-input">Specialties:</label>
        <div class="select-wrapper">
          <v-select
            class="style-chooser"
            :options="specialties"
            label="name"
            id="specialties-input"
            :reduce="(specialty) => specialty.id"
            v-model="faculty.specialtyIds"
            multiple
          ></v-select>
        </div>
      </div>
      <button class="submit-button add-button" @click="addFaculty">Add</button>
    </form>
  </div>
</template>
<script setup>
import { ref, inject } from 'vue'
import axios from 'axios'

const props = defineProps(['subjects', 'teachers', 'faculties', 'specialties'])
const emitter = inject('emitter')
const activeTab = ref('subject')

const specialty = ref({
  name: '',
  facultyId: '',
  subjectIds: []
})

const subject = ref({
  name: '',
  teacherIds: []
})

const faculty = ref({
  name: '',
  specialtyIds: []
})

function swapActiveTab(tab) {
  activeTab.value = tab
}

async function addSubject() {
  try {
    const result = await axios({
      method: 'POST',
      data: subject.value,
      url: `https://localhost:7080/api/Subject`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    console.log(result.data)
    emitter.emit('renewSubjects', '')
    return result
  } catch (e) {
    console.log(e)
  }
}

async function addSpecialty() {
  try {
    console.log(specialty.value)
    const result = await axios({
      method: 'POST',
      data: specialty.value,
      url: `https://localhost:7080/api/Subject/add-specialty`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    console.log(result.data)
    emitter.emit('renewSpecialties', '')

    return result
  } catch (e) {
    console.log(e)
  }
}

async function addFaculty() {
  try {
    console.log(faculty.value)
    const result = await axios({
      method: 'POST',
      data: faculty.value,
      url: `https://localhost:7080/api/Subject/add-faculty`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    emitter.emit('renewFaculties', '')
    console.log(result.data)
    return result
  } catch (e) {
    console.log(e)
  }
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
  background-color: rgb(8, 101, 177);
  border-radius: 15px;
}
.input-wrapper-row {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 15.31rem;
  background-color: #002d53;
  border-radius: 5px;
  padding: 0.5rem;
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
