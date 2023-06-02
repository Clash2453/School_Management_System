<script setup></script>
<template>
  <main class="main-container">
    <div class="message-container">
      <h1 class="main-title">Thank you for your registration!</h1>
      <h2 class="subtitle">
        Your application is waiting approval while this is happening there is nothing for you to do,
        but enjoy a cup of coffee and relax as we take care of everything.
      </h2>
    </div>
    <div class="image-wrapper">
      <img src="/images/latte.png" alt="cup of coffee" class="coffee-cup" />
    </div>
  </main>
</template>
<style scoped>
.main-container {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: row;
  color: white;
  text-align: center;
  gap: 2rem;
  width: 100%;
  max-height: 100%;
  min-height: calc(100vh - 13rem);
  background: url('/images/waiting-page-background.svg') no-repeat;
  background-position: center;
  background-size: cover;
}
.coffee-cup {
  aspect-ratio: 1/1;
  width: 360px;
}
.image-wrapper {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  width: 40%;
  max-height: 100%;
  min-height: calc(100vh - 13rem);
}
.message-container {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  color: white;
  text-align: center;
  width: 60%;
  padding: 2rem 0 2rem 0;
  gap: 4rem;
}
@media (max-width: 650px) {
  .main-container {
    flex-direction: column;
  }
  .image-wrapper {
    min-height: fit-content;
  }
  .message-container {
    padding: 1rem 0 1rem 0;
  }
}
</style>
