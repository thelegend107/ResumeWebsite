<script setup>
import { inject } from 'vue'
import ProfileIntro from '../components/ProfileIntro.vue';
const resume = inject('resume');
</script>

<template>
    <ProfileIntro :user="resume.user" />
</template>

<style scoped>

@media (min-width: 1024px) {
}
</style>