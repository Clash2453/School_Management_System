<script setup>
import { ref, onMounted, defineAsyncComponent } from 'vue'
import ErrorComponent from '../components/general/ErrorComponent.vue'
import LoadingComponent from '../components/general/LoadingComponent.vue'
const WaitList = defineAsyncComponent({
  // the loader function
  loader: () => import('../components/adminDashboard/WaitListComponent.vue'),

  // A component to use while the async component is loading
  loadingComponent: LoadingComponent,
  // Delay before showing the loading component. Default: 200ms.
  delay: 200,

  // A component to use if the load fails
  errorComponent: ErrorComponent,
  // The error component will be displayed if a timeout is
  // provided and exceeded. Default: Infinity.
  timeout: 3000
})
</script>
<template>
  <section class="container">
    <WaitList></WaitList>
  </section>
</template>
<style scoped>
.container {
  display: flex;
  width: 100%;
  height: 100%;
}
</style>
