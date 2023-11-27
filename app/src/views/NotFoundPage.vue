<script setup>
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiHome } from '@mdi/js'
import { useRouter } from 'vue-router';

const router = useRouter();

function goToHomePage(){
    router.push({ name: "Home" });
}
</script>

<template>
    <div class="NotFound">
        <h1 class="h1-custom">404.</h1>
        <div>
            <h3>The requested route was not found.</h3>
            <h3>Go home you are drunk.</h3>
        </div>
        <button @click="goToHomePage()">
            <svg-icon type="mdi" :path="mdiHome" :size="20"></svg-icon>
            <pre><h3> Home</h3></pre>
        </button>
    </div>
</template>

<style lang="scss" scoped>
.NotFound {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
  height: 70vh;

  button {
    margin: 1rem;
    width: 8rem;
  }
}
</style>