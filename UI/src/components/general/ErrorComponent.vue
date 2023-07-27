<script setup lang="ts">
import router from '../../router'
</script>
<template>
  <main class="flex">
    <div class="text-container">
      <h1 class="main-title">Page not found</h1>
      <h2 class="subtitle">Looks like there was a problem with the page you were looking for.</h2>
      <button class="main-button" @click="router.back()">Take me back</button>
    </div>
    <img src="/images/404-error-dark.svg" alt="Error 404" class="image" />
  </main>
</template>
<style scoped>
.flex,
.text-container {
  display: flex;
  align-items: center;
  gap: 1rem;
  background-color: var(--background-color);
}
.flex {
  width: 100%;
  flex: 1;
  justify-content: space-between;
  padding: 3rem;
  color: var(--font-color-primary);
}
.main-title {
  font-size: 5rem;
  color: var(--font-color-primary);
  justify-content: center;
}
.text-container {
  flex-direction: column;
}
.subtitle {
  color: var(--font-color-primary);
}
.main-button {
  align-self: flex-start;
  color: var(--font-color-primary );
}
.image {
  width: 100%;
  max-width: 40rem;
}
@media (max-width: 1300px){
  .main-title {
  font-size: 3rem;
}
}
@media (max-width: 750px){
  .flex {
    flex-direction: column;
    padding: 1rem;
  }
}
</style>
