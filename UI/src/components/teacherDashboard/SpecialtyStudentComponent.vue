<template>
  <div class="list-item">
    <h2 class="subtitle subject-name align-c">{{ subject }}</h2>
    <div
      class="student-card"
      v-for="(student, i) in students[subject]"
      :key="i"
      :class="{ expanded: adding }"
    >
      <div class="info-wrapper">
        <h3 class="student-name subtitle">
          {{ student.name }}
        </h3>
      </div>

      <div class="selection-wrapper" >
        <div
          class="grade"
          id="grade-weak"
          @click="setGradeValue(2, student.name, student.studentId)"
        >
          2
        </div>
        <div
          class="grade"
          id="grade-average"
          @click="setGradeValue(3, student.name, student.studentId)"
        >
          3
        </div>
        <div
          class="grade"
          id="grade-good"
          @click="setGradeValue(4, student.name, student.studentId)"
        >
          4
        </div>
        <div
          class="grade"
          id="grade-very-good"
          @click="setGradeValue(5, student.name, student.studentId)"
        >
          5
        </div>
        <div
          class="grade"
          id="grade-excellent"
          @click="setGradeValue(6, student.name, student.studentId)"
        >
          6
        </div>
        <button @click="addGrade" class="add-button">Grade</button>
      </div>
    </div>
  </div>
</template>
<script setup>
import { ref} from 'vue'
import axios from 'axios'

const props = defineProps(['students', 'subject'])
const grade = ref({
  value: 6,
  studentId: -1,
  subject: props.subject,
  gradeType: 'regular'
})

// "value": 0,
//   "studentId": 0,
//   "subject": "string",
//   "gradeType": 0
console.log(props.students)
function setGradeValue(value, name, id) {
  grade.value.value = value
  grade.value.studentName = name
  grade.value.studentId = id

  console.log(name)
}
async function addGrade() {
  console.log(grade.value)
  try {
    const result = await axios({
      method: 'POST',
      data: grade.value,
      url: `https://localhost:7080/api/Grade`,
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
.list-item {
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 1rem;
  gap: 0.5rem;
}
.subject-name {
  background-color: #0b2239;
  width: 100%;
  border-radius: 5px;
  font-weight: 600;
  padding: 0.5rem 0;
}
.student-card {
  width: 100%;
  padding: 1rem;
  gap: 1rem;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  background-color: #0f355c;
  border-radius: 5px;
}
.info-wrapper {
  width: 100%;
  background-color: #0f355c;
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.selection-wrapper {
  display: flex;
  align-items: center;
  justify-content: flex-start;
  background-color: #091d31;
  padding: 0.5rem;
  border-radius: 5px;
  gap: 0.5rem;
}
.grade {
  padding: 0.5rem 1rem;
  border-radius: 5px;
  cursor: pointer;
}
#grade-weak {
  background-color: #f26c82;
}
#grade-average {
  background-color: #f6a14c;
}
#grade-good {
  background-color: #facc62;
}
#grade-very-good {
  background-color: #64bcbe;
}
#grade-excellent {
  background-color: #4ca0e7;
}
.add-button {
  padding: 0.3rem;
  border-radius: 5px;
}
.student-name {
  padding: 0.5rem;
}
.expanded {
  min-height: 5rem;
}
.grade:focus {
  border: 2px solid blue;
}
</style>
