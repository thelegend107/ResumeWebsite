import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import axios from 'axios'

const resume = await axios.get("api/user/mma.ayoub@outlook.com");

const app = createApp(App);

app.provide('resume', resume);

app.mount('#app');
