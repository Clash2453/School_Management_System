<script>
import FeaturesSectionComponent from '../components/FeaturesSectionComponent.vue'
import HeroSection from '../components/HeroSectionComponent.vue'
export default {
  data: () => {
    return {}
  },
  components: {
    HeroSection,
    FeaturesSectionComponent
  }
}
</script>

<template>
  <HeroSection></HeroSection>
  <FeaturesSectionComponent></FeaturesSectionComponent>
</template>
