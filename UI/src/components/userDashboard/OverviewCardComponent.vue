<script setup>
import RoundLoader from './RoundLoaderComponent.vue'
const props = defineProps([
  'mainContent',
  'firstArgument',
  'secondArgument',
  'backColor',
  'displayedValue',
  'loaderNeeded',
  'cardTitle'
])
const startColor = '#ceff8f'
const endColor = '#0eff00'

console.log(props.mainContent)
</script>
<template>
  <section class="overview">
    <RoundLoader
      v-if="props.loaderNeeded"
      :starting-color="startColor"
      :ending-color="endColor"
      :value="parseFloat(props.displayedValue)"
    ></RoundLoader>
    <div class="stats-container">
      <h2 class="subtitle card-title">{{ props.cardTitle }}</h2>
      <h3 class="average subtitle">{{ props.mainContent }}</h3>
      <h4 class="discipline">{{ firstArgument }}</h4>
      <h4 class="discipline">{{ secondArgument }}</h4>
    </div>
  </section>
</template>
<style scoped>
.overview {
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 1rem;
  gap: 1rem;
  background-color: v-bind('$props.backColor');
  border-radius: 5px;
  color: white;
  box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  width: clamp(20rem, 30%, 40rem);
  height: 100%;
  min-height: 14.5rem;
}
.stats-container {
  width: 100%;
  height: 100%;
  padding: 0.5rem;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;
  gap: 0.5rem;
}
.card-title {
  font-size: 1.5rem;
  margin-bottom: 1rem;
  font-weight: 900;
}
.discipline {
  font-family: 'Lato', sans-serif;
  font-size: 1.125rem;
}
@media (max-width: 1350px) {
  .overview {
    /* flex-direction: column; */
    width: 30rem;
  }
  .discipline {
    font-size: 1rem;
  }
}
@media (max-width: 550px) {
  .overview {
    flex-direction: column;
    width: fit-content;
    padding: 1rem;
  }
}
</style>
