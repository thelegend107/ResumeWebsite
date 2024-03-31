<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { getIconPath, showIconName, uniqueArray, headerIconSize, iconSize } from '../utils';
import IconNextJs from './Icons/IconNextJs.vue'
import IconNuxtJs from './Icons/IconNuxtJs.vue'

const props = defineProps({
    skills: Array
})

const skillTypes = uniqueArray(props.skills.map(x => x.type));

</script>

<template>
    <div class="c-container">
        <div class="c-header">
            <svg-icon type="mdi" :path="getIconPath('tools')" :size="headerIconSize" />
            <h3>
                Skills
            </h3>
        </div>
        <ul class="c-body">
            <li v-for="skillType in skillTypes" :key="skillType">
                <p>{{ skillType }}: </p>
                <div class="skillTypes">
                    <p class="skill" v-for="skill in skills.filter(x => x.type == skillType).map(x => x.name)" :key="skill">
                        <IconNextJs v-if="skill.toLowerCase() == 'next.js'" />
                        <IconNuxtJs v-else-if="skill.toLowerCase() == 'nuxt.js'" />
                        <svg-icon v-else type="mdi" :path="getIconPath(skill)" :size="iconSize" />{{ showIconName(skill) }}
                    </p>
                </div>
            </li>
        </ul>
    </div>
</template>

<style lang="scss" scoped>
ul {
    list-style: none;
    padding: 0;
}

.skillTypes {
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    padding: 0 0 1rem 0;
    column-gap: 5px;
    row-gap: 5px;
    pointer-events: none;

    .skill {
        display: flex;
        align-items: center;
        justify-content: center;
        font-weight: 600;

        background-color: var(--primary);
        background-image: linear-gradient(45deg, var(--primary), var(--primaryV));
        box-shadow: var(--box-shadow-1);
        color: black;
        padding: 3px 10px 3px 5px;
        border-radius: 50px;
        column-gap: 10px;
    }
}
</style>