import './assets/main.scss'

import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import axios from 'axios'

import App from './App.vue'
import AdminPage from './views/AdminPage.vue'
import HomePage from './views/HomePage.vue'
import NotFoundPage from './views/NotFoundPage.vue'
import Unauthorized from './views/UnAuthorized.vue'
import LoginPage from './views/LoginPage.vue'

const app = createApp(App);

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: "/", name: "Home", component: HomePage},
        { path: "/admin", name: "Admin", component: AdminPage},
        { path: "/login", name: "Login", component: LoginPage},
        { path: "/unauthorized", name: "Unauthorized", component: Unauthorized},
        { path: "/:notFound", name: "NotFound", component: NotFoundPage},
    ]
});

await axios.get("api/user/mma.ayoub@outlook.com")
.then(response => {
    response.data.links.push({
        id: response.data.links.length,
        userId: Math.max(response.data.links.map(x => x.userId)),
        name: "Email",
        url: "mailto:" + response.data.user.email
    });

    app.provide('resume', response.data);
    console.log(response.data);
})
.catch(err => {
    console.error(err);
})

app.use(router).mount('#app');
