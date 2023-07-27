<template>
    <section class="flex-container">
        <div class="item-wrapper">
            <h2 class="subtitle">Select theme:</h2>
            <div></div>
            <div class="setting-selector">
                <div class="little-component-dark" @click="selectTheme('dark')"
                :class="{isActive: selected === 'dark'}"
               >
                    <div class="nav-example"></div>
                    <div class="content-example"></div>
                    <div class="footer-example">
                        <div class="button-example"></div>
                    </div>
                </div>
                <div class="little-component-light" @click="selectTheme('light')"
                :class="{isActive: selected === 'light'}"
                >
                    <div class="nav-example"></div>
                    <div class="content-example"></div>
                    <div class="footer-example">
                        <div class="button-example"></div>
                    </div>
                </div>
            </div>
            <button class="apply-button main-button" @click="setTheme">Apply</button>
        </div>
    </section>
</template>
<script setup lang="ts">
import { inject, ref } from 'vue'
import { ThemeSwitcher } from '../services/themeSwitcher';
import {Emitter} from 'mitt'

const emitter:Emitter<GlobalEvents> = inject('emitter')
const switcher:ThemeSwitcher = inject('themeSwitcher')
const selected = ref<string>()

function selectTheme(theme:string) {
    if(theme === 'light'){
        selected.value = 'light'
    }
    else{
        selected.value = 'dark'
    }
}
function setTheme(){
    if(selected.value === 'light'){
        switcher.setLightTheme()
    }
    else{
        switcher.setDarkTheme()
    }
    console.log(`the user selected theme is ${selected.value}`)
    switcher.setPreference()
    emitter.emit('updateTheme')

}
</script>
<style scoped>
.flex-container {
    width: 100%;
    height: 100%;
    background-color: var(--background-color);
    color: var(--font-color-primary);
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 1rem;
}
.item-wrapper {
    width: 90%;
    height: 100%;
    
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    justify-content: center;
    gap: 1rem;
    padding: 1rem;
    background-color: var(--tertiary-color);
    border-radius: 15px;
}
.setting-selector {
    width: 100%;
    height: 100%;
    min-height: 15rem;
    display: flex;
    flex-direction: row;
    gap: 2rem;
    align-items: center;
    background-color: var(--secondary-color);
    border-radius: 15px;
    padding: 1rem   ;  
}
.little-component-dark,
.little-component-light {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    width: 15rem;
    height: 15rem;
    border-radius: 15px;
    gap: 0.5rem;
    cursor: pointer;
}
.little-component-dark {
    --primary-color: #212b3f;
    --secondary-color: #394867;
    --decline-button: #4ca0e7;;
    background-color: #131924;
}
.little-component-light {
  --primary-color: #bddcff;   
  --secondary-color: #a0ccff;
  --tertiary-color: rgb(244, 251, 255);;
  --accent-color:  #94c4f9;
  --background-color: #f4faff;
    background-color: var(--background-color);
}
.nav-example {
    width: 100%;
    height: 3rem;
    background-color: var(--primary-color);
    border-top-left-radius: 15px;
    border-top-right-radius: 15px;
}
.content-example {
    width: 90%;
    height: 5rem;
    border-radius: 5px;
    background-color: var(--secondary-color);
    
}
.footer-example {
    display: flex;
    justify-content: flex-end;
    padding: 0.5rem;
    width: 100%;
    height: 3rem;
    background-color: var(--primary-color);
    border-bottom-left-radius: 15px;
    border-bottom-right-radius: 15px;
}
.isActive {
    outline: 3px var(--approve-button) solid;
}
.button-example {
    position: relative;
    bottom: 100%;
    width: 3rem;
    height: 3rem;
    border-radius: 50%;
    background-color: var(--decline-button);
    margin-bottom: 5rem;
}
</style>zx../api/themeSwitcher