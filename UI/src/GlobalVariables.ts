import {ref} from 'vue'

export const theme = ref('light')
export const heroFill = ref('light')
export const iconFill = ref('dark')
export function applyTheme() {
        const persistentTheme = localStorage.getItem("userTheme")
        console.log(persistentTheme)
        if (persistentTheme === null) {
            if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                theme.value = 'dark'
                iconFill.value = 'white'
                heroFill.value = 'white'
              }
              window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (event) => {
                if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                    theme.value = 'dark'
                    iconFill.value = 'white'
                    heroFill.value = 'white'
                    document.body.classList.add('dark')
                    document.body.classList.remove('light')
                }
                else{
                    theme.value = 'light'
                    iconFill.value = '#272635'
                    heroFill.value = 'white'
                    document.body.classList.add('light')
                    document.body.classList.remove('dark')
                }
                console.log('i change from dark to light')
                
              });
        }
        else {
            console.log('setting theme from local')
            if(persistentTheme === 'light'){
                theme.value = 'light'
                iconFill.value = '#272635'
                heroFill.value = 'white'
                document.body.classList.add('light')
                document.body.classList.remove('dark')
            }
            else {
                theme.value = 'dark'
                iconFill.value = 'white'
                heroFill.value = 'white'
                document.body.classList.add('dark')
                document.body.classList.remove('light')
            }
        }
    }