<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiAccount, mdiLinkedin, mdiGithub, mdiFilePdfBox, mdiLink, mdiEmail } from '@mdi/js'

defineProps({
    links: Array
})

const iconSize = 25;

// Dynamically retrieve link icon
function retrieveIconPath(linkName){
    let path = mdiLink;
    if (!linkName){
        return path;
    }

    linkName = linkName.trim().toLowerCase();

    switch (linkName) {
        case "linkedin":
            path = mdiLinkedin;
            break;
        
        case "github":
            path = mdiGithub;
            break;

        case "gravatar":
            path = mdiAccount;
            break;

        case "pdf":
            path = mdiFilePdfBox;
            break;
        
        case "email":
            path = mdiEmail;
            break;
    
        default:
            break;
    }

    return path;
}
</script>

<template>
    <div class="social-stack">
        <a v-for="link in links" :key="link.id" :href="link.url" target="_blank" rel="noopener noreferrer">
            <svg-icon type="mdi" :path="retrieveIconPath(link.name)" :size="iconSize" />
        </a>
    </div>
</template>

<style lang="scss" scoped>
.social-stack {
    display: flex;
    justify-content: space-between;
}
</style>