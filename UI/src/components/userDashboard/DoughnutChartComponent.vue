<template>
  <div class="chart shadow">
    <Doughnut :data="data"></Doughnut>
  </div>
</template>
<script setup lang="ts">
import { Doughnut } from 'vue-chartjs'
import {
  Chart as ChartJS,
  Title,
  Tooltip,
  Legend,
  PointElement,
  ArcElement,
  CategoryScale,
  LinearScale
} from 'chart.js'

ChartJS.register(Title, Tooltip, Legend, PointElement, ArcElement, CategoryScale, LinearScale)
const data = {
  labels: ['Red', 'Blue', 'Yellow'],
  datasets: [
    {
      label: 'My First Dataset',
      data: [300, 50, 100],
      backgroundColor: ['rgb(255, 99, 132)', 'rgb(54, 162, 235)', 'rgb(255, 205, 86)'],
      hoverOffset: 4
    }
  ]
}
</script>
<style scoped>
.chart {
  width: 100%;
  height: 100%;
}
</style>
