<script setup>
import { inject } from 'vue'
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiAccount, mdiLinkedin, mdiGithub, mdiFilePdfBox, mdiEmailOutline } from '@mdi/js'

const resumeAPI = inject('resume');
</script>

<template>
  <header>
    <div>
      <img alt="Moe Profile" class="logo" src=".\assets\profilePicture-modified.png" width="250" height="250" />
      <table class="social-stack">
        <td class="social"><a href="https://gravatar.com/mmaayoub" target="_blank" rel="noopener noreferrer"><svg-icon type="mdi" :path="mdiAccount" :size="25" /></a></td>
        <td class="social"><a href="https://www.linkedin.com/in/mhayoub/" target="_blank" rel="noopener noreferrer"><svg-icon type="mdi" :path="mdiLinkedin" :size="25" /></a></td>
        <td class="social"><a href="https://github.com/thelegend107" target="_blank" rel="noopener noreferrer"><svg-icon type="mdi" :path="mdiGithub" :size="25" /></a></td>
        <td class="social"><a href="mailto:mma.ayoub@outlook.com" target="_blank" rel="noopener noreferrer"><svg-icon type="mdi" :path="mdiEmailOutline" :size="25" /></a></td>
        <td class="social"><a href="/M.Ayoub(Moe)_Resume.pdf" target="_blank" rel="noopener noreferrer" download><svg-icon type="mdi" :path="mdiFilePdfBox" :size="25" /></a></td>
      </table>
    </div>
  </header>
  <main>
  </main>
</template>

<style scoped>

@media (min-width: 1024px) {
}
</style>
