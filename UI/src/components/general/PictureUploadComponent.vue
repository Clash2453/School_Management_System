<template>
    <div class="input-container">
        <input type="file" name="profile-picture" id="profile-picture" class="file-input" accept=".jpg, .jpeg, .png"
            @change="onFileChange">
        <label for="profile-picture" class="file-label">Choose a file</label>
        <div id="preview">
            <img v-if="fileUrl" :src="fileUrl" id="profile-preview" />
        </div>
        <div class="row-container">
            <button class="decline-button" @click="emitter.emit('closeDialogue')">Close</button>
            <button class="add-button" @click="submitProfilePicture()">Submit</button>
        </div>

    </div>
</template>
<script setup lang="ts">
import {ref, inject} from 'vue'
import {Emitter} from 'mitt';
import { uploadProfilePicture } from '../../api/apiService';
const fileUrl = ref<string>() 

const emitter: Emitter<{ closeDialogue: string }> = inject('emitter')
const picture = new FormData()
defineProps<{'state':boolean}>()
function onFileChange (e) {
    const file = e.target.files[0];
    fileUrl.value = URL.createObjectURL(file);
    if(picture.entries.length === 1)
        picture.delete('profile-picture')
    
    picture.append('userFile', file)
}
function submitProfilePicture(){
    uploadProfilePicture(picture)
}
</script>
<style scoped>
.input-container {
    position: fixed;
    top: calc(50% + 4rem);
    left: calc(50% + 7rem);
    transform: translate(-50%, -50%);

    background-color: var(--accent-color);
    width: 20rem;
    height: 20rem;
    border-radius: 15px;

    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;

    gap: 0.5rem;
}

.row-container {
    display: flex;
    align-items: center;
    justify-content: center;
    width: 100%;
    padding: 0.5rem;
    gap: 1rem;
}

.file-input {
    width: 0.1px;
    height: 0.1px;
    opacity: 0;
    overflow: hidden;
    position: absolute;
    z-index: -1;
}

.file-label {
    font-size: 1.25em;
    font-weight: 600;
    color: var(--font-color-primary);
    font-family: var(--main-font);
    background-color: var(--approve-button);
    display: inline-block;
    padding: 0.5rem;
    border-radius: 5px;
}

.file-input:focus+.file-label,
.file-input+.file-label:hover {
    background-color: var(--approve-button-hover);
}

.file-label {
    cursor: pointer;
    /* "hand" cursor */
}

.file-input:focus+.file-label {
    outline: 1px dotted #000;
    outline: -webkit-focus-ring-color auto 5px;
}

.file-input+.file-label * {
    pointer-events: none;
}
#preview {
    width: 10rem;
    height: 10rem;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: var(--secondary-color);
    padding: 1rem;
    border-radius: 5px;
}
#profile-preview {
    border-radius: 50%;
}
.decline-button,
.add-button {
    width: 4.375rem;
}
@media (max-width: 750px) {
    .flex-container {
        left: 50%;
        bottom: 50%;
    }
}</style>