<script setup>
import { inject, ref } from 'vue'
import { useRouter } from 'vue-router';

import SvgIcon from '@jamescoyle/vue-icon';
import SideBar from './components/SideBar.vue';
import SocialStack from './components/SocialStack.vue';
import { getUserInfo, getIconPath } from './utils';

const resume = inject('resume');
const isHome = ref(true);
const sideBarWidth = ref("0px");
const userLogin = ref(null);
const router = useRouter();

function showSidebar() { sideBarWidth.value = "300px"};
function collapseSidebar() { sideBarWidth.value = "0px"};

router.beforeEach((to) => {
    if (to.name == 'Home'){
        isHome.value = true;
    }
    else{
        isHome.value = false;
        collapseSidebar();
    }
});

getUserInfo().then(response => {
    userLogin.value = response
}).catch(error => {
    console.log(error);
});
</script>

<template>
    <header>
        <div class="links">
            <RouterLink @click="showSidebar()" v-if="isHome" to=""><svg-icon type="mdi" :path="getIconPath('menu')" /></RouterLink>
        </div>
        <SocialStack :links="resume.links" />
        <div class="userLogin">
            <RouterLink v-if="!isHome" to="/"><svg-icon type="mdi" :path="getIconPath('home')" /></RouterLink>
            <RouterLink v-else-if="isHome && !userLogin" to="/login"><svg-icon type="mdi" :path="getIconPath('loginvariant')" /><pre> Login</pre></RouterLink>
            <a v-else href="/.auth/logout"><svg-icon  type="mdi" :path="getIconPath('logoutvariant')" /><pre> Logout</pre></a>
        </div>
    </header>
    <SideBar @collapse-sidebar="collapseSidebar()" :width="sideBarWidth" />
    <main>
        <router-view></router-view>
    </main>
</template>

<style scoped>
.bottom-pad {
    padding-bottom: 4.5rem;
}

.links {
    display: flex;
    justify-content: left;
}

.userLogin {
    display: flex;
    justify-content: right;
}
</style>