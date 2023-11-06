<script setup>
import HelloWorld from './components/HelloWorld.vue'
import TheWelcome from './components/TheWelcome.vue'
</script>

<template>
  <header>
    <img alt="Moe Profile" class="logo" src=".\assets\profilePicture-modified.png" width="250" height="250" />

    <div class="wrapper">
      <HelloWorld msg="Moe Ayoub" />
    </div>
  </header>

  <main>
    <TheWelcome />
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
  border: 3px solid hsla(273, 98%, 60%, 1);
  border-radius: 50%
}

@media (min-width: 1024px) {
  header {
    display: flex;
    padding-top: calc(var(--section-gap) / 2);
    padding-right: calc(var(--section-gap) / 2);
  }

  main {
    padding-top: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
