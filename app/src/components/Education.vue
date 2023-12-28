<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { ref } from 'vue';
import SvgIcon from '@jamescoyle/vue-icon'
import { displayAddress, displayDate, getIconPath, iconSize, headerIconSize } from '../utils'

const props = defineProps({
    educations: Array
});

const index = ref(0);
const length = props.educations.length;
const justifyContent = ref('space-between');

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

if (length > 1)
    justifyContent.value = 'space-between';
else
    justifyContent.value = 'center';

</script>

<template>
    <div class="c-container">
        <div class="c-header">
            <svg-icon type="mdi" :path="getIconPath('bookeducation')" :size="headerIconSize" />
            <h3>Education</h3>
        </div>
        <div class="c-info-container" :style="{ justifyContent: justifyContent }">
            <button v-if="length > 1" @click="changeArrayIndex(-1)"><svg-icon type="mdi" :path="getIconPath('chevronLeft')" :size="iconSize"/></button>
            <div class="c-info">
                <p> {{ educations[index].school }} </p>
                <b> {{ displayAddress(educations[index].address) }}</b>
                <b> {{ displayDate(educations[index].startDate) }} - {{ displayDate(educations[index].endDate) }}</b>
                <b> {{ educations[index].grade }} </b>
                <p v-if="length > 1">{{ index+1 }} / {{ length }}</p>
            </div>
            <button v-if="length > 1" @click="changeArrayIndex(1)"><svg-icon type="mdi" :path="getIconPath('chevronRight')" :size="iconSize"/></button>
        </div>
        <div class="c-body">
            <ul v-for="item in educations[index].educationItems" :key="item.id">
                <li> {{ item.name }} </li>
            </ul>
        </div>
    </div>
</template>