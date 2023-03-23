<script></script>

<template>
  <section id="hero">
    <div class="heading-wrapper">
      <h1 class="main-title">Digital information system for schools and universities.</h1>
      <h2 class="subtitle">
        A school management system demo supporting 3 types of user roles, interactive dashboard and
        event scheduler
      </h2>
      <div class="button-wrapper">
        <button class="hero-main-button">Try it out</button>
        <button class="hero-secondary-button">Learn more</button>
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
}
.hero-image {
  width: 30%;
  height: 25%;
  padding: 3rem;
  padding: 5rem;
}
.heading-wrapper {
  width: 50%;
  padding: 5rem;
  background-color: #1f4873;
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
.hero-main-button {
  background-color: #1a395a;
  border: 1px solid transparent;
  border-radius: 0.75rem;
  color: #ffffff;
  cursor: pointer;
  flex: 0 0 auto;
  font-family: Roboto, 'Helvetica Neue', Arial, 'Noto Sans', sans-serif, 'Apple Color Emoji',
    'Segoe UI Emoji', 'Segoe UI Symbol', 'Noto Color Emoji';
  font-size: 1.125rem;
  font-weight: 600;
  line-height: 1.5rem;
  padding: 0.75rem 1.2rem;
  text-align: center;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  width: auto;
}

.hero-main-button:hover {
  background-color: #27598f;
}

.hero-main-button:focus {
  box-shadow: none;
  outline: 2px solid transparent;
  outline-offset: 2px;
}

.hero-secondary-button {
  appearance: none;
  background-color: transparent;
  border: 2px solid #ffffff;
  border-radius: 15px;
  cursor: pointer;
  display: inline-block;
  font-family: Roboto, 'Helvetica Neue', Arial, 'Noto Sans', sans-serif, 'Apple Color Emoji',
    'Segoe UI Emoji', 'Segoe UI Symbol', 'Noto Color Emoji';
  font-size: 1.125rem;
  font-weight: 600;
  line-height: normal;
  margin: 0;
  min-width: 0;
  outline: none;
  padding: 0.75rem 1.2rem;
  text-align: center;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  width: auto;
  will-change: transform;
}

.hero-secondary-button:disabled {
  pointer-events: none;
}

.hero-secondary-button:hover {
  color: #fff;
  background-color: #27598f;
  box-shadow: rgba(0, 0, 0, 0.25) 0 8px 15px;
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
  }
  .heading-wrapper {
    padding: 2rem;
  }
}
</style>
