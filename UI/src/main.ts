import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import mitt from 'mitt'
import { createPinia } from 'pinia' 
import './assets/main.css'
import vSelect from 'vue-select'
import 'vue-select/dist/vue-select.css'
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
  HiSolidChartPie,
  BiTable,
  MdStickynote2Outlined,
  FaChalkboardTeacher,
  HiSolidMailOpen,
  FaUserGraduate,
  FaUniversity,
  BiArrowDownCircle
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
  HiSolidChartPie,
  BiTable,
  MdStickynote2Outlined,
  FaChalkboardTeacher,
  HiSolidMailOpen,
  FaUserGraduate,
  FaUniversity,
  BiArrowDownCircle
)
const pinia = createPinia()
const app = createApp(App)
const emitter = mitt()

app.config.globalProperties.emitter = emitter
app.provide('emitter', emitter)
app.component('v-icon', OhVueIcon)
app.component('v-select', vSelect)
app.use(pinia)
app.use(router)

app.mount('#app')
