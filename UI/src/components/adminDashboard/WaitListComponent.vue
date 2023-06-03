<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'
import WaitListItemComponent from './WaitListItemComponent.vue'

let guests = ref([])
onMounted(async () => {
  guests.value = await fetchWaitList()
  console.log(guests)
})
async function fetchWaitList() {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Admin/guests`,
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
async function approveStudent() {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Admin/guests`,
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
async function approveTeacher() {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Admin/guests`,
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
<template>
  <div class="list-container">
    <h1 class="main-title align-c">Applications waiting approval</h1>
    <ul class="list">
      <li class="list-item" v-for="(guest, index) in guests" :key="index">
        <WaitListItemComponent :data="guest"></WaitListItemComponent>
        <!-- <div class="student-form">
          <div class="input-wrapper">
            <label for="faculty" class="subtitle">Faculty:</label>
            <input type="text" name="title" id="title-input" class="input-field" />
          </div>
          <div class="input-wrapper">
            <label for="specialty" class="subtitle">Specialty:</label>
            <input type="text" name="title" id="title-input" class="input-field" />
          </div>
          <div class="input-wrapper">
            <label for="group" class="subtitle">Group:</label>
            <input type="text" name="title" id="title-input" class="input-field" />
          </div> -->

          <!-- <button class="add-button">Add</button>
        </div> -->
      </li>
    </ul>
  </div>
</template>
<style scoped>
.list-container {
  background-image: url('/images/waitList-background.svg');
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;

  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;

  color: white;
  font-family: 'Roboto', sans-serif;

  width: 23.4375rem;
  border-radius: 15px;
  min-width: 18rem;
  height: 100%;
  max-height: calc(100vh - 10rem);
  /* overflow-y: auto; */
  /* padding: 1rem; */
}
.list {
  width: 100%;
  height: 80%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  gap: 1rem;
  /* margin-top: 3rem; */
  padding: 1rem 0;
  min-height: fit-content;
  overflow-y: auto;
}
.main-title {
  height: 20%;
  min-height: fit-content;
  margin-top: 1rem;
  font-size: 1.5rem;
}
.input-wrapper {
  display: flex;
  flex-direction: column;
}
.input-field {
  background-color: rgba(11, 53, 89, 0.4);
}
</style>
