<script setup>
const props = defineProps({
    user: Object
});

const profilePicSize = 250;
const fullName = props.user.firstName + " " + props.user.lastName;
</script>

<template>
    <div class="profile">
        <img class="profile-pic" src="..\..\public\profilePicture-modified.png" :width="profilePicSize" :height="profilePicSize" />
        <div class="name">
            <h1>{{ fullName }}</h1>
            <h2>{{ props.user.title }}</h2>
            <p>{{ props.user.description.replaceAll('<br>', ' ') }}</p>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.profile {
    text-align: center;
    .profile-pic {
        border: 4px solid;
        border-color: var(--primary);
        border-radius: 100%;
    }
    .name {
        h1 {
            font-size: 45px;
        }
        p {
            padding-top: 1rem;
            text-align: left;
        }
    }
}
</style>