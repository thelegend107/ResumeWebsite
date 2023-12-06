<script setup>
import { ref } from 'vue'
import Header from './components/Header.vue';
import SideBar from './components/SideBar.vue';
import { getUserInfo } from './utils';

const userLogin = ref(null);
const sideBarWidth = ref("0px");

function showSidebar() { sideBarWidth.value = "300px"};
function collapseSidebar() { sideBarWidth.value = "0px"};

getUserInfo().then(response => {
    userLogin.value = response
}).catch(error => {
    console.log(error);
});
</script>

<template>
    <Header @collapse-sidebar="collapseSidebar()" @show-sidebar="showSidebar()"></Header>
    <SideBar @collapse-sidebar="collapseSidebar()" :width="sideBarWidth"></SideBar>
    <main>
        <router-view></router-view>
    </main>
</template>
