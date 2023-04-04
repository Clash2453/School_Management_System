<script>
export default {
  data: function () {
    return {
      toggleMobile: true,
      toggleMobileButton: false
    }
  },
  methods: {
    mobileNavigation() {
      let width = window.innerWidth
      if (width < 500) {
        this.toggleMobile = true
        this.toggleMobileButton = true
        return
      }
      this.toggleMobile = false
      this.toggleMobileButton = false
    },
    triggerMenu() {
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
  }
}
</script>

<template>
  <header id="header">
    <div class="wrapper">
      <div class="logo-container" @click="triggerMenu">
        <router-link to="/" class="nav-link">
          <img id="logo" src="./icons/logo-no-background.svg" alt="" />
        </router-link>
      </div>
      <button v-if="toggleMobileButton" class="button-container" @click="triggerMenu">
        <span class="material-symbols-outlined"> menu </span>
      </button>
    </div>
    <nav class="nav-bar">
      <ul class="link-list">
        <li v-if="!toggleMobile" class="nav-list-item">
          <router-link to="/" class="nav-link" id="logo">Home</router-link>
        </li>
        <li v-if="!toggleMobile" class="nav-list-item">
          <router-link to="/" class="nav-link">About</router-link>
        </li>
        <li v-if="!toggleMobile" class="nav-list-item">
          <router-link to="Login" class="nav-link">Login</router-link>
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
  background-color: #2a619b;
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
  color: white;
}
#logo {
  width: 5rem;
  height: 5rem;
  padding: 0;
}
.nav-list-item {
  padding: 0.25rem 1rem;
  color: white;
  border-bottom: 5px solid transparent;
}
.nav-list-item:hover {
  background-color: white;
  color: #00617e;
  border-bottom: 5px solid #00c08d;
}
.nav-link {
  color: inherit;
  font-size: 1.5rem;
  font-family: 'Roboto', sans-serif;
  font-weight: 800;
}
.material-symbols-outlined {
  font-size: 3rem;
}

@media only screen and (max-width: 500px) {
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
  }

  .nav-list-item:first-child {
    font-size: 1.5rem;
  }
}
</style>
