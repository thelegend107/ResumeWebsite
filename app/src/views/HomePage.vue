<script setup>
import { inject } from 'vue'
import ProfileIntro from '../components/Profile.vue';
import Education from '../components/Education.vue';
import WorkExperience from '../components/WorkExperience.vue';
import Skills from '../components/Skills.vue';

const resume = inject('resume');
</script>

<template>
    <div class="home-header">
        <div>
            <div class="home-group-1">
                <ProfileIntro :user="resume.user" />
            </div>
        </div>
        <div class="home-group-2">
            <Skills id="skills" class="skills" :skills="resume.skills" />
            <Education id="education" :educations="resume.educations" />
            <WorkExperience id="workExperience" :work-experiences="resume.workExperiences.sort((a, b) => b.id - a.id)"/>
        </div>
    </div>
</template>

<style lang="scss" scoped>

@media (min-width: 1024px) {
    .home-header {
        display: grid;
        grid-template-columns: 50% 50%;
        gap: 20px;
        width: 100%;
    }
    .home-group-1 {
        position: fixed;
        width: 515px;
    }
    .home-group-2 {
        display: flex;
        flex-direction: column;
    }
}
</style>