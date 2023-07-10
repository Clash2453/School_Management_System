import { defineStore } from 'pinia'

export const useUserStore = defineStore('user', {
  state: () => ({
    isAuthenticated: false,
    role: 'guest'
  }),
  getters: {
    authenticationStatus(state) {
      return state.isAuthenticated
    },
    getRole(state) {
      return state.role
    }
  },
  actions: {
    authenticateUser() {
      this.isAuthenticated = true
    },
    setRole(newRole: string) {
      this.role = newRole
    }
  }
})
