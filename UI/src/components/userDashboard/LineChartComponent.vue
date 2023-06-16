<template>
  <div class="chart shadow">
    <Line :options="chartOptions" :data="props.chartData" />
  </div>
</template>

<script setup>
import { Line } from 'vue-chartjs'
import {
  Chart as ChartJS,
  Title,
  Tooltip,
  Legend,
  PointElement,
  LineElement,
  CategoryScale,
  LinearScale
} from 'chart.js'

ChartJS.register(Title, Tooltip, Legend, PointElement, LineElement, CategoryScale, LinearScale)

const props = defineProps(['chartData'])
const chartOptions = {
  responsive: true,
  plugins: {
    legend: {
      labels: {
        color: 'rgb(255, 255, 255)'
      }
    }
  },
  scales: {
    y: {
      ticks: { color: 'rgba(255, 255, 255, 1)' },
      suggestedMin: 2,
      suggestedMax: 6,
      grid: {
        color: 'rgba(255, 255, 255, 0.7)'
      }
    },
    x: {
      ticks: { color: 'rgba(255, 255, 255, 1)' },
      grid: {
        color: 'rgba(255, 255, 255, 0.7)'
      }
    }
  }
}
</script>
<style scoped>
.chart {
  width: 31rem;
  height: 20rem;
  background-color: var(--component-dark-blue);
  border-radius: 5px;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 1rem;

}
</style>
