<template>
    <div class="flex-container">
        <div class="profile-container">
            <div class="profile-icon-container">
                <img :src="pictureSource" alt="" class="profile-image">
                <button class="add-button" @click="showUploadPrompt = !showUploadPrompt">Change picture</button>
            </div>
            <PictureUpload :state="showUploadPrompt" v-if="showUploadPrompt"></PictureUpload>
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
import {ref, inject, onMounted } from 'vue'
import PictureUpload from '../../components/general/PictureUploadComponent.vue';
import { fetchProfilePicture } from '../../api/apiService';

const style = getComputedStyle(document.body)
const pictureSource = ref<string>(style.getPropertyValue('--large-user-icon')) 
console.log(pictureSource.value)
const emitter: Emitter<{
    toggleMobile:string,
    updateTheme:string,
    closeDialogue:string
}> = inject('emitter')  

const showUploadPrompt = ref<boolean>()

onMounted(async () => {
    pictureSource.value = await fetchProfilePicture()

    if (pictureSource.value === '') {
        pictureSource.value = style.getPropertyValue('--large-user-icon')
        console.log(pictureSource.value)
    }
    emitter.on('closeDialogue', () => {
        showUploadPrompt.value = false
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
    background-color: var(--secondary-color);
    padding: 1rem;
    border-radius: 50%;

    width: 100%;
    aspect-ratio: 1;
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
}
</style>