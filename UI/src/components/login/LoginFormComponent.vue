<script lang="ts">
import axios from 'axios'
import router from '../../router'
import { mapStores } from 'pinia'
import { useUserStore } from '../../stores/UserStore'
import { iconFill } from '../../GlobalVariables'
export default {
  data: function () {
    return {
      login: true,
      pageTwoActive: false,
      firstName: '',
      lastName: '',
      loginEmail: '',
      loginPassword: '',
      registerEmail: '',
      registerPassword: '',
      confirmationPassword: '',
      institutionName: '',
    }
  },
  computed: {
    ...mapStores(useUserStore)
  },
  methods: {
    /** 
    Sets registration page as active
    */
    toggleRegister() {
      this.login = false
    },
    toggleLogin() {
      this.login = true
    },
    async loginUser() {
      console.log(this.userEmail)
      const data = 
      {
        email: this.loginEmail,
        password: this.loginPassword
      }

      if(this.loginEmail === '')
      {
        return
      }
      
      if(this.loginPassword === ''){
        return
      }

      const response = await axios(
        {
        method: 'POST',
        url: 'https://localhost:7080/api/User/login',
        data: data,
        headers: {
          'Content-Type': 'application/json'
        },
        withCredentials: true
      })
      console.log(response.status)
      if (response.status == 200) 
      {
        console.log(response.data.userRole)
        this.userStore.authenticateUser()
        this.userStore.setRole(response.data.userRole)
        this.emitter.emit('user-logged', response.data.userId)

        switch (response.data.userRole) {
          case 'Admin':
            router.push(`dashboard/admin/overview`)
            break
          case 'Student':
            router.push(`dashboard/student/overview`)
            break
          case 'Teacher':
            router.push(`dashboard/teachers`)
            break
          case 'Guest':
            router.push(`/waiting`)
            break
        }
        return
      }
    },
    async registerUser() 
    {
      console.log(this.userEmail)
      const data = 
      {
        name: `${this.firstName} ${this.lastName}`,
        email: this.registerEmail,
        password: this.registerPassword
      }
      const result = await axios(
        {
        method: 'POST',
        url: 'https://localhost:7080/api/User/register',
        data: data,
        headers: 
          {
            'Content-Type': 'application/json'
          }
      }).catch((e) => console.log(e))
      if (result.status == 201) 
      {
        router.push(`/waiting`)
      }
      console.log(result)
      console.log(data.name)
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
      <button :class="{ active: !login, inactive: login }" class="right-radius" @click="toggleRegister">
        Register
      </button>
    </div>
    <form v-if="login" class="form" v-on:submit.prevent="onSubmit">
      <h1 class="main-title">Login</h1>
      <div class="label-wrapper">
        <label class="input-label" for="email">Email</label>
        <input v-model="loginEmail" class="form-input" type="email" name="email" required @keypress.enter.prevent />
      </div>
      <div class="label-wrapper">
        <label class="input-label" for="">Password</label>
        <input v-model="loginPassword" class="form-input" type="password" name="password" required
          @keypress.enter.prevent />
      </div>
      <div class="button-wrapper">
        <button class="add-button" @click="loginUser">Log in</button>
        <router-link to="/reset-password" class="password-link">Forgotten password?</router-link>
      </div>
    </form>


    <!-- Registration form -->


    <form v-if="!login" class="form" v-on:submit.prevent="onSubmit">
      <div class="flex-container" v-if="!pageTwoActive">
        <h1 class="main-title">Register</h1>
        <div class="label-wrapper">
          <label class="input-label" for="name">First name:</label>
          <input class="form-input" v-model="firstName" type="name" name="firstName" required @keypress.enter.prevent />
        </div>
        <div class="label-wrapper">
          <label class="input-label" for="name">Last name:</label>
          <input class="form-input" v-model="lastName" type="name" name="lastName" required @keypress.enter.prevent />
        </div>
        <div class="label-wrapper">
          <label class="input-label" for="email">Email</label>
          <input class="form-input" v-model="registerEmail" type="email" name="email" required @keypress.enter.prevent />
        </div>
        <div class="button-wrapper">
          <button class="add-button arrow-button" @click="pageTwoActive = true">
          <v-icon name="md-keyboardarrowright-round" scale="2.5" :fill="this.iconFill" />
          </button>
          <button class="password-link" @click="toggleLogin">Already have an account?</button>
        </div>
      </div>



      <!-- Page two of registration  -->
      

      <div class="flex-container" v-if="pageTwoActive">
        <h1 class="main-title">Step-2</h1>
        <div class="label-wrapper">
          <label class="input-label" for="name">School name:</label>
          <input class="form-input" v-model="institutionName" type="name" name="firstName" required @keypress.enter.prevent />
        </div>
        <div class="label-wrapper">
          <label class="input-label" for="name">Password:</label>
          <input class="form-input" v-model="registerPassword" type="password" name="password" required
              @keypress.enter.prevent />
        </div>
        <div class="label-wrapper">
          <label class="input-label" for="email">Confirm password:</label>
          <input class="form-input" v-model="confirmationPassword" type="email" name="email" required @keypress.enter.prevent />
        </div>
        <div class="button-wrapper">
          <button class="add-button" @click="registerUser">Register</button>
          <button class="decline-button arrow-button " @click="pageTwoActive = false">
          <v-icon name="md-keyboardarrowleft-round" scale="2.5" :fill="this.iconFill" />
          
          </button>

        </div>
      </div>
    </form>
  </section>
</template>
<style scoped>
#form-section,
.form,
.flex-container {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
}
.flex-container {
  width: 100%;
  gap: 1rem;
  flex: 1;
}

#form-section {
  width: 60%;
  flex: 1;
  object-fit: fill;

  flex: auto;
  background-color: var(--dashboard-background);
  padding: 2rem;
  background-image: var(--login-image);
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
  height: 80%;
  max-width: 25rem;
}

.form {
  min-height: 30rem;

  gap: 1rem;
  padding: 2rem;
  background-color: var(--secondary-color);
  color: var(--font-color-primary);
  border-bottom-left-radius: 5px;
  border-bottom-right-radius: 5px;
}

.form-input {
  background-color: var(--tertiary-color);
  border-radius: 5px;
  font-size: 1.125rem;
  font-family: 'Montserrat', sans-serif;
  padding: 0.25rem;
  width: 100%;
  max-width: 20rem;
  color: var(--font-color-primary);
}

.form-input:focus {
  outline: 2px solid var(--secondary-color);
}

.input-label {
  font-family: 'Roboto', sans-serif;
  font-size: 1.125rem;
  text-align: left;
  width: 100%;
  max-width: 20rem;
  color: var(--font-color-primary);
}

.password-link {
  text-decoration: underline;
  text-align: left;
}

.button-wrapper {
  width: 90%;
  max-width: 20rem;
  display: flex;
  flex-direction: row-reverse;
  align-items: center;
  justify-content: space-between;
  font-family: 'Montserrat', sans-serif;
  font-weight: 500;
}
.arrow-button {
  padding: 0;
  width: 3rem;
  height: 3rem;
  border-radius: 50%;
}

.label-wrapper {
  width: 90%;
  display: flex;
  flex-direction: column;
}

.active,
.inactive {
  width: 100%;
  color: var(--font-color-primary);
  font-size: 1.25rem;
  font-family: 'Roboto', sans-serif;
  padding: 1rem;
}

.tab-container {
  display: flex;
  justify-content: center;
  flex-direction: row;
  height: 10%;
}

.left-radius {
  border-top-left-radius: 5px;
}

.right-radius {
  border-top-right-radius: 5px;
}

.active {
  background-color: var(--secondary-color);
}

.inactive {
  background-color: var(--accent-color);
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
