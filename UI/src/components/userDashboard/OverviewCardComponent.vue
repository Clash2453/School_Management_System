<script setup lang="ts">
import RoundLoader from './RoundLoaderComponent.vue'
const props = defineProps<{
  cardData: {
    mainContent: string,
    firstArgument: string,
    secondArgument: string,
    displayedValue: string,
    backColor: string,
    loaderNeeded: boolean,
    cardTitle: string
  }
}>()
const startColor = '#ceff8f'
const endColor = '#0eff00'
</script>
<template>
  <section class="overview shadow">
    <RoundLoader v-if="props.cardData.loaderNeeded" :starting-color="startColor" :ending-color="endColor"
      :value="parseFloat(props.cardData.displayedValue)"></RoundLoader>
    <div class="stats-container">
      <h2 class="subtitle card-title">
        <strong>{{ props.cardData.cardTitle }}</strong>
      </h2>
      <h3 class="average subtitle">{{ props.cardData.mainContent }}</h3>
      <h4 class="discipline">{{ props.cardData.firstArgument }}</h4>
      <h4 class="discipline">{{ props.cardData.secondArgument }}</h4>
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
  background-color: v-bind('$props.cardData.backColor');
  border-radius: 5px;
  color: white;
  width: 100%;
  height: 14.5rem;
  min-height: fit-content;
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
  font-weight: bold;
}

.discipline {
  font-family: 'Lato', sans-serif;
  font-size: 1.125rem;
}

@media (max-width: 1625px) {
  .overview {
    width: 100%;
  }

  .discipline {
    font-size: 1rem;
  }
}

@media (max-width: 550px) {
  .overview {
    padding: 1rem;
    min-height: fit-content;
    height: 100%;
    width: 100%;
    padding: 0;
  }
}

</style>
