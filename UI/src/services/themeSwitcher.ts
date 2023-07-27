

export class ThemeSwitcher {
    private readonly lightThemeHeroFill: string
    private readonly darkThemeHeroFill: string
    private readonly lightThemeIconFill: string
    private readonly darkThemeIconFIll: string
    private isLight: string=  'light';
    /**
     * Sets the current theme preference to light
     */
    public setLightTheme() {
        this.isLight = 'light';
    }
    /**
     * setPreference
     */
    public setPreference() {
        this.savePreference()
        console.log('setting preference')
        if(this.isLight === 'light' ){
            document.body.classList.add('light')
            document.body.classList.remove('dark')

            return
        }
        if(this.isLight === 'dark') {
            document.body.classList.add('dark')
            document.body.classList.remove('light')

            return 
        }
    }
    /**
     * Saves the user theme preference in the local storage
     */
    public savePreference() {
        localStorage.setItem('userTheme', this.isLight)
    }
    /**
     * Sets the current theme preference to dark
     */
    public setDarkTheme() {
        this.isLight = 'dark';
    }
    /**
     * Getter for the current user preferred theme
     */
    public getPreference() {
        return this.isLight;
    }
    /**
     * Get light theme fill colors for the hero section 
     */
    public getLightThemeHeroFill() {
        return this.lightThemeHeroFill
    }
    /**
     * Get dark theme fill colors for the hero section 
     */
    public getDarkThemeHeroFill() {
        return this.darkThemeHeroFill
    }
    /**
     * Get light theme fill colors for the hero section 
     */
    public getLightThemeIconFill() {
        return this.lightThemeIconFill
    }
    /**
     * Get dark theme fill colors for the icons
     */
    public getDarkThemeIconFill() {
        return this.darkThemeIconFIll
    }
    /**
     * Returns the icon fill color based on teh currently preferred user theme
     */
    public getIconFill() {
        if(this.getPreference() === 'dark'){
            console.log('its dark')
            return this.getDarkThemeIconFill()
          }
          return this.getLightThemeIconFill()
    }
    /**
     * Applies the selected user theme from the local storage
     */
    public applyTheme() {
        const persistentTheme = localStorage.getItem("userTheme")

        if (persistentTheme === null) {
            if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                this.setDarkTheme()
                this.setPreference()
              }
              window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (event) => {
                if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                  this.setDarkTheme()
                }
                else{
                  this.setLightTheme()
                }
                console.log('i change from dark to light')
                this.setPreference()
              });
        }
        else {
            console.log('setting theme from local')
            this.isLight = persistentTheme
        }
    }
    /**
     *
     */
    constructor() {
        this.applyTheme()
        this.lightThemeHeroFill = 'white'
        this.darkThemeHeroFill = 'white'
        this.lightThemeIconFill = '#272635'
        this.darkThemeIconFIll = 'white'
    }
}