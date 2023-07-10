export interface InternetError extends Error{
    cause?:number|undefined
    response?: any
}