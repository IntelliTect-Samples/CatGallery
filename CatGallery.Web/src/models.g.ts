import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface Photo extends Model<typeof metadata.Photo> {
  photoId: number | null
  uploadDate: Date | null
  uploadedById: string | null
  uploadedByName: string | null
  isPublic: boolean | null
  photoTags: PhotoTag[] | null
}
export class Photo {
  
  /** Mutates the input object and its descendents into a valid Photo implementation. */
  static convert(data?: Partial<Photo>): Photo {
    return convertToModel(data || {}, metadata.Photo) 
  }
  
  /** Maps the input object and its descendents to a new, valid Photo implementation. */
  static map(data?: Partial<Photo>): Photo {
    return mapToModel(data || {}, metadata.Photo) 
  }
  
  /** Instantiate a new Photo, optionally basing it on the given data. */
  constructor(data?: Partial<Photo> | {[k: string]: any}) {
      Object.assign(this, Photo.map(data || {}));
  }
}


export interface PhotoTag extends Model<typeof metadata.PhotoTag> {
  photoTagId: number | null
  photoId: number | null
  photo: Photo | null
  tagId: string | null
  tag: Tag | null
}
export class PhotoTag {
  
  /** Mutates the input object and its descendents into a valid PhotoTag implementation. */
  static convert(data?: Partial<PhotoTag>): PhotoTag {
    return convertToModel(data || {}, metadata.PhotoTag) 
  }
  
  /** Maps the input object and its descendents to a new, valid PhotoTag implementation. */
  static map(data?: Partial<PhotoTag>): PhotoTag {
    return mapToModel(data || {}, metadata.PhotoTag) 
  }
  
  /** Instantiate a new PhotoTag, optionally basing it on the given data. */
  constructor(data?: Partial<PhotoTag> | {[k: string]: any}) {
      Object.assign(this, PhotoTag.map(data || {}));
  }
}


export interface Tag extends Model<typeof metadata.Tag> {
  name: string | null
  color: string | null
}
export class Tag {
  
  /** Mutates the input object and its descendents into a valid Tag implementation. */
  static convert(data?: Partial<Tag>): Tag {
    return convertToModel(data || {}, metadata.Tag) 
  }
  
  /** Maps the input object and its descendents to a new, valid Tag implementation. */
  static map(data?: Partial<Tag>): Tag {
    return mapToModel(data || {}, metadata.Tag) 
  }
  
  /** Instantiate a new Tag, optionally basing it on the given data. */
  constructor(data?: Partial<Tag> | {[k: string]: any}) {
      Object.assign(this, Tag.map(data || {}));
  }
}


