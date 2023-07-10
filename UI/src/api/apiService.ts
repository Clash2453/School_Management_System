import axios, { AxiosError } from 'axios'
import type{ Teacher } from '../interfaces/Teacher' 
import type { Subject } from '../interfaces/Subject'
import { inject} from 'vue'
import { Emitter } from 'mitt'
import type { Admin } from '@/interfaces/Admin';
import type { Student } from '@/interfaces/Student';
import type { ErrorHandlingService } from '@/services/ErrorHandlingService'
import type { Specialty } from '@/interfaces/Specialty'

type ListUpdate = {
  usersRenewed:()=>boolean
}

const emitter:Emitter<ListUpdate> | undefined = inject('emitter')
const errorHandler:ErrorHandlingService | undefined = inject('errorHandler')

function errorCheck(e:unknown){
  if(errorHandler === undefined)
    {
      const error = new Error('error handler is undefined')
      console.error(error)
      return error
    }
    return errorHandler.ensureError(e)
}

async function fetchTeachers(): Promise<Teacher[]> {
    try {
      const result = await axios({
        method: 'GET',
        url: `https://localhost:7080/api/Admin/fetch/teachers`,
        headers: {
          'Content-Type': 'application/json'
        },
        withCredentials: true
      })
      console.log(result.data)
      return result.data
    } catch (e:unknown) {
      const internetError = errorCheck(e)
      console.log(internetError)
      throw internetError
    }
  }
  
  async function fetchSpecialties(): Promise<Specialty[]>  {
    try {
      const result = await axios({
        method: 'GET',
        url: `https://localhost:7080/api/Subject/get-specialties`,
        headers: {
          'Content-Type': 'application/json'
        },
        withCredentials: true
      })
      console.log(result.data)
      return result.data
    } catch (e:unknown) {
      const internetError = errorCheck(e)
      console.log(internetError)
      throw internetError
    }
  }
  
  async function fetchFaculties(): Promise<Teacher[]>  {
    try {
      const result = await axios({
        method: 'GET',
        url: `https://localhost:7080/api/Subject/get-faculties`,
        headers: {
          'Content-Type': 'application/json'
        },
        withCredentials: true
      })
      console.log(result.data)
      return result.data
    } catch (e:unknown) {
      const internetError = errorCheck(e)
      console.log(internetError)
      throw internetError
    }
  }
  
  async function fetchSubjects():Promise<Subject[]>  {
    try {
      const result = await axios({
        method: 'GET',
        url: `https://localhost:7080/api/Subject/get-subjects`,
        headers: {
          'Content-Type': 'application/json'
        },
        withCredentials: true
      })
      console.log(result.data)
      return result.data
    } catch (e:unknown) {
      const internetError = errorCheck(e)
      console.log(internetError)
      throw internetError
    }
  }

async function fetchStudents(): Promise<Student[]>   {
  try{
    const result = await axios({

      method: 'GET',
      url: 'https://localhost:7080/api/Admin/fetch/students',
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    renewLists()
    return result.data
  } catch (e:unknown) {
    const internetError = errorCheck(e)
    console.log(internetError)
    throw  internetError
  }
}
async function fetchAdmins(): Promise<Admin[]> {
  try {
    const result = await axios({
      method: 'GET',
      url: `https://localhost:7080/api/Admin/fetch/admins`,
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    })
    renewLists()
    return result.data
    } catch (e:unknown) {
      const internetError = errorCheck(e)
      console.log(internetError)
      throw internetError
    }
}
async function renewLists() {
  if(emitter == undefined)
    console.log('emitter error')
  else
    emitter.emit('usersRenewed', () => true)
}
  export {fetchFaculties, fetchSpecialties, fetchSubjects, fetchTeachers, fetchAdmins, fetchStudents}