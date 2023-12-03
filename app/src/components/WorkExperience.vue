<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiBriefcase  } from '@mdi/js'
import { displayAddress, displayDate } from '../utils'

defineProps({
    workExperiences: Array
});
</script>

<template>
    <div class="work-content">
        <div class="work-heading">
            <svg-icon class="icon" type="mdi" :path="mdiBriefcase" :size="35" />
            <h3>
                <pre> Work Experience</pre>
            </h3>
        </div>
        <div v-for="work in workExperiences" :key="work.id">
            <div class="work-body">
                <div class="work-info">
                    <b> {{ work.employer }} </b>
                    <b> {{ work.title }} </b>
                </div>
                <div class="work-info">
                    <b> {{ displayAddress(work.address) }}</b>
                    <b> {{ displayDate(work.startDate) }} - {{ displayDate(work.endDate) }}</b>
                </div>
                <ul v-for="item in work.workExperienceItems" :key="item.id">
                    <li> {{ item.description }} </li>
                </ul>
            </div>
        </div>
    </div>
</template>