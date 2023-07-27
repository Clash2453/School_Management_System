<script setup lang="ts">
import {inject, onBeforeMount, ref } from 'vue'
import { ThemeSwitcher } from '../../services/themeSwitcher';
import { Emitter } from 'mitt';

const themeSwitcher:ThemeSwitcher = inject('themeSwitcher')
const emitter: Emitter<GlobalEvents> = inject('emitter')
const iconFill = ref<string>();

onBeforeMount(() => {
  iconFill.value = themeSwitcher.getIconFill()
  emitter.on('updateTheme', () => {
    iconFill.value = themeSwitcher.getIconFill()
  })
})
console.log(iconFill)
</script>

<template>
  <footer id="footer">
    <div class="icon-row">
      <v-icon class="icon" name="bi-github" scale="2" :fill="iconFill"></v-icon>
      <v-icon class="icon" name="bi-facebook" scale="2" :fill="iconFill"></v-icon>
      <v-icon class="icon" name="bi-linkedin" scale="2" :fill="iconFill"></v-icon>
    </div>
    <p class="wh-p align-c">© 2023 All Rights Reserved | This site was made by Spas Milenkov</p>
  </footer>
</template>

<style scoped>
.icon-row,
#footer {
  width: 100%;

  display: flex;
  align-items: center;
  justify-content: center;
}
#footer {
  padding: 1rem;
  flex-direction: column;
  gap: 1rem;
  min-height: 7rem;
  bottom: 0;
  right: 0;

  background-color: var(--primary-color  );
}
.icon-row {
  gap: 1rem;
}
.icon {
  color: white;
}

.icon:hover {
  color: rgb(224, 224, 224);
}
</style>