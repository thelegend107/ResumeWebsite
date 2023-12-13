<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { inject, ref } from 'vue'
import { useRouter } from 'vue-router';
import SocialStack from './SocialStack.vue';
import SvgIcon from '@jamescoyle/vue-icon';
import { getUserInfo, getIconPath } from '../utils';

const router = useRouter();
const isHome = ref(true);
const isLogin = ref(false);
const resume = inject('resume');

const emit = defineEmits(['show-sidebar', 'close-sidebar']);

router.beforeEach((to) => {
    if (to.name == 'Home'){
        isHome.value = true;
        isLogin.value = false;
    }
    else if (to.name == 'Login') {
        isHome.value = false;
        isLogin.value = true;
    }
    else{
        isHome.value = false;
        isLogin.value = false;
        emit('close-sidebar');
    }
});
const userLogin = ref(null);
getUserInfo().then(response => {
    userLogin.value = response
}).catch(error => {
    console.log(error);
});
</script>
<template>
    <header v-if="isHome || isLogin">
        <div class="header-content-1">
            <RouterLink @click="emit('show-sidebar')" v-if="isHome" to=""><svg-icon type="mdi" :path="getIconPath('menu')" /></RouterLink>
        </div>
        <div class="header-content-2">
            <SocialStack v-if="isHome" class="header-content-2" :links="resume.links" />
        </div>
        <div class="header-content-3">
            <router-link v-if="!isHome" to="/"><svg-icon type="mdi" :path="getIconPath('home')" /></router-link>
            <router-link v-else-if="isHome && !userLogin" to="/login"><svg-icon type="mdi" :path="getIconPath('loginvariant')" /></router-link>
            <a v-else href="/.auth/logout'"><svg-icon type="mdi" :path="getIconPath('logoutvariant')" /></a>
        </div>
    </header>
</template>