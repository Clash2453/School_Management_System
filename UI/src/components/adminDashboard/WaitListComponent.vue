<script setup>
import { ref, onMounted, inject } from 'vue'
import axios from 'axios'
import WaitListItemComponent from './WaitListItemComponent.vue'
let guests = ref([])
const emitter = inject('emitter')
onMounted(async () => {
  guests.value = await fetchWaitList()
  emitter.on('refreshList', async () => {
    guests.value = await fetchWaitList()
  })
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
</script>
<template>
  <div class="list-container shadow">
    <h1 class="main-title align-c">Applications waiting approval</h1>
    <ul class="list">
      <li
        class="list-item"
        v-for="(guest, index) in guests"
        :key="index"
        :ref="'guest-card' + guest.id"
      >
        <WaitListItemComponent :data="guest"></WaitListItemComponent>
      </li>
    </ul>
  </div>
</template>
<style scoped></style>
