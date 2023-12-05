<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { ref } from 'vue';
import SvgIcon from '@jamescoyle/vue-icon'
import { displayDate, getIconPath } from '../utils'

const props = defineProps({
    workExperiences: Array
});

const index = ref(0);
const length = props.workExperiences.length;

function changeArrayIndex(num){
    if (index.value == length-1 && num > 0)
        index.value = -1;
    else if (index.value == 0 && num < 0)
        index.value = length;

    if (num > 0)
        index.value++;
    else
        index.value--;
}

</script>

<template>
    <div class="c-content">
        <div class="c-header">
            <svg-icon type="mdi" :path="getIconPath('briefcase')" :size="35" />
            <h3><pre> Work Experience</pre></h3>
        </div>
        <div>
            <div class="c-info">
                <button @click="changeArrayIndex(-1)"><svg-icon type="mdi" :path="getIconPath('chevronLeft')"/></button>
                <div class="c-info-content">
                    <p>{{ workExperiences[index].employer }}</p>
                    <b> {{ workExperiences[index].title }} </b>
                    <b> {{ displayDate(workExperiences[index].startDate) }} - {{ displayDate(workExperiences[index].endDate) }}</b>
                    <p>{{ index+1 }} / {{ length }}</p>
                </div>
                <button @click="changeArrayIndex(1)"><svg-icon type="mdi" :path="getIconPath('chevronRight')"/></button>
            </div>
            <div class="c-body">
                <ul v-for="item in workExperiences[index].workExperienceItems" :key="item.id">
                    <li> {{ item.description }} </li>
                </ul>
                <br>
            </div>
        </div>
    </div>
</template>