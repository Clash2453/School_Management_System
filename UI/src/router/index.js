import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/HomeView.vue'
import Login from '../views/LoginView.vue'
import Dashboard from '../views/DashboardView.vue'
import OverviewView from '../views/OverviewView.vue'
import GradesView from '../views/GradesView.vue'
import AbsenceView from '../views/AbsenceView.vue'
import TeachersView from '../views/TeachersView.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', component: Home },
    { path: `/dashboard`, component: Dashboard },
    { path: '/login', component: Login },
    {
      path: '/dashboard',
      component: Dashboard,
      children: [
        {
          path: 'overview',
          component: OverviewView
        },
        {
          path: 'grades',
          component: GradesView
        },
        {
          path: 'absence',
          component: AbsenceView
        },
        {
          path: 'teachers',
          component: TeachersView
        }
      ]
    }
  ]
})
export default router
