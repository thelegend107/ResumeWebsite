<script setup>
import { inject } from 'vue'
import SocialStack from './components/SocialStack.vue';
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiHome, mdiLoginVariant, mdiMenu } from '@mdi/js'

const resume = inject('resume');
</script>

<template>
    <header>
        <div class="links">
            <RouterLink v-if="$route.name == 'Home'" to=""><svg-icon class="icon" type="mdi" :path="mdiMenu" /></RouterLink>
        </div>
        <div class="userLogin">
            <RouterLink v-if="$route.name != 'Home'" to="/"><svg-icon class="icon" type="mdi" :path="mdiHome" /></RouterLink>
            <RouterLink v-if="$route.name == 'Home'" to="/login"><svg-icon class="icon" type="mdi" :path="mdiLoginVariant" /></RouterLink>
        </div>
    </header>
    <main>
        <router-view></router-view>
    </main>
    <footer v-if="$route.name == 'Home'">
        <SocialStack :links="resume.links" />
    </footer>
</template>

<style scoped>
.links {
    display: flex;
    justify-content: left;
}

.userLogin {
    display: flex;
    justify-content: right;
}
</style>