<template>
    <main class="flex-container">
        <div class="container">
            <h1 class="main-title">Enter your email.</h1>
            <h2 class="instruction-text">
                To reset your password and regain control of your account, please enter the email address associated with your account in the field below:
            </h2>
            <div class="input-wrapper">
                <label for="email" class="subtitle">Email:</label>
                <input class="form-input" type="text" name="email" id="email-input">
            </div>
            <div class="button-wrapper">
                <button class="decline-button" @click="router.back()">Cancel</button>
                <button class="add-button">Submit</button>
            </div>
        </div>
    </main>
</template>
<script setup lang="ts">
import router from '../../router/index'
</script>
<style scoped>
.flex-container,
.container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    width: 100%;
    flex: 1;
    padding: 3rem;
    gap: 2rem;
    color: var(--font-color-primary);
    background-color: var(--background-color);
}

.container {
    background-color: var(--primary-color);
    max-width: 25rem;
    max-height: 35rem;
    border-radius: 15px;
}

.form-input {
    background-color: var(--tertiary-color);
    border-radius: 5px;
    font-size: 1.125rem;
    font-family: 'Montserrat', sans-serif;
    padding: 0.25rem;
    width: 100%;
    max-width: 20rem;
    color: var(--font-color-primary);
}
.button-wrapper {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    gap: 1rem;
    width: 100%;
}
.instruction-text {
    font-family: var(--main-font);
    font-size: 1rem;
}
.input-wrapper {
    width: 100%;
}
@media (max-width: 500px) {
    .flex-container
    {
        padding: 1rem;
    }
    .container {
        padding: 2rem;
    }
}
</style>