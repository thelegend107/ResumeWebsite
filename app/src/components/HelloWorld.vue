<script setup>
defineProps({
  msg: {
    type: String,
    required: true
  }
})
</script>

<template>
  <div class="greetings">
    <h1 class="electricPurple">{{ msg }}</h1>
    <h2 class="electricPurple">
      Software Developer
    </h2>
      Electrical Engineer graduate of South Dakota State University (SDSU) with 4 years of diversified experience and strong software development skills including in-depth knowledge of Software Development Life Cycle and practical experience with SCRUM and Agile Software Development Model.
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  position: relative;
  top: -10px;
}

h2 {
  font-weight: 500;
  font-size: 1.2rem;
  position: relative;
  top: -10px;
}

h3 {
  font-size: 1.2rem;
}

.greetings h1,
.greetings p,
.greetings h2,
.greetings h3 {
  text-align: center;
}

@media (min-width: 1024px) {
  .greetings h1,
  .greetings p,
  .greetings h2,
  .greetings h3 {
    text-align: left;
  }
}
</style>
