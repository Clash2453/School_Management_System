import { defineStore } from 'pinia'

export const useUserStore = defineStore('user', {
  state: () => ({
    isAuthenticated: false
  }),
  getters: {
    authenticationStatus(state) {
      return state.isAuthenticated
    }
  },
  actions: {
    authenticateUser() {
      this.isAuthenticated = true
    }
  }
})
