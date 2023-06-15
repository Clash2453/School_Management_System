<script>
import FeatureCardComponent from './FeatureCardComponent.vue'

export default {
  data: function () {
    return {
      cards: [
        {
          title: 'Lorem',
          description:
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed a efficitur mi. Fusce pretium viverra ante, ac semper est imperdiet sit amet. Ut porta vehicula. ',
          icon: 'md-web'
        },
        {
          title: 'Lorem',
          description:
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed a efficitur mi. Fusce pretium viverra ante, ac semper est imperdiet sit amet. Ut porta vehicula. ',
          icon: 'md-accounttree-outlined'
        },
        {
          title: 'Lorem',
          description:
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed a efficitur mi. Fusce pretium viverra ante, ac semper est imperdiet sit amet. Ut porta vehicula. ',
          icon: 'md-supportagent'
        },
        {
          title: 'Lorem',
          description:
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed a efficitur mi. Fusce pretium viverra ante, ac semper est imperdiet sit amet. Ut porta vehicula. ',
          icon: 'hi-solid-chart-pie'
        },
        {
          title: 'Lorem',
          description:
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed a efficitur mi. Fusce pretium viverra ante, ac semper est imperdiet sit amet. Ut porta vehicula. ',
          icon: 'hi-clipboard-list'
        },
        {
          title: 'Lorem',
          description:
            'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed a efficitur mi. Fusce pretium viverra ante, ac semper est imperdiet sit amet. Ut porta vehicula. ',
          icon: 'bi-calendar2-week'
        }
      ]
    }
  },
  components: { FeatureCardComponent }
}
</script>

<template>
  <section id="features-section">
    <FeatureCardComponent
      v-for="card in this.cards"
      :title="card.title"
      :description="card.description"
      :iconName="card.icon"
      :key="card.title"
    ></FeatureCardComponent>
  </section>
</template>

<style scoped>
#features-section {
  width: 100%;
  height: 100%;

  display: grid;
  grid-template-columns: repeat(3, 1fr);
  grid-template-rows: repeat(2, 250px);
  gap: 2rem;
  padding: 2rem;
  background-color: var(--dashboard-background-blue);
  /* background-image: url('/images/feature-section-background.svg'); */
  background-repeat: no-repeat;
  background-size: cover;
}
@media (max-width: 1350px) {
  #features-section {
    grid-template-columns: repeat(auto-fill, minmax(400px, 1fr));
  }
}
@media (max-width: 375px) {
  #features-section {
    grid-template-columns: repeat(auto-fill, minmax(325px, 1fr));
    grid-template-rows: repeat(auto-fill, 325px);
    padding: 1rem;
  }
}
</style>
