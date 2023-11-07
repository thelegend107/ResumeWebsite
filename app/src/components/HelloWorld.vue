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
      <!-- Electrical Engineer graduate of South Dakota State University (SDSU) with 4 years of diversified experience and strong software development skills including in-depth knowledge of Software Development Life Cycle and practical experience with SCRUM and Agile Software Development Model. -->
      As a Software Developer at Raven Industries, I was the product owner and main contributor to our E-Commerce web site for the Agricultural Division. I also integrated our web site, CRM, ERP, and IT ticketing systems using various technologies, such as C#, Azure, Boomi, and Oracle. 
      <br><br> I graduated from South Dakota State University with a BSEE degree in 2020, where I designed and built a device that can reconfigure the network settings of display controllers for Daktronics. I have a strong background in electrical and electronics engineering, as well as object-oriented programming and web development. I am passionate about creating innovative and user-friendly solutions that enhance the performance and efficiency of complex systems.
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
