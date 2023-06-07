<template>
  <div class="list-container">
    <h1 class="main-title align-c">Applications waiting approval</h1>
    <ul class="list">
      <li class="list-item" v-for="(guest, index) in guests" :key="index"></li>
    </ul>
  </div>
</template>
<script setup></script>
<style scoped>
/* .list-container; */
</style>
