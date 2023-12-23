<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { displayDate, getIconPath, headerIconSize } from '../utils'

defineProps({
    certificates: Array
})

</script>

<template>
    <div class="c-container">
        <div class="c-header">
            <svg-icon type="mdi" :path="getIconPath('certificate')" :size="headerIconSize" />
            <h3><pre> Certificates</pre></h3>
        </div>
        <div class="c-body">
            <div class="card-container">
                <div v-for="cert in certificates" :key="cert.id">
                    <a class="c-card" :href="cert.url" target="_blank" rel="noopener noreferrer">
                        <p>{{ cert.name }}</p>
                        <p v-if="cert.certificateId"><b>Certificate ID:</b> {{ cert.certificateId }}</p>
                        <p><b>Issued By:</b> {{ cert.issuedBy }}</p>
                        <p><b>Issue Date:</b> {{ displayDate(cert.issueDate) }}</p>
                    </a>
                </div>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
a {
    color: inherit;
    :hover{
        color: inherit;
    }
}

.card-container {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 10px;
    transition: all 0.3s ease;
}

.c-card {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 1rem 1.5rem;
    border-radius: 50px;
    border: 1px solid;
}

.c-card:hover {
    background-color: var(--primary);
    background-image: linear-gradient(45deg, var(--primary), var(--primaryV));
    color: white;
    box-shadow: var(--box-shadow-1);
    border: 1px solid black;

    b {
        color: black;
    }
}
</style>