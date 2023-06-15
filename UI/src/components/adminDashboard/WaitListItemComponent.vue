<script setup>
import { ref, onMounted } from 'vue'
import { inject } from 'vue'
import axios from 'axios'
const props = defineProps(['data'])
let adding = ref(false)
const waitingUser = ref(true)
const emitter = inject('emitter')

onMounted(() => {
  emitter.on('onlyOne', (user) => {
    if (adding.value === true) adding.value = false
  })
})

function expandCard() {
  emitter.emit('onlyOne', () => {
    if (adding.value === true) adding.value = false
  })
  adding.value = true
}
async function declineUser() {
  try {
    const result = await axios({
      method: 'DELETE',
      url: `https://localhost:7080/api/Admin/delete-user?id=${props.data.id}`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    console.log(result.data)
    if (result.status === 200) {
      emitter.emit('refreshList', true)
    }
  } catch (e) {
    console.log(e)
  }
}

function addRole(role) {
  emitter.emit('adding', {
    id: props.data.id,
    name: props.data.name,
    email: props.data.email,
    role: role
  })
}
</script>
<template>
  <div
    class="card-container shadow"
    :class="{ 'expand-main': adding, selected: adding }"
    v-if="waitingUser"
    @click="expandCard"
  >
    <div class="main-wrapper" :class="{ expanded: adding }">
      <div class="user-info">
        <h2 class="card-heading no-flicker">Name: {{ props.data.name }}</h2>
        <h3 class="card-subtitle no-flicker">Email: {{ props.data.email }}</h3>
        <h3 class="card-subtitle no-flicker">Id: {{ props.data.id }}</h3>
      </div>
      <div class="button-wrapper">
        <button class="add-button no-flicker" @click="expandCard">Add</button>
        <button class="decline-button no-flicker" @click="declineUser">Reject</button>
      </div>
    </div>
    <div class="role-buttons" :class="{ 'expand-transition': adding }" v-if="adding">
      <button class="add-button no-flicker" @click="addRole('student')">Student</button>
      <button class="add-button no-flicker" @click="addRole('teacher')">Teacher</button>
    </div>
  </div>
</template>
<style scoped>
.card-container {
  width: 20rem;
  height: 100%;
  max-height: 7rem;
  min-height: fit-content;
  min-width: 17.25rem;
  padding: 0.5rem;
  gap: 0.5rem;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  border-radius: 25px;
  background-color: rgb(57, 72, 103);
  will-change: height;
  transform-origin: top center;
  cursor: pointer;
}
.main-wrapper {
  width: 100%;
  height: 100%;
  display: flex;
  gap: 0.5rem;
}
.card-heading,
.card-subtitle {
  text-overflow: ellipsis;
}
.user-info {
  width: 100%;
  display: flex;
  height: fit-content;
  flex-direction: column;
  align-items: flex-start;
  justify-content: center;
  padding: 0.5rem;
}
.button-wrapper,
.role-buttons {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 1rem;
}
.button-wrapper {
  flex-direction: column;
}
.role-buttons {
  padding: 0.5rem;
}
.add-button,
.decline-button {
  width: 4rem;
  border-radius: 5px;
  backface-visibility: hidden;
}
.expanded {
  min-height: fit-content;
}
.expand-main {
  justify-content: space-between;
  max-height: 12rem;
}
.expand-transition {
  animation: growAnimation 0.6s;
  backface-visibility: hidden;
}
.selected {
  background-color: rgb(38, 48, 68);
}
@keyframes growAnimation {
  0% {
    opacity: 0;
  }
  100% {
    opacity: 100%;
  }
}
</style>
