<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import { ref } from 'vue';
import SvgIcon from '@jamescoyle/vue-icon';
import { getGravatarProfilePic, getIconPath, headerIconSize } from '../utils';

const props = defineProps({
    user: Object
});

const profilePicSize = 250;
const fullName = props.user.firstName + " " + props.user.lastName;

// Special Request :*
const profileHeartPath = ref(getIconPath('heartoutline'));
const profileHeartColor = ref(false);
function profileHeartPathToggle(){
    if (profileHeartPath.value == getIconPath('heartoutline')){
        profileHeartPath.value = getIconPath('heart');
        profileHeartColor.value = true;
    }
    else{
        profileHeartPath.value = getIconPath('heartoutline');
        profileHeartColor.value = false;
    }
}

</script>

<template>
    <div class="profile">
        <div class="profile-heart">
            <svg-icon :class="{red: profileHeartColor}" @click="profileHeartPathToggle" type="mdi" :path="profileHeartPath" :size="headerIconSize" />
        </div>
        <img alt="profile pic from gravatar based on email hash" class="profile-pic" :src="getGravatarProfilePic(user.email)" :width="profilePicSize" :height="profilePicSize" />
        <div class="name">
            <h1>{{ fullName }}</h1>
            <h2>{{ props.user.title }}</h2>
            <p>{{ props.user.description.replaceAll('<br>', ' ') }}</p>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.profile {
    width: 100%;
    text-align: center;
    display: flex;
    flex-direction: column;
    border-radius: 25px;
    box-shadow: var(--box-shadow-1);
    background-color: var(--vt-c-black);
    padding: 1rem 2rem;
    .profile-pic {
        align-self: center;
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
    text-align: right;
    cursor: pointer;
}

.red {
    color: darkred;
}
</style>