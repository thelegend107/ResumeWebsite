<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { ref } from 'vue';
import SvgIcon from '@jamescoyle/vue-icon'
import { displayAddress, displayDate, getIconPath } from '../utils'

const props = defineProps({
    educations: Array
});

const index = ref(0);
const length = props.educations.length;

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
            <svg-icon class="icon" type="mdi" :path="getIconPath('bookeducation')" :size="35" />
            <h3><pre> Education</pre></h3>
        </div>
        <div class="c-body">
            <div class="c-info">
                <button @click="changeArrayIndex(-1)"><svg-icon type="mdi" :path="getIconPath('chevronLeft')"/></button>
                <div class="c-info-content">
                    <p> {{ educations[index].school }} </p>
                    <b> {{ displayAddress(educations[index].address) }}</b>
                    <b> {{ displayDate(educations[index].startDate) }} - {{ displayDate(educations[index].endDate) }}</b>
                    <b> {{ educations[index].grade }} </b>
                    <p>{{ index+1 }} / {{ length }}</p>
                </div>
                <button @click="changeArrayIndex(1)"><svg-icon type="mdi" :path="getIconPath('chevronRight')"/></button>
            </div>
            <ul v-for="item in educations[index].educationItems" :key="item.id">
                <li> {{ item.name }} </li>
            </ul>
        </div>
    </div>
</template>