<script setup lang="ts">
import { iconFill } from '../../GlobalVariables';

defineProps<{title:string, description:string, iconName:string}>()
</script>
<template>
  <section class="feature-card">
    <v-icon :name="this.iconName" scale="5" :fill="iconFill" />
    <div class="text-wrapper">
      <h3 class="subtitle">{{ this.title }}</h3>
      <p class="description">{{ this.description }}</p>
    </div>
  </section>
</template>
<style scoped>
.feature-card {
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 1rem;

  border-radius: 5px;
  padding: 2rem;
  background-color: var(--primary-color);
}
.text-wrapper {
  color: var(--font-color-primary);
  padding: 1rem;
  display: flex;
  flex-direction: column;
  gap: 1rem;
}
.subtitle {
  font-size: 1.5rem;
}
.description {
  font-family: 'Montserrat', sans-serif;
  font-size: 1rem;
}
@media (max-width: 375px) {
  .feature-card {
    padding: 1rem;
  }
  .text-wrapper {
    width: 100%;
  }
}
</style>
../../api/themeSwitcher