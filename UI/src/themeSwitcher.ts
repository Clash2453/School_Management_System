export class ThemeSwitcher {
    private readonly lightThemeHeroFill: string
    private readonly darkThemeHeroFill: string
    private readonly lightThemeIconFill: string
    private readonly darkThemeIconFIll: string
    private isLight: string=  'light';
    /**
     * setLightTheme
     */
    public setLightTheme() {
        this.isLight = 'light';
    }
    /**
     * setPreference
     */
    public setPreference() {
        console.log('HERE I AM')
        if(this.isLight === 'light' ){
            document.body.classList.add('light')
            document.body.classList.remove('dark')
            console.log('light')

            return
        }
        if(this.isLight === 'dark') {
            document.body.classList.add('dark')
            document.body.classList.remove('light')
            console.log('dark')

            return 
        }
    }
    /**
     * setDarkTheme
     */
    public setDarkTheme() {
        this.isLight = 'dark';
    }

    /**
     * getTheme
     */
    public getPreference() {
        return this.isLight;
    }
    /**
     * getHeroFill
     */
    public getLightThemeHeroFill() {
        return this.lightThemeHeroFill
    }
    /**
     * getDarkThemeHeroFill
     */
    public getDarkThemeHeroFill() {
        return this.darkThemeHeroFill
    }
    /**
     * getLightThemeIconFill
     */
    public getLightThemeIconFill() {
        return this.lightThemeIconFill
    }
    /**
     * getDarkThemeIconFill
     */
    public getDarkThemeIconFill() {
        return this.darkThemeIconFIll
    }
    /**
     * returns the name of the 
     */
    public getIconFill() {
        if(this.getPreference() === 'dark'){
            console.log('its dark')
            return this.getDarkThemeIconFill()
          }
          return this.getLightThemeIconFill()
    }
    /**
     *
     */
    constructor() {
        this.lightThemeHeroFill = 'white'
        this.darkThemeHeroFill = 'white'
        this.lightThemeIconFill = '#272635'
        this.darkThemeIconFIll = 'white'
    }
}