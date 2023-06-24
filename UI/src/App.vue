<script setup>
import NavigationComponent from './components/general/NavigationComponent.vue'
import FooterComponent from './components/general/FooterComponent.vue'
import './assets/main.css'
import Loader from './components/general/LoadingComponent.vue'
</script>

<template>
  <NavigationComponent />
  <Suspense>
    <template #default>
      <router-view></router-view>
    </template>
    <template #fallback>
      <Loader></Loader>
    </template>
  </Suspense>
  <FooterComponent></FooterComponent>
</template>

<style scoped></style>
