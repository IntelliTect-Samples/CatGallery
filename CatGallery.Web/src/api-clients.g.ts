import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class PhotoApiClient extends ModelApiClient<$models.Photo> {
  constructor() { super($metadata.Photo) }
  public upload(file: File | null, isPublic: boolean | null, tags: string[] | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.Photo>> {
    const $method = this.$metadata.methods.upload
    const $params =  {
      file,
      isPublic,
      tags,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public download(id: number, etag: number, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<File>> {
    const $method = this.$metadata.methods.download
    const $params =  {
      id,
      etag,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


export class PhotoTagApiClient extends ModelApiClient<$models.PhotoTag> {
  constructor() { super($metadata.PhotoTag) }
}


export class TagApiClient extends ModelApiClient<$models.Tag> {
  constructor() { super($metadata.Tag) }
}


