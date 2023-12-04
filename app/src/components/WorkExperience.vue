<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { displayAddress, displayDate, getIconPath } from '../utils'

defineProps({
    workExperiences: Array
});
</script>

<template>
    <div class="c-content">
        <div class="c-header">
            <svg-icon type="mdi" :path="getIconPath('briefcase')" :size="35" />
            <h3>
                <pre> Work Experience</pre>
            </h3>
        </div>
        <div v-for="work in workExperiences" :key="work.id">
            <div class="c-body">
                <div class="c-info">
                    <b> {{ work.employer }} </b>
                    <b> {{ work.title }} </b>
                </div>
                <div class="c-info">
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