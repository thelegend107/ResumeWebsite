<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { inject, ref } from 'vue'
import { useRouter } from 'vue-router';
import SocialStack from './SocialStack.vue';
import SvgIcon from '@jamescoyle/vue-icon';
import { getUserInfo, getIconPath } from '../utils';

const router = useRouter();
const isHome = ref(true);
const resume = inject('resume');

const emit = defineEmits(['show-sidebar', 'close-sidebar']);

function goToHomePage(){
    router.push({ name: "Home" });
};

router.beforeEach((to) => {
    if (to.name == 'Home'){
        isHome.value = true;
    }
    else{
        isHome.value = false;
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
    <header>
        <div>
            <RouterLink @click="emit('show-sidebar')" v-if="isHome" to=""><svg-icon type="mdi" :path="getIconPath('menu')" /></RouterLink>
        </div>
        <SocialStack :links="resume.links" />
        <div>
            <a v-if="!isHome" href=""><svg-icon @click="goToHomePage()" type="mdi" :path="getIconPath('home')" /></a>
            <a v-else-if="isHome && !userLogin" href=""><svg-icon @click="router.push({ name: 'Login' })" type="mdi" :path="getIconPath('loginvariant')" /></a>
            <a v-else href=""><svg-icon @click="router.push('/.auth/logout')" type="mdi" :path="getIconPath('logoutvariant')" /></a>
        </div>
    </header>
</template>