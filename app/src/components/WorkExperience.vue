<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { ref } from 'vue';
import SvgIcon from '@jamescoyle/vue-icon'
import { displayAddress, displayDate, getIconPath } from '../utils'

const props = defineProps({
    workExperiences: Array
});

const index = ref(0);
const length = props.workExperiences.length;

function changeWorkExperienceIndex(num){
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
            <div class="button-group">
                <button @click="changeWorkExperienceIndex(-1)"><svg-icon type="mdi" :path="getIconPath('chevronLeft')"/></button>
                <div class="button-group-info">
                    <p>{{ workExperiences[index].employer }}</p>
                    <b> {{ workExperiences[index].title }} </b>
                    <b> {{ displayDate(workExperiences[index].startDate) }} - {{ displayDate(workExperiences[index].endDate) }}</b>
                    <p>{{ index+1 }} / {{ length }}</p>
                </div>
                <button @click="changeWorkExperienceIndex(1)"><svg-icon type="mdi" :path="getIconPath('chevronRight')"/></button>
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

<style lang="scss" scoped>
.button-group {
    margin-top: 1rem;
    padding: 0rem 0.25rem;
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: hsla(0, 0, 0, 0.25);
    border-radius: 50px;

    .button-group-info {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }

    button {
        height: 2rem;
        width: 2rem;
    }

    p {
        font-size: 15px;
    }
}

.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}
</style>