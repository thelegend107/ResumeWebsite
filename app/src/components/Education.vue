<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { displayAddress, displayDate, getIconPath } from '../utils'

defineProps({
    educations: Array
});
</script>

<template>
    <div class="c-content">
        <div class="c-header">
            <svg-icon class="icon" type="mdi" :path="getIconPath('bookeducation')" :size="35" />
            <h3><pre> Education</pre></h3>
        </div>
        <div class="c-body">
            <div v-for="edu in educations" :key="edu.id">
                <div class="c-info">
                    <b> {{ edu.school }} </b>
                    <b> {{ edu.grade }} </b>
                </div>
                <div class="c-info">
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