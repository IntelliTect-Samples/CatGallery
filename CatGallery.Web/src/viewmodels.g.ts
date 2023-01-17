import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface PhotoViewModel extends $models.Photo {
  photoId: number | null;
  uploadDate: Date | null;
  uploadedById: string | null;
  uploadedByName: string | null;
  originalFileName: string | null;
  storageUrl: string | null;
  isPublic: boolean | null;
  photoTags: PhotoTagViewModel[] | null;
}
export class PhotoViewModel extends ViewModel<$models.Photo, $apiClients.PhotoApiClient, number> implements $models.Photo  {
  
  
  public addToPhotoTags() {
    return this.$addChild('photoTags') as PhotoTagViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Photo> | null) {
    super($metadata.Photo, new $apiClients.PhotoApiClient(), initialData)
  }
}
defineProps(PhotoViewModel, $metadata.Photo)

export class PhotoListViewModel extends ListViewModel<$models.Photo, $apiClients.PhotoApiClient, PhotoViewModel> {
  
  constructor() {
    super($metadata.Photo, new $apiClients.PhotoApiClient())
  }
}


export interface PhotoTagViewModel extends $models.PhotoTag {
  photoTagId: number | null;
  photoId: number | null;
  photo: PhotoViewModel | null;
  tagId: string | null;
  tag: TagViewModel | null;
}
export class PhotoTagViewModel extends ViewModel<$models.PhotoTag, $apiClients.PhotoTagApiClient, number> implements $models.PhotoTag  {
  
  constructor(initialData?: DeepPartial<$models.PhotoTag> | null) {
    super($metadata.PhotoTag, new $apiClients.PhotoTagApiClient(), initialData)
  }
}
defineProps(PhotoTagViewModel, $metadata.PhotoTag)

export class PhotoTagListViewModel extends ListViewModel<$models.PhotoTag, $apiClients.PhotoTagApiClient, PhotoTagViewModel> {
  
  constructor() {
    super($metadata.PhotoTag, new $apiClients.PhotoTagApiClient())
  }
}


export interface TagViewModel extends $models.Tag {
  name: string | null;
  color: string | null;
}
export class TagViewModel extends ViewModel<$models.Tag, $apiClients.TagApiClient, string> implements $models.Tag  {
  
  constructor(initialData?: DeepPartial<$models.Tag> | null) {
    super($metadata.Tag, new $apiClients.TagApiClient(), initialData)
  }
}
defineProps(TagViewModel, $metadata.Tag)

export class TagListViewModel extends ListViewModel<$models.Tag, $apiClients.TagApiClient, TagViewModel> {
  
  constructor() {
    super($metadata.Tag, new $apiClients.TagApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  Photo: PhotoViewModel,
  PhotoTag: PhotoTagViewModel,
  Tag: TagViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  Photo: PhotoListViewModel,
  PhotoTag: PhotoTagListViewModel,
  Tag: TagListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

