<template>
  <div class="chart shadow">
    <Radar :data="data" :options="options"></Radar>
  </div>
</template>
<script setup lang="ts">
import { Radar } from 'vue-chartjs'
import {
  Chart as ChartJS,
  RadialLinearScale,
  PointElement,
  LineElement,
  Filler,
  Tooltip,
  Legend
} from 'chart.js'

ChartJS.register(Tooltip, Legend, PointElement, RadialLinearScale, LineElement, Filler)

const options = {
  scales: {
    r: {
      pointLabels: {
        color: 'rgba(240, 240, 240,0.8 )'
      },
      max: 100,
      min: 0,
      ticks: {
        stepSize: 20,
        textStrokeColor: '#fff',
        color: '#fff',
        backdropColor: 'rgb(47, 56, 62)'
      },
      angleLines: {
        color: 'rgba(240, 240, 240,0.8 )'
      },

      grid: {
        color: 'rgba(240, 240, 240,0.8)'
      }
    }
  },
  plugins: {
    legend: {
      labels: {
        color: 'rgb(255, 255, 255)'
      }
    }
  }
}

const data = {
  labels: ['Eating', 'Drinking', 'Sleeping', 'Designing', 'Coding', 'Cycling', 'Running'],
  datasets: [
    {
      label: 'My First dataset',
      backgroundColor: 'rgba(0, 193, 255,0.2)',
      fill: true,
      borderColor: 'rgba(0, 193, 255,1)',
      pointBackgroundColor: 'rgba(179,181,198,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(179,181,198,1)',
      data: [65, 59, 90, 81, 56, 55, 40]
    },
    {
      label: 'My Second dataset',
      backgroundColor: 'rgba(255,99,132,0.2)',
      borderColor: 'rgba(255,99,132,1)',
      pointBackgroundColor: 'rgba(255,99,132,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(255,99,132,1)',
      data: [28, 48, 40, 19, 96, 27, 100]
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
