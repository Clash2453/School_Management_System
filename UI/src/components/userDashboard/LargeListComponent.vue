<template>
  <ul class="list shadow">
    <LargeListItemComponent v-for="(option, index) in dataset" :key="index" :options="option" />
    <!-- <LargeListItemComponent :options="data" />
    <LargeListItemComponent :options="data" />
    <LargeListItemComponent :options="data" />
    <LargeListItemComponent :options="data" /> -->
  </ul>
</template>
<script setup>
import LargeListItemComponent from './LargeListItemComponent.vue'
import { ref, onMounted, inject } from 'vue'
const emitter = inject('emitter')
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
  gap: 1rem;
  padding: 1rem;
  background-color: #00499b;
  /* background: url('/images/form-background.svg') no-repeat; */
  background-color: var(--component-dark-blue);
  background-size: cover;
  background-position: center;
  border-radius: 15px;
  max-width: 50rem;
  max-height: 40rem;
  overflow-y: auto;
}
</style>
