<script setup>
import Loader from './RoundLoaderComponent.vue'
</script>
<template>
  <section class="container">
    <Loader></Loader>
    <h1 class="subtitle">Global Stats</h1>
  </section>
</template>
<style scoped>
.container {
  width: clamp(20rem, 30%, 40rem);
  padding: 1rem;
  border-radius: 10px;
  background-color: #2a9a9b;
  color: white;

  display: flex;
  gap: 1rem;
}
</style>
