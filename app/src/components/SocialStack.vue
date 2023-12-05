<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { getIconPath } from '../utils';

defineProps({
    links: Array
})

const iconSize = 25;
</script>

<template>
    <div class="social-stack">
        <a v-for="link in links" :key="link.id" :href="link.url" target="_blank" rel="noopener noreferrer">
            <svg-icon class="links" type="mdi" :path="getIconPath(link.name)" :size="iconSize" />
        </a>
    </div>
</template>

<style lang="scss" scoped>
.social-stack {
    display: flex;
    justify-content: center;
    .links {
        width: 100%;
        padding: 0 1.25vw;
    }
}
</style>