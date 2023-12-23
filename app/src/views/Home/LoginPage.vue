<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiGithub, mdiMicrosoft} from '@mdi/js'

function socialLogin(social){
    let url = "/.auth/login/" + social;
    return window.location.href = url;
}
</script>

<template>
    <div class="loginBox">
        <div class="login-container">
            <h1 class="h1-custom">Login.</h1>
            <button @click="socialLogin('aad')"><svg-icon type="mdi" :path="mdiMicrosoft" /><pre> Microsoft</pre></button>
            <button @click="socialLogin('github')"><svg-icon type="mdi" :path="mdiGithub" /><pre> GitHub</pre></button>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.login-container {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    box-shadow: var(--box-shadow-1);
    background-color: var(--vt-c-black);
    gap: 20px;
    border-radius: 25px;
    width: 550px;
    padding: 2rem;
    button {
        width: 100%;
    }
}

.loginBox {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-wrap: wrap;
    height: 80vh;
}
</style>