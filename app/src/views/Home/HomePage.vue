<script setup>
import { inject } from 'vue'
import ProfileIntro from '../../components/Profile.vue';
import Education from '../../components/Education.vue';
import WorkExperience from '../../components/WorkExperience.vue';
import Skills from '../../components/Skills.vue';
import Certificates from '../../components/Certificates.vue';

const resume = inject('resume');
</script>

<template>
    <div class="home-container">
        <div class="home-group-1">
            <ProfileIntro id="profile" :user="resume.user" />
        </div>
        <div class="home-group-2">
            <Skills id="skills" :skills="resume.skills" />
            <Education id="education" :educations="resume.educations" />
            <WorkExperience id="workExperience" :work-experiences="resume.workExperiences.sort((a, b) => b.id - a.id)" />
            <Certificates id="certificates" :certificates="resume.certificates" />
        </div>
    </div>
</template>