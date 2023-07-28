<template>
    <div class="flex-container">
        <div class="profile-container">
            <div class="profile-icon-container">
                <img src="" alt="" class="profile-image">
                <button class="add-button">Change picture</button>
            </div>
            <div class="information-container">
                <div class="information-bar subtitle">
                    <p class="user-info">
                        Username: sdfiohsaodifhaosdihf
                    </p>
                </div>
                <div class="information-bar subtitle">
                    <p class="user-info">
                        Email: sdfiohsaodifhaosdihf
                    </p>
                </div>
                <div class="information-bar subtitle">
                    <p class="user-info">
                        Major: sdfiohsaodifhaosdihf
                    </p>
                </div>
                <div class="information-bar subtitle">
                    <p class="user-info">
                        Academical ID: sdfiohsaodifhaosdihf
                    </p>
                </div>
                <div class="information-bar subtitle">
                    <p class="user-info">
                        User ID: sdfiohsaodifhaosdihf
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>
<script setup lang="ts">
import { Emitter } from 'mitt';
import { ThemeSwitcher } from '../services/themeSwitcher';
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
.profile-icon-container,
.profile-container,
.flex-container,
.information-container {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    width: 100%;
    padding: 3rem;
    color: var(--font-color-primary);
}

.profile-container {
    max-width: 45rem;
    background-color: var(--primary-color);
    border-radius: 15px;
}

.add-button {
    width: 5rem;
}

.profile-icon-container {

    width: 100%;
    flex: 1;
    gap: 1rem;
    padding: 1rem;
    border-radius: 15px;
    flex-direction: column;
}

.profile-image {
    content: var(--large-user-icon);
    background-color: var(--secondary-color);
    padding: 1rem;
    border-radius: 50%;

    width: 100%;
    max-width: 20rem;
    max-height: 20rem;
}

.information-container {
    background-color: var(--secondary-color);
    border-radius: 15px;
    gap: 1rem;
}

.information-bar {
    display: flex;
    align-items: flex-start;
    justify-content: flex-start;
    width: 100%;
    background-color: var(--tertiary-color);
    padding: 0.5rem;
    border-radius: 5px;
}

.subtitle {
    word-wrap: break-word;
    white-space: pre-wrap;
    word-break: break-word;
}

@media (max-width: 500px) {

    .profile-icon-container,
    .profile-container,
    .flex-container,
    .information-container {

        padding: 1rem
    }

    .subtitle {
        font-size: 1rem;
    }
}</style>