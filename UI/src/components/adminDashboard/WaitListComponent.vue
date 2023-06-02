<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'
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
function expandCard(){

}
async function declineUser(){
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
    <h1 class="main-title">Applications waiting approval</h1>
    <ul class="list">
      <li class="list-item" v-for="(guest, index) in guests" :key="index">
        <div class="card-container">
          <div class="user-info">
            <h2 class="card-heading">{{ guest.name }}</h2>
            <h3 class="card-subtitle">{{ guest.email }}</h3>
            <h3 class="card-subtitle">{{ guest.id }}</h3>
          </div>
          <div class="button-wrapper">
            <button class="add-button" @click="expandCard">Add</button>
            <button class="decline-button" @click="declineUser">Reject</button>
          </div>
        </div>
        <div class="expanded-card">
          <input type="text" name="" id="">
        </div>
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

  color: white;
  font-family: 'Roboto', sans-serif;

  width: 100%;
  min-width: 18rem;
  height: 100%;
  padding: 1rem;
}
.list {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 1rem;
}
.card-container {
  width: 100%;
  min-height: fit-content;
  min-width: 17.25rem;
  min-height: 7.5rem;
  padding: 0.5rem;
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-radius: 30px;
  background: url('/images/card-background.svg') center no-repeat;
  background-size: cover;
}
.user-info {
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: center;
}
.button-wrapper {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  gap: 0.5rem;
}
.add-button,
.decline-button {
  width: 3rem;
  border-radius: 5px;
}
.add-button {
  background-color: #4ca0e7;
}
.decline-button {
  background-color: #f26c82;
}
</style>
