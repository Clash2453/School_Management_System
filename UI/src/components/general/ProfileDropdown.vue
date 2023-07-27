<template>
    <div class="flex-container">
        <div class="icon-container">
            <h2 class="container">Username placeholder</h2>
            <img src="" alt="" class="profile-image">
        </div>
        <div class="icon-container container">
            <h2 class="institution-name container">Edit profile </h2>
            <v-icon name="md-arrowforwardios-round" scale="1.5" :fill="iconFill"></v-icon>
        </div>
        <div class="button-container container">
            <button  class="log-out">Log
                out <v-icon name="ri-logout-box-r-line" scale="1.5"></v-icon></button>
        </div>
    </div>
</template>
<script setup lang="ts">
import { Emitter } from 'mitt';
import { ThemeSwitcher } from '../../services/themeSwitcher';
import { ref, inject, onMounted } from 'vue'

const themeSwitcher: ThemeSwitcher = inject('themeSwitcher')
const emitter: Emitter<GlobalEvents> = inject('emitter')
const iconFill = ref<string>()

onMounted(() => {
    iconFill.value = themeSwitcher.getIconFill()
    emitter.on('updateTheme', () => {
        iconFill.value = themeSwitcher.getIconFill()
    })
})
</script>
<style scoped>
.flex-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-evenly;
    color: var(--font-color-primary);
    background-color: var(--secondary-color);
    font-family: var(--main-font);
    padding: 1rem;
    gap: 1rem;
    width: 20rem;
    height: 17rem;
    border-radius: 5px;
}

.container,
.icon-container {
    width: 100%;
    height: 100%;
    display: flex;
    align-items: center;
    max-height: 3rem;
    border-radius: 5px;
}
.container {
    background-color: var(--accent-color);
    padding: 0.5rem;

}
.icon-container {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    /* max-height: 4rem; */

}
.icon-container .container {
    width: 80%;
}
.log-out {
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: space-between;
}
.log-out:hover {
    color: var(--decline-button);
}
.profile-image {
    content: var(--user-icon);
}
</style>