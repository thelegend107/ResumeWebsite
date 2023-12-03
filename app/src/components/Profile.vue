<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { ref } from 'vue';
import SvgIcon from '@jamescoyle/vue-icon';
import { mdiHeart, mdiHeartOutline } from '@mdi/js';
import { getGravatarProfilePic } from '../utils';

const props = defineProps({
    user: Object
});

const profilePicSize = 250;
const fullName = props.user.firstName + " " + props.user.lastName;

// Special Request :*
const profileHeartPath = ref(mdiHeartOutline);
const profileHeartColor = ref(false);
function profileHeartPathToggle(){
    if (profileHeartPath.value == mdiHeartOutline){
        profileHeartPath.value = mdiHeart;
        profileHeartColor.value = true;
    }
    else{
        profileHeartPath.value = mdiHeartOutline;
        profileHeartColor.value = false;
    }
}

</script>

<template>
    <div class="profile">
        <div class="profile-heart">
            <svg-icon :class="{red: profileHeartColor}" @click="profileHeartPathToggle" type="mdi" :path="profileHeartPath" :size="35" />
        </div>
        <img class="profile-pic" :src="getGravatarProfilePic(user.email)" :width="profilePicSize" :height="profilePicSize" />
        <div class="name">
            <h1>{{ fullName }}</h1>
            <h2>{{ props.user.title }}</h2>
            <p>{{ props.user.description.replaceAll('<br>', ' ') }}</p>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.profile {
    text-align: center;
    border-radius: 25px;
    box-shadow: var(--box-shadow-1);
    padding: 1rem 2rem;
    .profile-pic {
        border: 4px solid;
        border-color: var(--primary);
        border-radius: 100%;
    }
    .name {
        h1 {
            font-size: 45px;
        }
        p {
            padding-top: 1rem;
            text-align: left;
        }
    }
}

.profile-heart {
    display: flex;
    justify-content: right;
    cursor: pointer;
}

.red {
    color: darkred;
}
</style>