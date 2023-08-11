<template>
    <div class="flex-container container">
        <div class="tall-container container">
            <img src="" alt="" class="institution-logo">
            <h1 class="institution-name main-title">Technical University sofia</h1>
            <div class="-info-container"></div>
        </div>
        <div class="content-container container" id="field-1">aaaaaa</div>
        <div class="content-container container" id="field-2"></div>
    </div>

</template>
<script setup lang="ts"></script>
<style scoped>

.grid-container {
    width: 100%;
    height: calc(100vh - 13rem);
    display: flex;
    align-items: center;
    gap: 1rem;
    background: var(--background-color);
}
.container {
    padding: 1rem;
    color: var(--font-color-primary);
    font-family: 'Lato', sans-serif;
}
.tall-container,
.content-container {
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    flex-grow: 1;
    border-radius: 0.9375rem;
    background: var(--primary-color);
    flex-shrink: 0;
}
.tall-container{
    grid-column: 1;
    grid-row: 1 / span 2;
}
#field-1{
    grid-column: 2;
    grid-row: 1;
}
#field-2{
    grid-column: 2;
    grid-row: 2;
}
.institution-logo{}
.content-container{}
</style>