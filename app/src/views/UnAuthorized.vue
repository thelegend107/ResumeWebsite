<script setup>
import SvgIcon from '@jamescoyle/vue-icon';
import { mdiHome } from '@mdi/js';
import { useRouter } from 'vue-router';

const router = useRouter();
function goToHomePage(){
    router.push({ name: "Home" });
};
</script>
<template>
    <div class="Unauthorized">
        <h1 class="h1-custom">401: Unauthorized</h1>
        <div>
            <h3>You don't have permissions for this page. Please check your login info and permissions and try again.</h3>
            <h3>Go home.</h3>
        </div>
        <button @click="goToHomePage()">
            <svg-icon type="mdi" :path="mdiHome" :size="25"></svg-icon>
            <pre><h3> Home</h3></pre>
        </button>
    </div>
</template>