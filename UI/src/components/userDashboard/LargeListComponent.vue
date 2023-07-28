<template>
  <ul class="list shadow">
    <LargeListItemComponent v-for="(option, index) in dataset" :key="index" :options="option" />
  </ul>
</template>
<script setup lang="ts">
import { Emitter } from 'mitt';
import LargeListItemComponent from './LargeListItemComponent.vue'
import { ref, onMounted, inject } from 'vue'
type EventHandler = {
  renewUsers: ()=> void,
}
const emitter:Emitter<EventHandler> = inject('emitter')
const props = defineProps(['options'])
const dataset = ref([])
const matrix = ref({})

onMounted(async () => {
  matrix.value = props.options.itemLists
  emitter.on('renewUsers', parseData())
})
function parseData() {
  console.log('UPDATE RECEIVED')
  for (let i = 0; i < matrix.value.length; i++) {
    const row = matrix.value[i]
    console.log(row)
    for (let k = 0; k < row.length; k++) {
      const col = row[k]
      const data = {
        firstContent: col.name,
        secondContent: 'Id: ' + col.id,
        firstField: '',
        secondField: '',
        thirdField: ''
      }
      console.log(col)
      if (col.role === 'Student') {
        data.firstField = `Email: ${col.email}`
        data.secondField = `Course: ${col.attributes.Course}`
        data.thirdField = `Major: ${col.attributes.Specialty}`
      }
      if (col.role === 'Teacher') {
        data.firstField = `Email: ${col.email}`
        data.secondField = `Title: ${col.attributes.Title}`
      }
      if (col.role === 'Admin') {
        console.log('Admin')
      }
      dataset.value.push(data)
    }
  }
}
</script>
<style scoped>
.list {
  display: flex;
  height: 100% ;
  gap: 1rem;
  padding: 1rem;
  background-color: #00499b;
  background-color: var(--primary-color);
  background-size: cover;
  background-position: center;
  border-radius: 15px;
  max-height: 40rem; /* dont remove causes the page to resize uncontrolably */
  overflow-y: auto;
}
</style>
