<script setup>
import HelloWorld from './components/HelloWorld.vue'
import TheWelcome from './components/TheWelcome.vue'
import LinkedInIcon from './components/icons/IconLinkedIn.vue'
import GitHubIcon from './components/icons/IconGitHub.vue'
import EmailIcon from './components/icons/IconEmail.vue'
import DownloadIcon from './components/icons/IconDownload.vue'
</script>

<template>
  <header>
    <div>
      <a href="https://gravatar.com/mmaayoub" target="_blank" rel="noopener noreferrer"><img alt="Moe Profile" class="logo" src=".\assets\profilePicture-modified.png" width="250" height="250" /></a>
      <table class="social-stack">
        <td class="social"><a href="https://www.linkedin.com/in/mhayoub/" target="_blank" rel="noopener noreferrer"><LinkedInIcon /></a></td>
        <td class="social"><a href="https://github.com/thelegend107" target="_blank" rel="noopener noreferrer"><GitHubIcon /></a></td>
        <td class="social"><a href="mailto:mma.ayoub@outlook.com" target="_blank" rel="noopener noreferrer"><EmailIcon /></a></td>
        <td class="social"><a href="/M.Ayoub(Moe)_Resume.pdf" target="_blank" rel="noopener noreferrer" download><DownloadIcon /></a></td>
      </table>
    </div>
    <br>
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
  border-radius: 50%;
}

.social {
  padding-inline: 1rem;
} 

.social-stack {
  position: inherit;
  margin: 0 auto 2rem;
}

.social-stack td a:hover, .social-stack td a:focus {
  background-color: transparent;
}


@media (min-width: 1024px) {
  header {
    width: 100%;
    height: 100vh;
    min-height: 100vh;
    top: 0; /* this is required for "sticky" to work */
    position: sticky;
    padding-top: calc(var(--section-gap) / 2);
    padding-right: calc(var(--section-gap) / 2);
  }

  main {
    padding-top: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 1rem 0 0 8rem;
  }

  .social-stack {
    position: inherit;
    margin: 1rem 0 0 8rem;
  }

  .social {
    padding-left: 20px;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
