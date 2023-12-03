<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiBookEducation } from '@mdi/js'
import { displayAddress, displayDate } from '../utils'

defineProps({
    educations: Array
});
</script>

<template>
    <div class="edu-content">
        <div class="edu-heading">
            <svg-icon class="icon" type="mdi" :path="mdiBookEducation" :size="35" />
            <h3><pre> Education</pre></h3>
        </div>
        <div class="edu-body">
            <div class="edu-item" v-for="edu in educations" :key="edu.id">
                <div class="edu-info">
                    <b> {{ edu.school }} </b>
                    <b> {{ edu.grade }} </b>
                </div>
                <div class="edu-info">
                    <b> {{ displayAddress(edu.address) }}</b>
                    <b> {{ displayDate(edu.startDate) }} - {{ displayDate(edu.endDate) }}</b>
                </div>
                <ul v-for="item in edu.educationItems" :key="item.id">
                    <li> {{ item.name }} </li>
                </ul>
            </div>
        </div>
    </div>
</template>