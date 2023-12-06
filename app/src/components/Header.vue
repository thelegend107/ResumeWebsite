<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { inject, ref } from 'vue'
import { useRouter } from 'vue-router';
import SocialStack from './SocialStack.vue';
import SvgIcon from '@jamescoyle/vue-icon';
import { getIconPath } from '../utils';

const router = useRouter();
const isHome = ref(true);
const resume = inject('resume');

const emit = defineEmits(['show-sidebar', 'close-sidebar']);

router.beforeEach((to) => {
    if (to.name == 'Home'){
        isHome.value = true;
    }
    else{
        isHome.value = false;
        emit('close-sidebar');
    }
});
</script>
<template>
    <header>
        <div>
            <RouterLink @click="emit('show-sidebar')" v-if="isHome" to=""><svg-icon type="mdi" :path="getIconPath('menu')" /></RouterLink>
        </div>
        <SocialStack :links="resume.links" />
        <div>
            <RouterLink v-if="!isHome" to="/"><svg-icon type="mdi" :path="getIconPath('home')" /></RouterLink>
            <RouterLink v-else-if="isHome && !userLogin" to="/login"><svg-icon type="mdi" :path="getIconPath('loginvariant')" /></RouterLink>
            <a v-else href="/.auth/logout"><svg-icon  type="mdi" :path="getIconPath('logoutvariant')" /></a>
        </div>
    </header>
</template>