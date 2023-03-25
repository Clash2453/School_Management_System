<script>
import LoginFormComponent from '../components/LoginFormComponent.vue'

export default {
  data: function () {
    return {
      loginImage: '/images/login/map-1.svg',
      counter: 1
    }
  },
  methods: {
    cycle() {
      if (this.counter === 8) {
        this.counter = 0
      }
      this.counter++
      this.loginImage = `/images/login/map-${this.counter}.svg`
      setTimeout(this.cycle, 2000)
      return
    }
  },
  components: {
    LoginFormComponent
  },
  mounted() {
    this.cycle()
  }
}
</script>

<template>
  <main class="flex-container">
    <div class="solid-color">
      <h1 class="main-title">Welcome</h1>
      <p class="subtitle">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Ad tenetur repudiandae sit, dolorum
        deleniti asperiores id animi nesciunt accusamus illo in.
      </p>
      <img :src="loginImage" alt="A map of the world" class="login-image" />
    </div>
    <LoginFormComponent></LoginFormComponent>
  </main>
</template>

<style scoped>
.flex-container {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  color: white;
}
.main-title {
  text-align: center;
  font-size: 3.5rem;
}
.solid-color {
  background-color: #0e2a47;
  display: flex;
  justify-content: flex-start;
  align-items: center;
  flex-direction: column;
  width: 100%;
  height: 100%;
  min-height: 100vh;
  padding: 2rem;
}
.subtitle {
  width: 80%;
  text-align: center;
}
.login-image {
  object-fit: contain;
}
@media (max-width: 1250px) {
  .flex-container {
    flex-direction: column-reverse;
  }
}
</style>
