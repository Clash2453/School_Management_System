<script lang="ts">
import FeaturesSectionComponent from '../components/landingPage/FeaturesSectionComponent.vue'
import HeroSection from '../components/landingPage/HeroSectionComponent.vue'
import {defineComponent} from 'vue'

export default defineComponent({
  data: () => {
    return {}
  },
  components: {
    HeroSection,
    FeaturesSectionComponent
  }
})

</script>

<template>
  <HeroSection></HeroSection>
  <FeaturesSectionComponent></FeaturesSectionComponent>
</template>
