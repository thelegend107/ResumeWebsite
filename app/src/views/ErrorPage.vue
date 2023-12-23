<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { statusCode, getIconPath, iconSize } from '../utils';
import SvgIcon from '@jamescoyle/vue-icon';

const router = useRouter();
const h1Text = ref(statusCode[404].name);
const h3Texts = ref(statusCode[404].description);

switch (router.currentRoute.value.name) {
    case "Unauthorized":
        h1Text.value = statusCode[401].name;
        h3Texts.value = statusCode[401].description;
        break;
    case "Forbidden":
        h1Text.value = statusCode[403].name;
        h3Texts.value = statusCode[403].description;
        break;
    default:
        h1Text.value = statusCode[404].name;
        h3Texts.value = statusCode[404].description;
        break;
}
</script>

<template>
    <div class="ErrorPage">
        <h1 class="h1-custom">{{ h1Text }}</h1>
        <div>
            <h3 v-for="(t, index) in h3Texts" :key="index">{{ t }}</h3>
        </div>
        <button @click="router.push({ name: 'Home' })">
            <svg-icon type="mdi" :path="getIconPath('home')" :size="iconSize"></svg-icon>
            <pre><h3> Home</h3></pre>
        </button>
    </div>
</template>