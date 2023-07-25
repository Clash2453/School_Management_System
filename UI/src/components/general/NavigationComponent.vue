<script lang="ts">
import { defineComponent } from 'vue'
import { useUserStore } from '../../stores/UserStore'
import { mapStores } from 'pinia'
export default defineComponent ({
  data: function () {
    return {
      toggleMobile: true, 
      toggleMobileButton: false,
      extra: false
    }
  },
  computed: {
    ...mapStores(useUserStore)
  },
  methods: {
    mobileNavigation():void {
      let width = window.innerWidth
      if (width < 750) {
        this.toggleMobile = true
        this.toggleMobileButton = true
        this.emitter.emit('toggleMobile', this.toggleMobile)
        if(this.userStore.authenticationStatus){
          this.extra = true
      }
        return
      }
      this.toggleMobile = false
      this.toggleMobileButton = false
      this.extra = false 
      this.emitter.emit('toggleMobile', this.toggleMobile)
    },
    triggerMenu():void {
      this.toggleMobile = !this.toggleMobile
    }
  },
  created() {
    window.addEventListener('resize', this.mobileNavigation)
  },
  unmounted() {
    window.removeEventListener('resize', this.mobileNavigation)
  },
  mounted() { 
    this.mobileNavigation()
    this.emitter.on('toggle-extra', (toggleExtra) => {
      this.extra = toggleExtra
    })
  }
})
</script>

<template>
  <header id="header">
    <div class="wrapper">
      <div class="logo-container">
        <router-link to="/" class="nav-link">
          <img id="logo" src=".././icons/logo-no-background.svg" alt="" />
        </router-link>
      </div>
      <button v-if="toggleMobileButton" class="button-container" @click="triggerMenu">
        <span class="material-symbols-outlined"> menu </span>
      </button>
    </div>
    <nav class="nav-bar">
      <ul class="link-list">
        <li v-if="!toggleMobile">
          <router-link to="/" class="nav-link nav-list-item" >Home</router-link>
        </li>
        <li v-if="!toggleMobile">
          <router-link to="/" class="nav-link nav-list-item">About</router-link>
        </li>
        <li v-if="!toggleMobile" class="">
          <router-link to="/login" class="nav-link nav-list-item">Login</router-link>
        </li>
        <li v-if="!toggleMobile && extra">
          <router-link to="overview" class="nav-link nav-list-item">Overview</router-link>
        </li>
        <li v-if="!toggleMobile && extra">
          <router-link to="/dashboard/grades" class="nav-link nav-list-item">Grades</router-link>
        </li>
        <li v-if="!toggleMobile && extra">
          <router-link to="/dashboard/absence" class="nav-link nav-list-item">Absence</router-link>
        </li>
        <li v-if="!toggleMobile && extra">
          <router-link to="/dashboard/teachers" class="nav-link nav-list-item"
            >Teachers</router-link
          >
        </li>
      </ul>
    </nav>
  </header>
</template>
<style scoped>
.link-list,
#header,
.nav-bar,
.wrapper {
  width: 100%;
  height: 100%;

  display: flex;
  justify-content: flex-end;
  align-items: center;
}
#header {
  position: sticky;
  top: 0;
  left: 0;
  min-height: 6rem;
  background-color: var(--primary-color);
  padding: 0.5rem;
  box-sizing: border-box;
  z-index: 999;
}
.link-list {
  gap: 1rem;
}

.logo-container {
  margin-right: auto;
  padding: 0;
  border-bottom: none;
}

.logo-container:hover {
  border-bottom: none;
  background-color: transparent;
}
.button-container {
  width: 5rem;
  height: 5rem;
  color: var(--font-color-primary );
}
#logo {
  width: 5rem;
  height: 5rem;
  padding: 0;
}
.nav-list-item {
  padding: 0.25rem 1rem;
  color: var(--font-color-primary);
  border-bottom: 5px solid transparent;
}
.nav-list-item:hover {
  background-color: var(--font-color-secondary);
  color: var(--secondary-color);
  border-bottom: 5px solid var(--font-color-primary);
}
.nav-link {
  color: var(--font-color-primary);
  font-size: 1.5rem;
  font-family: 'Roboto', sans-serif;
  font-weight: 800;
}
.material-symbols-outlined {
  font-size: 3rem;
}

@media only screen and (max-width: 750px) {
  .link-list {
    flex-direction: column;
    align-items: flex-end;
    justify-content: flex-end;
  }
  #header {
    flex-direction: column;
  }
  .button-container {
    margin-bottom: auto;
    margin-left: auto;
  }
  .nav-list-item {
    font-size: 1rem;
    padding: 0;
    text-align: right;
  }

  .nav-list-item:first-child {
    font-size: 1.5rem;
  }
}
</style>
