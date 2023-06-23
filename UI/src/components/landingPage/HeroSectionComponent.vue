<script setup>
import router from '../../router'
function goToLogin() {
  router.push('/login')
}

function goToAbout() {
  router.push('/about')
}
</script>

<template>
  <section id="hero">
    <div class="heading-wrapper">
      <h1 class="main-title">Digital information system for schools and universities.</h1>
      <h2 class="subtitle">
        A school management system demo supporting 3 types of user roles, interactive dashboard and
        event scheduler
      </h2>
      <div class="button-wrapper">
        <button class="main-button" @click="goToLogin">Try it out</button>
        <button class="secondary-button" @click="goToAbout">Learn more</button>
      </div>
    </div>
    <v-icon name="md-school-outlined" class="hero-image" fill="white"></v-icon>
  </section>
</template>

<style scoped>
#hero {
  width: 100%;

  display: flex;
  align-items: center;
  justify-content: space-between;
  background-color: #1f4873;
  background-image: url('/images/hero-background.svg');
  background-repeat: no-repeat;
  background-size: cover;
  background-position: bottom;
}
.hero-image {
  width: 30%;
  min-width: 400px;
  height: 25%;
  padding: 3rem;
  padding: 5rem;
}
.heading-wrapper {
  width: 50%;
  padding: 5rem;
  /* background-color: #1f4873; */
  display: flex;
  flex-direction: column;
  justify-content: center;
  color: white;
  gap: 2rem;
}
.button-wrapper {
  display: flex;
  align-items: center;
  justify-content: flex-start;
  gap: 1rem;
}

@media (min-width: 768px) {
  .hero-main-button,
  .hero-secondary-button {
    padding: 0.75rem 1.5rem;
  }
}
@media (max-width: 850px) {
  #hero {
    flex-direction: column-reverse;
  }
  .heading-wrapper {
    width: 100%;
  }
  .hero-image {
    width: 50%;
  }
}
@media (max-width: 450px) {
  .hero-image {
    width: 75%;
    padding: 2rem;
    min-width: 350px;
  }
  .heading-wrapper {
    padding: 2rem;
  }
}
</style>
