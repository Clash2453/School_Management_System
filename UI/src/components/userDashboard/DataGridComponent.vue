<script setup>
import { onMounted, ref } from 'vue'
const props = defineProps(['options'])
const rowData = ref([])
let maxRowSpan = ref(0)

onMounted(() => {
  props.options.subjects.forEach((subject) => {
    rowData.value.push(props.options.grades[subject])
  })
  // console.log(rowData)

  for (let i = 0; i < props.options.subjects.length; i++) {
    const row = rowData.value[i]
    // console.log(row)
    if (row.length >= maxRowSpan.value) maxRowSpan.value = row.length
  }
})

console.log(props.options)
</script>
<template>
  <div class="table-container">
    <table id="grades-table" class="table-component">
      <thead>
        <tr>
          <th class="subtitle header table-component">{{ props.options.headers[0] }}</th>
          <th class="subtitle header table-component">
            {{ props.options.headers[1] }}
          </th>
          <th class="subtitle header table-component">{{ props.options.headers[2] }}</th>
          <th class="subtitle header table-component">{{ props.options.headers[3] }}</th>
          <th class="subtitle header table-component">{{ props.options.headers[4] }}</th>
          <th class="subtitle header table-component">{{ props.options.headers[5] }}</th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(row, index) in props.options.subjects"
          :key="index"
          :class="{ light: index % 2, dark: !(index % 2) }"
          class="table-row"
        >
          <td class="main-column subtitle">
            {{ row }}
          </td>
          <td class="table-cell" :class="{ light: index % 2, dark: !(index % 2) }">
            <button
              v-for="(grade, gradeId) in rowData[index]"
              :key="gradeId"
              class="grade subtitle"
              :class="{
                green: grade.value >= 5.5,
                blue: grade.value <= 5.5 && grade.value >= 4.5,
                yellow: grade.value <= 4.5 && grade.value >= 3.5,
                orange: grade.value <= 3.5 && grade.value >= 3,
                red: grade.value == 2
              }"
            >
              {{ grade.value }}
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
<style scoped>
.table-container {
  overflow-x: scroll;
  width: 100%;
  padding: 1rem;
}
#grades-table {
  color: white;
  width: 100%;
  height: 100%;
  min-width: 62.5rem;
  padding: 1rem;
  table-layout: fixed;
}
.header {
  width: fit-content;
  padding: 0.5rem;
  min-width: 10rem;
  background-color: #2a619b;
  white-space: nowrap;
}
.main-title {
  font-weight: 400;
  font-size: 1.5rem;
}
.main-column {
  padding: 1rem 0.5rem;
}
.light {
  background-color: #2a619b;
}
.dark {
  background-color: #062d55;
}
.table-component {
  color: white;
}
.grade {
  border-radius: 5px;
  min-width: 3rem;
  font-weight: bold;
  font-size: 1.3rem;
}
.red {
  background-color: #ec3a57;
}
.orange {
  background-color: #f6a14c;
}
.yellow {
  background-color: #facc62;
}
.blue {
  background-color: #4ca0e7;
}
.green {
  background-color: #4cc540;
}
.table-row {
  width: 100%;
  height: 100%;
  padding: 0.5rem;
  min-height: fit-content;
}
.table-cell {
  display: flex;
  align-items: center;
  justify-content: flex-start;
  margin-bottom: auto;
  flex-wrap: wrap;
  width: 100%;
  height: 100%;
  min-height: fit-content;
  padding: 0.5rem;
  flex: 1;
  gap: 0.5rem;
  padding: 1rem;
  vertical-align: center;
}
@media (max-width: 1275px) {
  .subtitle {
    font-size: 1rem;
  }
  .header {
    padding: 0.5rem 0;
    white-space: nowrap;
  }
  .grade {
    /* padding: 0 0.5rem; */
    border-radius: 5px;
    min-width: 2rem;
  }
}
</style>
