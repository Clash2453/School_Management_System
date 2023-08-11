<template>
    <div class="section-container">
        <div class="tab-container">
            <button class="tab tab-left" @click="activePanel = 'institution'"
                :class="{ active: activePanel === 'institution' }">Schools and Universities</button>
            <button class="tab tab-right" @click="activePanel = 'individual'"
                :class="{ active: activePanel === 'individual' }">Individual accounts</button>
        </div>
        <div class="flex-container" v-if="activePanel === 'institution'">
            <div class="flex-container-column">
                <h2 class="main-title">Is your organization ready to revolutionize its management and elevate student
                    outcomes? </h2>
                <p class="info-paragraph">
                    We welcome educational institutions, whether universities or schools,
                    to join our platform and experience the benefits of
                    streamlined management. To initiate the registration process,
                    kindly reach out to us through email or give us a call.
                    Our dedicated team is eager to assist you in
                    getting started and ensuring a seamless integration
                    tailored to your institution's needs.
                    Let's embark on this educational journey together!
                </p>
            </div>
            <div class="flex-container-column">
                <h2 class="main-title contact-title">Contact us:</h2>
                <div class="contact-card">
                    <v-icon />
                    <h2 class="subtitle">schoolItegration@gmail.com</h2>
                </div>
                <div class="contact-card">
                    <v-icon />
                    <h2 class="subtitle">phone number for schools</h2>
                </div>
            </div>
        </div>
        <div class="flex-container" v-if="activePanel === 'individual'">
            <div class="flex-container-column">
                <h2 class="main-title">Eager to take your learning to the next level, even if your organization hasn't
                    adopted our platform?</h2>
                <p class="info-paragraph">

                    We've got great news for you! Students can still tap into the power of our cutting-edge software
                    evaluation algorithms. Craft your own educational journey by joining our vibrant community with a
                    personalized account. While you take the reins on data entry, our algorithms illuminate your path with
                    insights and progress tracking. Ready to supercharge your learning?
                </p>
            </div>
            <div class="flex-container-column">
                <h2 class="main-title contact-title">Contact us:</h2>
                <div class="contact-card">
                    <v-icon />
                    <h2 class="subtitle">individualIntegration@gmail.com</h2>
                </div>
                <div class="contact-card">
                    <v-icon />
                    <h2 class="subtitle">phone number for students</h2>
                </div>
            </div>
        </div>
    </div>
</template>
<script setup lang="ts">
import { ref } from 'vue'
const activePanel = ref('institution')
</script>
<style scoped>
.flex-container,
.section-container,
.flex-container-column {
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 2rem;
    background-color: var(--background-color);
    width: 100%;
    height: 100%;
    min-height: 25rem;
    color: var(--font-color-primary);
    font-family: var(--main-font);
}

.section-container {
    flex-direction: column;
}

.flex-container-column {
    flex-direction: column;
    background-color: var(--primary-color);
    gap: 1rem;
    justify-content: space-evenly;
    align-items: flex-start;
}


.flex-container {
    border-bottom-left-radius: 15px;
    border-bottom-right-radius: 15px;
    background-color: var(--primary-color);
}

.tab-container {
    display: flex;
    align-items: center;
    border-top-left-radius: 15px;
    border-top-right-radius: 15px;
    width: 100%;
    height: 100%;
}

.tab {
    width: 100%;
    height: 100%;
    padding: 0.5rem;
    font-size: 1.4rem;
    background-color: var(--secondary-color);
}

.tab-left {
    border-top-left-radius: 15px;
}

.tab-right {
    border-top-right-radius: 15px;
}

.active {
    background-color: var(--primary-color);
}

.info-paragraph {
    width: 100%;
    font-family: 'Lato', sans-serif;
    font-size: 1.125rem;
}

.main-title {
    font-size: 1.8rem;
}

.contact-title {
    font-size: 2rem;
}

.contact-card {
    padding: 0.5rem;
    min-width: 22rem;
    overflow-wrap: break-word;
    display: flex;
    align-items: center;
    background-color: var(--approve-button);
    font-family: 'Lato', sans-serif;
    font-size: 1rem;
    border-radius: 5px;
}

.subtitle {
    width: 100%;
    text-align: center;
}

@media (max-width: 875px) {
    .flex-container {
        flex-wrap: wrap;
    }

    .flex-container,
    .flex-container-column {
        padding: 0.5rem;
    }
    .flex-container-column {
        align-items: center;
    }
    .contact-card {
        min-width: unset;
        max-width: 15rem; 
   }
   .contact-title {
    text-align: center;
   }
}
</style>
