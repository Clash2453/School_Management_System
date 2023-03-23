import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import './assets/main.css'

import { OhVueIcon, addIcons } from 'oh-vue-icons'
import { BiGithub, BiFacebook, BiLinkedin, MdSchoolOutlined } from 'oh-vue-icons/icons'

addIcons(BiGithub, BiFacebook, BiLinkedin, MdSchoolOutlined)

const app = createApp(App)

app.component('v-icon', OhVueIcon)
app.use(router)

app.mount('#app')
