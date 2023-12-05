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
        <h1 class="h1-custom">Login.</h1>
        <div class="loginMethods">
            <button @click="socialLogin('aad')"><svg-icon type="mdi" :path="mdiMicrosoft" /><pre> Microsoft</pre></button>
            <button @click="socialLogin('github')"><svg-icon type="mdi" :path="mdiGithub" /><pre> GitHub</pre></button>
        </div>
    </div>
</template>

<style lang="scss" scoped>

.loginBox {
    width: 100%;
    display: grid;
    grid-template-columns: 100%;
    gap: 1rem;
    padding: 0rem 2rem;
    box-shadow: var(--box-shadow-1);
    border-radius: 50px;

    label, input {
        padding-bottom: 0.25rem;
    }

    h1 {
        text-align: center;
    }

    padding-bottom: -4.5rem;
}

.emailInput, .passwordInput {
    display: flex;
    flex-direction: column;
}

.loginMethods {
    button {
        margin-bottom: 1rem;
        width: 100%;
    }
}
</style>