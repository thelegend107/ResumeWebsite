<script setup>
import { ref } from 'vue';
import { getUserInfo, getGravatarProfilePic, getIconPath } from '../utils';
import SvgIcon from '@jamescoyle/vue-icon';

const userLogin = ref(null);
const userImage = ref(null);

getUserInfo().then(response => {
    userLogin.value = response;
    userImage.value = getGravatarProfilePic(response.userDetails, 25);
}).catch(error => {
    console.log(error);
});
</script>

<template>
    <header>
        <div class="admin-options">
            <div class="admin-info">
                <img v-if="userImage" :src="userImage">
                <p v-if="userLogin">{{ userLogin.userDetails }}</p>
            </div>
            <div class="dropdown-options">
                <a href="#">Dashboard</a>
                <a href="#">Setting</a>
                <a href="#">Logout</a>
            </div>
        </div>
        <router-link to="/"><SvgIcon type="mdi" :path="getIconPath('home')" />HOME</router-link>

    </header>
</template>

<style lang="scss" scoped>
header {
    font-weight: 1000;
    display: flex;
    justify-content: end;
    gap: 10px;

    img {
        display: flex;
        border-radius: 100%;
    }
}

.admin-info {
    display: flex;
    gap: 5px;
}

.admin-options {
    position: relative;
}

.dropdown-options {
    margin-top: 1rem;
    position: absolute;
    border: 1px solid;
    border-radius: 10px;
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    gap: 2px;
    z-index: 1;
}
</style>

