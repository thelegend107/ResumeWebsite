<script setup>
import { ref } from 'vue'
import Header from '../../components/Header.vue';
import SideBar from '../../components/SideBar.vue';

const sideBarWidth = ref("0px");

function showSidebar() { sideBarWidth.value = "300px"};
function collapseSidebar() { sideBarWidth.value = "0px"};
</script>

<template>
    <div class="background-image"></div>
    <Header @collapse-sidebar="collapseSidebar()" @show-sidebar="showSidebar()"></Header>
    <SideBar @collapse-sidebar="collapseSidebar()" :width="sideBarWidth"></SideBar>
    <main>
        <router-view></router-view>
    </main>
</template>