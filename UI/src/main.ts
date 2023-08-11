import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import mitt, { Emitter} from 'mitt'
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
  BiArrowDownCircle,
  FaCog,
  IoEllipseSharp,
  RiLogoutBoxRLine,
  MdArrowforwardiosRound,
  MdKeyboardarrowrightRound,
  MdKeyboardarrowleftRound
} from 'oh-vue-icons/icons'
import { ErrorHandlingService } from './services/ErrorHandlingService'

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
  MdKeyboardarrowrightRound,
  MdKeyboardarrowleftRound,
  FaChalkboardTeacher,
  HiSolidMailOpen,
  FaUserGraduate,
  FaUniversity,
  BiArrowDownCircle,
  FaCog,
  IoEllipseSharp,
  RiLogoutBoxRLine,
  MdArrowforwardiosRound
)
const pinia = createPinia()
const app = createApp(App)
const emitter:Emitter = mitt()

import { applyTheme } from './GlobalVariables'
applyTheme()

app.config.globalProperties.emitter = emitter
app.provide('emitter', emitter)
app.provide('errorHandler', ErrorHandlingService)
app.component('v-icon', OhVueIcon)
app.component('v-select', vSelect)
app.use(pinia)
app.use(router)

app.mount('#app')
