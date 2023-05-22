import { createRouter, createWebHistory } from 'vue-router'
import { useUserStore } from '../stores/UserStore.js'
import Home from '../views/HomeView.vue'
import Login from '../views/LoginView.vue'
import Dashboard from '../views/DashboardView.vue'
import OverviewView from '../views/StudentOverviewView.vue'
import GradesView from '../views/GradesView.vue'
import AbsenceView from '../views/AbsenceView.vue'
import TeachersView from '../views/TeachersView.vue'
import ErrorComponent from '../components/general/ErrorComponent.vue'
import WaitingPage from '../views/WaitingApprovalView.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: Home,
      meta: {
        requiresAuthentication: false
      }
    },
    {
      path: '/waiting',
      component: WaitingPage,
      meta: {
        requiresAuthentication: false
      }
    },
    {
      path: `/dashboard`,
      component: Dashboard,
      meta: {
        requiresAuthentication: false
      }
    },
    {
      path: '/login',
      component: Login,
      meta: {
        requiresAuthentication: false
      }
    },
    {
      path: '/dashboard/',
      component: Dashboard,
      meta: {
        requiresAuthentication: true
      },
      children: [
        {
          path: 'overview',
          component: OverviewView,
          meta: {
            requiresAuthentication: true
          }
        },
        {
          path: 'grades',
          component: GradesView,
          meta: {
            requiresAuthentication: true
          }
        },
        {
          path: 'absence',
          component: AbsenceView,
          meta: {
            requiresAuthentication: true
          }
        },
        {
          path: 'teachers',
          component: TeachersView,
          meta: {
            requiresAuthentication: true
          }
        }
      ]
    }
  ]
})

router.beforeEach((to, from, next) => {
  if (to.matched.some((page) => page.meta.requiresAuthentication)) {
    const store = useUserStore()

    if (!store.authenticationStatus)
      next({
        path: '/login',
        component: Login
      })
    else next()
  } else next()
})
export default router
