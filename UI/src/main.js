import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import mitt from 'mitt'
import { createPinia } from 'pinia'
import './assets/main.css'

import { OhVueIcon, addIcons } from 'oh-vue-icons'
import {
  BiGithub,
  BiFacebook,
  BiLinkedin,
  MdSchoolOutlined,
  MdAccounttreeOutlined,
  MdSupportagent,
  CoChartLine,
  HiClipboardList,
  BiCalendar2Week,
  MdWeb,
  HiSolidChartPie
} from 'oh-vue-icons/icons'

addIcons(
  BiGithub,
  BiFacebook,
  BiLinkedin,
  MdSchoolOutlined,
  MdAccounttreeOutlined,
  MdSupportagent,
  CoChartLine,
  HiClipboardList,
  BiCalendar2Week,
  MdWeb,
  HiSolidChartPie
)
const pinia = createPinia()
const app = createApp(App)
const emitter = mitt()
app.config.globalProperties.emitter = emitter
app.provide('emitter', emitter)
app.component('v-icon', OhVueIcon)
app.use(pinia)
app.use(router)

app.mount('#app')
