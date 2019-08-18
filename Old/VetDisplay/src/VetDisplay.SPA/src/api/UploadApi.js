import { getAsync, postAsync, putAsync, deleteAsync, getStringAsync } from '../helpers/apiHelper'

const endpoint = process.env.VUE_APP_BACKEND + "/api/Upload";

export async function upload(file){
  return await postAsync(`${endpoint}/uploadVideo`, file );
}