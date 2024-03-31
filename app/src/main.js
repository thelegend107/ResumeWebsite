import './assets/main.scss'

import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import axios from 'axios'

import App from './App.vue'
import AdminApp from './views/Admin/AdminApp.vue'
import AdminHomePage from './views/Admin/AdminHomePage.vue'
import HomeApp from './views/Home/HomeApp.vue'
import HomePage from './views/Home/HomePage.vue'
import LoginPage from './views/Home/LoginPage.vue'
import ErrorPage from './views/ErrorPage.vue'

const app = createApp(App);

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: "/", name: "HomeApp", component: HomeApp, children: [
                { path: "/", name: "Home", component: HomePage },
                { path: "/login", name: "Login", component: LoginPage },
            ]
        },
        {
            path: "/admin", name: "AdminApp", component: AdminApp, children: [
                { path: "/admin", name: "AdminHome", component: AdminHomePage }
            ]
        },
        { path: "/unauthorized", name: "Unauthorized", component: ErrorPage },
        { path: "/forbidden", name: "Forbidden", component: ErrorPage },
        { path: "/:notFound", name: "NotFound", component: ErrorPage },
    ]
});

await axios.get("api/userResume/mma.ayoub@outlook.com")
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
