<script setup lang="ts">

const props = defineProps<{
  errorCode:string,
  message:string
}>()
</script>
<template>
  <main>
    <img :src="props.errorCode" alt="" />
    <h1 class="main-tile">404</h1>
  </main>
</template>
<style scoped></style>
