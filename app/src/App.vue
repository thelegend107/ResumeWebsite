<script setup>
import { inject, ref } from 'vue'
import { useRouter } from 'vue-router';
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiHome, mdiLoginVariant, mdiMenu } from '@mdi/js'

import SideBar from './components/SideBar.vue';
import SocialStack from './components/SocialStack.vue';

const router = useRouter();
const isHome = ref(true);
const sideBarWidth = ref("0px");
const resume = inject('resume');

function showSidebar() { sideBarWidth.value = "300px"};
function collapseSidebar() { sideBarWidth.value = "0px"};

router.beforeEach((to) => {
    if (to.name == 'Home')
        isHome.value = true;
    else{
        isHome.value = false;
        collapseSidebar();
    }

});
</script>

<template>
    <header>
        <div class="links">
            <RouterLink @click="showSidebar()" v-if="isHome" to=""><svg-icon class="icon" type="mdi" :path="mdiMenu" /></RouterLink>
        </div>
        <SocialStack :links="resume.links" />
        <div class="userLogin">
            <RouterLink v-if="!isHome" to="/"><svg-icon class="icon" type="mdi" :path="mdiHome" /></RouterLink>
            <RouterLink v-if="isHome" to="/login"><svg-icon class="icon" type="mdi" :path="mdiLoginVariant" /></RouterLink>
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