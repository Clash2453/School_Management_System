<script setup>
import RoundLoader from './RoundLoaderComponent.vue'
</script>
<template>
  <section class="overview">
    <RoundLoader></RoundLoader>
    <div class="stats-container">
      <h3 class="average subtitle">Average Grade:</h3>
      <h4 class="discipline">Highest Grade:</h4>
      <h4 class="discipline">Lowest Subject:</h4>
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
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
}
.discipline {
  font-family: 'Lato', sans-serif;
  font-size: 1.125rem;
}
</style>
