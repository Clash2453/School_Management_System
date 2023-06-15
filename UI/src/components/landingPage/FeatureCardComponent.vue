<script>
export default {
  props: ['title', 'description', 'iconName'],
  data: function () {
    return {}
  },
  mounted() {
    console.log(this.iconName)
  }
}
</script>
<template>
  <section class="feature-card">
    <v-icon :name="this.iconName" scale="5" fill="white" />
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
  background-color: var(--dashboard-background-light-blue);
}
.text-wrapper {
  color: white;
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
