<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { getIconPath, showIconName } from '../utils';

const props = defineProps({
    skills: Array
})

const skillTypes = []
const skillsGrouped = Object.groupBy(props.skills, ({ type }) => type);

for (const skillType in skillsGrouped) {
  skillTypes.push(skillType);
}
</script>

<template>
    <div class="c-content">
        <div class="c-header">
            <svg-icon type="mdi" :path="getIconPath('tools')" :size="35" />
            <h3>
                <pre> Skills</pre>
            </h3>
        </div>
        <ul class="c-body">
            <li v-for="skillType in skillTypes" :key="skillType">
                <p>{{ skillType }}: </p>
                <div class="skillTypes">
                    <p class="skill" v-for="skill in skillsGrouped[skillType].map(x => x.name)" :key="skill">
                        <svg-icon type="mdi" :path="getIconPath(skill)" />{{ showIconName(skill) }}
                    </p>
                </div>
            </li>
        </ul>
    </div>
</template>

<style lang="scss" scoped>
ul{
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