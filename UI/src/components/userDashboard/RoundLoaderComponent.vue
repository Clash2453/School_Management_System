<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'

const props = defineProps(['startingColor', 'endingColor', 'value'])
let offset = ref(0)
watch(
  () => props.value,
  (newValue) => {
    offset.value = 439.6 - (439.6 * (newValue / 6) * 100) / 100
  }
)
onMounted(() => {
  offset.value = 439.6 - (439.6 * (props.value / 6) * 100) / 100
})
</script>
<template>
  <div class="display">
    <div class="outer">
      <div class="inner">
        <div id="grade">{{ props.value }}</div>
      </div>
    </div>
    <svg xmlns="http://www.w3.org/2000/svg" version="1.1" width="160px" height="160px">
      <defs>
        <linearGradient id="GradientColor">
          <stop offset="0%" :stop-color="props.startingColor" />
          <stop offset="100%" :stop-color="props.endingColor" />
        </linearGradient>
      </defs>
      <circle class="circle" cx="80" cy="80" r="70" stroke-linecap="round" />
    </svg>
  </div>
</template>
<style scoped>
.display {
  width: 15rem;
  height: 12.5rem;
  position: relative;
  top: 1rem;
}
.outer {
  width: 10rem;
  height: 10rem;
  border-radius: 50%;
  padding: 1.25rem;
  /* box-shadow: 6px 6px 10px -1px rgba(0, 0, 0, 0.15), -6px -6px 10px -1px rgba(0, 0, 0, 0.15); */
}
.inner {
  width: 7.5rem;
  height: 7.5rem;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
}
#grade {
  font-weight: 600;
  color: 555;
  font-family: 'Roboto', sans-serif;
  font-size: 1.5rem;
}
.circle {
  fill: none;
  stroke: url(#GradientColor);
  stroke-width: 1.25rem;
  stroke-dasharray: 439.6;
  stroke-dashoffset: 439.6;
  animation: fill 2s linear forwards;
}
@keyframes fill {
  100% {
    stroke-dashoffset: v-bind(offset);
  }
}
svg {
  position: absolute;
  top: 0;
  left: 0;
}
</style>
