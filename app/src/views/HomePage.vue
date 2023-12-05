<script setup>
import { inject } from 'vue'
import ProfileIntro from '../components/Profile.vue';
import Education from '../components/Education.vue';
import WorkExperience from '../components/WorkExperience.vue';
import Skills from '../components/Skills.vue';
import Certificates from '../components/Certificates.vue';

const resume = inject('resume');
</script>

<template>
    <div class="home-content">
        <div class="home-header">
            <div class="home-group-1">
                <ProfileIntro id="profile" :user="resume.user" />
            </div>
            <div class="home-group-2">
                <Skills id="skills" class="skills" :skills="resume.skills" />
                <Education id="education" :educations="resume.educations" />
                <WorkExperience id="workExperience" :work-experiences="resume.workExperiences.sort((a, b) => b.id - a.id)"/>
                <Certificates id="certificates" :certificates="resume.certificates" />
            </div>
        </div>
    </div>

</template>

<style lang="scss" scoped>

@media (min-width: 1024px) and (min-height: 788px) {
    .home-content {
        display: flex;
    }
    .home-header {
        display: grid;
        grid-template-columns: 50% 50%;
        gap: 20px;
    }
    .home-group-1 {
        position: sticky;
        top: 4.563rem;
        height: 80vh;
        box-sizing: border-box;
    }
    .home-group-2 {
        display: flex;
        flex-direction: column;
        justify-content: left;
    }
}
</style>