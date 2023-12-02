<script setup>
import { inject } from 'vue'
import ProfileIntro from '../components/Profile.vue';
import Education from '../components/Education.vue';
import WorkExperience from '../components/WorkExperience.vue';
const resume = inject('resume');
</script>

<template>
    <ProfileIntro :user="resume.user" />
    <Education :educations="resume.educations" />
    <WorkExperience :work-experiences="resume.workExperiences" />
</template>

<style scoped>

@media (min-width: 1024px) {
}
</style>