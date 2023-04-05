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
  background-color: #222f3d;
  background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' version='1.1' xmlns:xlink='http://www.w3.org/1999/xlink' xmlns:svgjs='http://svgjs.com/svgjs' width='1440' height='560' preserveAspectRatio='none' viewBox='0 0 1440 560'%3e%3cg mask='url(%26quot%3b%23SvgjsMask1005%26quot%3b)' fill='none'%3e%3crect width='1440' height='560' x='0' y='0' fill='rgba(34%2c 47%2c 61%2c 1)'%3e%3c/rect%3e%3cpath d='M0%2c391.512C71.046%2c375.925%2c127.21%2c330.424%2c194.311%2c302.354C279.508%2c266.714%2c401.44%2c284.419%2c447.438%2c204.338C492.526%2c125.841%2c434.436%2c26.496%2c401.107%2c-57.67C373.548%2c-127.265%2c320.588%2c-178.772%2c272.887%2c-236.458C223.911%2c-295.686%2c188.141%2c-370.006%2c117.603%2c-400.519C43.627%2c-432.518%2c-41.7%2c-428.093%2c-119.235%2c-406.077C-197.193%2c-383.941%2c-275.12%2c-344.573%2c-319.113%2c-276.513C-361.278%2c-211.282%2c-336.927%2c-126.903%2c-349.26%2c-50.216C-361.872%2c28.199%2c-408.114%2c101.352%2c-392.406%2c179.206C-374.924%2c265.854%2c-335.845%2c359.548%2c-258.1%2c401.611C-180.808%2c443.429%2c-85.837%2c410.344%2c0%2c391.512' fill='%231b2631'%3e%3c/path%3e%3cpath d='M1440 1114.212C1540.201 1094.8110000000001 1605.403 1002.915 1699.965 964.5129999999999 1825.49 913.5360000000001 2025.1219999999998 976.152 2082.3469999999998 853.35 2139.381 730.957 1960.53 619.902 1920.67 490.89 1889.402 389.688 1926.342 275.654 1875.2 182.897 1818.039 79.22300000000001 1736.37-30.77800000000002 1620.271-53.946000000000026 1504.558-77.03700000000003 1403.462 20.03200000000004 1295.2930000000001 67.173 1201.92 107.86599999999999 1098.18 129.11599999999999 1028.899 203.779 958.429 279.723 944.078 386.202 908.852 483.632 863.825 608.168 751.705 729.611 793.329 855.325 834.484 979.6220000000001 984.588 1030.829 1106.142 1079.492 1212.161 1121.935 1327.883 1135.921 1440 1114.212' fill='%23293849'%3e%3c/path%3e%3c/g%3e%3cdefs%3e%3cmask id='SvgjsMask1005'%3e%3crect width='1440' height='560' fill='white'%3e%3c/rect%3e%3c/mask%3e%3c/defs%3e%3c/svg%3e");
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
