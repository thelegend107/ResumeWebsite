<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { inject, ref } from 'vue'
import SocialStack from './SocialStack.vue';
import SvgIcon from '@jamescoyle/vue-icon';
import { getUserInfo, getIconPath } from '../utils';

const resume = inject('resume');

const emit = defineEmits(['show-sidebar', 'close-sidebar']);

const userLogin = ref(null);
getUserInfo().then(response => {
    userLogin.value = response
}).catch(error => {
    console.log(error);
});
</script>
<template>
    <header>
        <div class="header-container-1">
            <RouterLink @click="emit('show-sidebar')" v-if="$route.name == 'Home'" to=""><svg-icon type="mdi" :path="getIconPath('menu')" /></RouterLink>
        </div>
        <div class="header-container-2">
            <SocialStack v-if="$route.name == 'Home'" :links="resume.links" />
        </div>
        <div class="header-container-3">
            <router-link v-if="$route.name != 'Home'" to="/"><svg-icon type="mdi" :path="getIconPath('home')" /></router-link>
            <router-link v-else-if="$route.name == 'Home' && !userLogin" to="/login"><svg-icon type="mdi" :path="getIconPath('loginvariant')" /></router-link>
            <a v-else href="/.auth/logout"><svg-icon type="mdi" :path="getIconPath('logoutvariant')" /></a>
        </div>
    </header>
</template>