<script>
import axios from 'axios'
export default {
  data: function () {
    return {
      login: true,
      userName: '',
      userEmail: '',
      userPassword: ''
    }
  },
  methods: {
    toggleRegister() {
      this.login = false
    },
    toggleLogin() {
      this.login = true
    },
    async loginUser() {
      console.log(this.userEmail)
      const data = {
        email: this.userEmail,
        password: this.userPassword
      }
      const token = await axios({
        method: 'POST',
        url: 'https://localhost:7080/api/User/login',
        data: data,
        headers: {
          'Content-Type': 'application/json'
        }
      }).catch((e) => console.log(e))
      console.log(token)
    },
    logger() {
      console.log(this.userEmail)
    }
  }
}
</script>
<template>
  <section id="form-section">
    <div class="tab-container">
      <button :class="{ active: login, inactive: !login }" class="left-radius" @click="toggleLogin">
        Login
      </button>
      <button
        :class="{ active: !login, inactive: login }"
        class="right-radius"
        @click="toggleRegister"
      >
        Register
      </button>
    </div>
    <form v-if="login" class="form" v-on:submit.prevent="onSubmit">
      <h1 class="main-title">Login</h1>
      <div class="label-wrapper">
        <label class="input-label" for="email">Email</label>
        <input v-model="userEmail" class="form-input" type="email" name="email" required />
      </div>
      <div class="label-wrapper">
        <label class="input-label" for="">Password</label>
        <input
          v-model="userPassword"
          @input="logger"
          class="form-input"
          type="password"
          name="password"
          required
        />
      </div>
      <div class="button-wrapper">
        <button class="hero-main-button" @click="loginUser">Log in</button>
        <router-link to="/change-password" class="password-link">Forgotten password?</router-link>
      </div>
    </form>

    <form v-if="!login" class="form" action="">
      <h1 class="main-title">Register</h1>
      <div class="label-wrapper">
        <label class="input-label" for="name">First and Last name:</label>
        <input class="form-input" type="name" name="userName" required />
      </div>
      <div class="label-wrapper">
        <label class="input-label" for="email">Email</label>
        <input class="form-input" type="email" name="email" required />
      </div>
      <div class="label-wrapper">
        <label class="input-label" for="">Password</label>
        <input class="form-input" type="password" name="password" required />
      </div>
      <div class="button-wrapper">
        <button class="hero-main-button">Log in</button>
        <router-link to="/Register" class="password-link">Forgotten password?</router-link>
      </div>
    </form>
  </section>
</template>
<style scoped>
#form-section,
.form {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
}

#form-section {
  width: 60%;
  height: 100%;
  min-height: 100vh;
  object-fit: fill;

  flex: auto;
  background-color: #0e2a47;
  padding: 2rem;
  background-image: url('../components/icons/login-background.svg');
}
.main-title {
  text-align: left;
  width: 90%;
  max-width: 20rem;
  padding: 0.25rem;
}
.tab-container,
.form {
  width: 100%;
  height: 100%;
  max-width: 25rem;
}
.form {
  min-height: 30rem;

  gap: 1rem;
  padding: 2rem;
  background-color: #113255;
  color: white;
  border-bottom-left-radius: 5px;
  border-bottom-right-radius: 5px;
}
.form-input {
  background-color: #e5eef5;
  border-radius: 5px;
  font-size: 1.125rem;
  font-family: 'Montserrat', sans-serif;
  padding: 0.25rem;
  width: 100%;
  max-width: 20rem;
  color: #0e2a47;
}
.form-input:focus {
  outline: 3px solid #3c88da;
}
.input-label {
  font-family: 'Roboto', sans-serif;
  font-size: 1.125rem;
  text-align: left;
  width: 100%;
  max-width: 20rem;
  color: white;
}
.password-link {
  text-decoration: underline;
}
.button-wrapper {
  width: 90%;
  height: 100%;
  max-width: 20rem;
  display: flex;
  flex-direction: row-reverse;
  align-items: center;
  justify-content: space-between;
  font-family: 'Montserrat', sans-serif;
  font-weight: 500;
}
.label-wrapper {
  width: 90%;
  display: flex;
  flex-direction: column;
}
.active,
.inactive {
  width: 100%;
  color: white;
  font-size: 1.25rem;
  font-family: 'Roboto', sans-serif;
  padding: 1rem;
  /* border-top-right-radius: 5px;
  border-top-left-radius: 5px; */
}
.tab-container {
  display: flex;
  justify-content: center;
  flex-direction: row;
}
.left-radius {
  border-top-left-radius: 5px;
}
.right-radius {
  border-top-right-radius: 5px;
}
.active {
  background-color: #2a619b;
}
.inactive {
  background-color: #204872;
}
@media (max-width: 1250px) {
  #form-section {
    width: 100%;
  }
}
@media (max-width: 350px) {
  #form-section {
    padding: 0;
    min-height: fit-content;
  }
  .form {
    max-width: 100%;
    padding: 0.5rem;
    background-image: url('../components/icons/login-background.svg');
  }
}
</style>
