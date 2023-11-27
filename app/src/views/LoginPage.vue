<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiApple, mdiEmail, mdiGithub, mdiKey, mdiLogin, mdiMicrosoft, mdiTwitter} from '@mdi/js'

function socialLogin(social){
    let url = "/.auth/login/" + social;
    return window.location.href = url;
}
</script>

<template>
    <div class="loginBox">
        <h1 class="h1-custom">Login.</h1>

        <div class="emailInput">
            <label for="email"><svg-icon type="mdi" :path="mdiEmail" /><pre> Email:</pre></label>
            <input v-model="email" name="email" type="email" placeholder="" />
        </div>

        <div class="passwordInput">
            <label for="password"><svg-icon type="mdi" :path="mdiKey" /><pre> Password:</pre></label>
            <input v-model="password" name="password" type="password" />
        </div>

        <button><svg-icon type="mdi" :path="mdiLogin" /><pre> Login</pre></button>
        
        <hr>
        
        <div class="loginMethods">
            <button @click="socialLogin('github')"><svg-icon type="mdi" :path="mdiGithub" /><pre> GitHub</pre></button>
            <button @click="socialLogin('aad')"><svg-icon type="mdi" :path="mdiMicrosoft" /><pre> Microsoft</pre></button>
            <button @click="socialLogin('apple')"><svg-icon type="mdi" :path="mdiApple" /><pre> Apple</pre></button>
            <button @click="socialLogin('twitter')"><svg-icon type="mdi" :path="mdiTwitter" /><pre> Twitter</pre></button>
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