import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class PhotoApiClient extends ModelApiClient<$models.Photo> {
  constructor() { super($metadata.Photo) }
}


export class PhotoTagApiClient extends ModelApiClient<$models.PhotoTag> {
  constructor() { super($metadata.PhotoTag) }
}


export class TagApiClient extends ModelApiClient<$models.Tag> {
  constructor() { super($metadata.Tag) }
}


