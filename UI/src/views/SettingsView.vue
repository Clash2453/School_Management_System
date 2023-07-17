<template>
<section class="flex-container">
    <!-- <div class="setting-wrapper"> -->
        <div class="item-wrapper">
        <h2 class="subtitle">Select theme:</h2>
        <div></div>
            <div class="setting-selector">
                <div class="little-component-dark">
                        <div class="nav-example"></div>
                        <div class="content-example"></div>
                        <div class="footer-example">
                            <div class="button-example"></div>
                        </div>
                    </div>
            </div>
            <button class="apply-button main-button">Apply</button>
        </div>
    <!-- </div> -->
</section>
</template>
<script setup lang="ts">
import SidebarComponent from '../components/userDashboard/SidebarComponent.vue'
</script>
<style scoped>
.flex-container {
    width: 100%;
    height: 100%;
    background-color: var(--dashboard--background);
    color: white;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 1rem;
}

.setting-wrapper {
    width: 90%;
    height: 100%;
    display: flex;
    flex-direction: column;
    gap: 2rem;
    align-items: center;
    justify-content: center;
    background-color: var(--dashboard-lighter-background);
    border-radius: 15px;
    padding: 1.5rem;
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
    background-color: var(--component-light);
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
    background-color: var(--dashboard-lighter-background);
    border-radius: 15px;
    padding: 1rem   ;  
}
.little-component-dark {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
    width: 15rem;
    height: 15rem;
    background-color: var(--component-darker-background);
    border-radius: 15px;
    gap: 0.5rem;
}
.nav-example {
    width: 100%;
    height: 3rem;
    background-color: var(--component-background);
    border-top-left-radius: 15px;
    border-top-right-radius: 15px;
}
.content-example {
    width: 90%;
    height: 5rem;
    border-radius: 5px;
    background-color: var(--component-light);
    
}
.footer-example {
    display: flex;
     /* align-items: flex-end; */
    justify-content: flex-end;
    padding: 0.5rem;
    width: 100%;
    height: 3rem;
    background-color: var(--component-background);
    border-bottom-left-radius: 15px;
    border-bottom-right-radius: 15px;
}
.button-example {
    position: relative;
    bottom: 100%;
    width: 3rem;
    height: 3rem;
    border-radius: 50%;
    background-color: var(--button-red);
    margin-bottom: 5rem;
}
</style>zx