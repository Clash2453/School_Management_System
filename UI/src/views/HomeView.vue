<script>
import FeaturesSectionComponent from '../components/landingPage/FeaturesSectionComponent.vue'
import HeroSection from '../components/landingPage/HeroSectionComponent.vue'
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
