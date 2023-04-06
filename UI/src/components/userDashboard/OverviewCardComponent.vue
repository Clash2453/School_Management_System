<script setup>
import RoundLoader from './RoundLoaderComponent.vue'

const props = defineProps(['mainContent', 'firstArgument', 'secondArgument'])
</script>
<template>
  <section class="overview">
    <RoundLoader></RoundLoader>
    <div class="stats-container">
      <h3 class="average subtitle">{{ mainContent }}</h3>
      <h4 class="discipline">{{ firstArgument }}</h4>
      <h4 class="discipline">{{ secondArgument }}</h4>
    </div>
  </section>
</template>
<style scoped>
.overview {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 1rem;
  gap: 1rem;
  background-color: #2a619b;
  border-radius: 5px;
  color: white;
  box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  width: 100%;
  height: 100%;
}
.stats-container {
  width: 100%;
  height: 100%;
  padding: 1rem;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;
  gap: 0.5rem;
}
.discipline {
  font-family: 'Lato', sans-serif;
  font-size: 1.125rem;
}
</style>
