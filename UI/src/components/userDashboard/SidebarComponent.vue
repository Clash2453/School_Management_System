<script>
export default {
  props: ['state'],
  data: function () {
    return {}
  }
}
</script>
<template>
  <section class="container">
    <h1 class="main-title">{{ state }}</h1>
    <ul class="action-list">
      <li class="action-card">
        <router-link to="overview" class="action-button subtitle">Overview</router-link>
      </li>
      <li class="action-card">
        <router-link to="grades" class="action-button subtitle">Grades</router-link>
      </li>
      <li class="action-card">
        <router-link to="absence" class="action-button subtitle">Absence</router-link>
      </li>
      <li class="action-card">
        <router-link to="teachers" class="action-button subtitle">Teachers</router-link>
      </li>
    </ul>
  </section>
</template>
<style>
.container {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  gap: 1rem;
  padding: 1rem;

  width: 100%;
  height: 100%;
  max-width: 15rem;
  min-height: calc(100vh - 7rem);
  background-color: #2a619b;
  color: white;

  position: sticky;
  top: 0;
  left: 0;
}
.action-list {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  gap: 1rem;
}
.action-button {
  text-align: left;
}
</style>
