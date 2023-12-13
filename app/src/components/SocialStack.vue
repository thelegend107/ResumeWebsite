<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { getIconPath, iconSize } from '../utils';

defineProps({
    links: Array
})

</script>

<template>
    <div class="social-stack">
        <a v-for="link in links" :key="link.id" :href="link.url" target="_blank" rel="noopener noreferrer">
            <svg-icon type="mdi" :path="getIconPath(link.name)" :size="iconSize" />
        </a>
    </div>
</template>