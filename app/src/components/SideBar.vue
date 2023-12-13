<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiClose } from '@mdi/js'
import { scrollMeTo, iconSize } from '../utils';

defineProps({
    width: String
})

const emit = defineEmits(['collapse-sidebar']);

function sidebarRedirect(elementId){
    emit('collapse-sidebar');
    scrollMeTo(elementId);
}

</script>

<template>
    <div class="overlay" :style="{width: width!='0px'?'100vw':'0vw'}"></div>
    <div class="sidebar" :style="{width: width}">
        <div v-if="width != '0px'">
            <div class="sidebar-header">
                <h4>Moe Ayoub - Online Resume</h4>
                <svg-icon class="mdiClose" @click="emit('collapse-sidebar')" type="mdi" :path="mdiClose" :size="iconSize"></svg-icon>
            </div>
            <ul>
                <li @click="sidebarRedirect('profile')">Profile</li>
                <li @click="sidebarRedirect('skills')">Skills</li>
                <li @click="sidebarRedirect('education')">Eduction</li>
                <li @click="sidebarRedirect('workExperience')">Work Experience</li>
                <li @click="sidebarRedirect('certificates')">Certificates</li>
            </ul>
        </div>
    </div>

</template>

<style lang="scss" scoped>
.sidebar-header {
    display: flex;
    justify-content: space-between;
    padding: 1rem 1rem;
    background-color: var(--primary);
    color: black;

    border-top-right-radius: 10px;

    .mdiClose {
        display: flex;
        cursor: pointer;
    }
}

hr {
    border-color: var(--primary);
}

ul {
    list-style: none;
    padding: 1rem 0rem;
    li {
        padding: 1rem 2rem;
    }
    
    li:hover, .active {
        color: var(--primary);
        font-weight: 700;
        cursor: pointer;
        border-bottom: 1px solid var(--primary);
    }
}

.sidebar {
    background-color: var(--vt-c-black);
    float: left;
    position: fixed;
    z-index: 1;
    top: 0;
    left: 0;
    bottom: 0;

    width: 120px;
    height: 100vh;
    transition: all 0.75s ease;

    box-shadow: var(--box-shadow-1);

    display: flex;
    flex-direction: column;
}

.overlay {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  z-index: 1;
  background-color: rgba(0,0,0,0.9);
}
</style>