<script setup>
import NavigationComponent from './components/NavigationComponent.vue'
import FooterComponent from './components/FooterComponent.vue'
import './assets/main.css'
</script>

<template>
  <NavigationComponent />
  <router-view></router-view>
  <FooterComponent></FooterComponent>
</template>

<style scoped></style>
