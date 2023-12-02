<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiClose } from '@mdi/js'

defineProps({
    width: String
})

</script>

<template>
    <div class="sidebar" :style="{width: width}">
        <div class="sidebarContent" v-if="width != '0px'">
            <div class="sidebar-header">
                <h4>Moe Ayoub - Online Resume</h4>
                <svg-icon class="mdiClose" @click="$emit('collapse-sidebar')" type="mdi" :path="mdiClose" :size="25"></svg-icon>
            </div>
            <ul>
                <li :class="{ active: $route.name == 'Home' }">Profile</li>
                <li :class="{ active: $route.name == 'Home' }">Eduction</li>
                <li :class="{ active: $route.name == 'Home' }">Work Experience</li>
                <li :class="{ active: $route.name == 'Home' }">Skills</li>
                <li :class="{ active: $route.name == 'Home' }">Certificates</li>
                <li :class="{ active: $route.name == 'Home' }">Other</li>
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
    transition: all 0.3 ease;
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

.sidebarItems {
    display: flex;
    flex-direction: column;
}

.sidebar {
    background-color: var(--vt-c-black);
    float: left;
    position: absolute;
    z-index: 1;
    top: 0;
    left: 0;
    bottom: 0;

    width: 120px;
    transition: all 0.75s ease;

    box-shadow: var(--box-shadow-1);

    display: flex;
    flex-direction: column;
}

.overlay {
  display: none;
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  z-index: 1;
  background-color: rgba(0,0,0,0.9);
}
</style>