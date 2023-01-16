import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const Photo = domain.types.Photo = {
  name: "Photo",
  displayName: "Photo",
  get displayProp() { return this.props.photoId }, 
  type: "model",
  controllerRoute: "Photo",
  get keyProp() { return this.props.photoId }, 
  behaviorFlags: 7,
  props: {
    photoId: {
      name: "photoId",
      displayName: "Photo Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    tags: {
      name: "tags",
      displayName: "Tags",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.PhotoTag as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.PhotoTag as ModelType).props.photoId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.PhotoTag as ModelType).props.photo as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    uploadDate: {
      name: "uploadDate",
      displayName: "Upload Date",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
    uploadedById: {
      name: "uploadedById",
      displayName: "Uploaded By Id",
      type: "string",
      role: "value",
    },
    uploadedByName: {
      name: "uploadedByName",
      displayName: "Uploaded By Name",
      type: "string",
      role: "value",
    },
    originalFileName: {
      name: "originalFileName",
      displayName: "Original File Name",
      type: "string",
      role: "value",
    },
    storageUrl: {
      name: "storageUrl",
      displayName: "Storage Url",
      type: "string",
      role: "value",
    },
    isPublic: {
      name: "isPublic",
      displayName: "Is Public",
      type: "boolean",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const PhotoTag = domain.types.PhotoTag = {
  name: "PhotoTag",
  displayName: "Photo Tag",
  get displayProp() { return this.props.photoTagId }, 
  type: "model",
  controllerRoute: "PhotoTag",
  get keyProp() { return this.props.photoTagId }, 
  behaviorFlags: 7,
  props: {
    photoTagId: {
      name: "photoTagId",
      displayName: "Photo Tag Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    photoId: {
      name: "photoId",
      displayName: "Photo Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Photo as ModelType).props.photoId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Photo as ModelType) },
      get navigationProp() { return (domain.types.PhotoTag as ModelType).props.photo as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Photo is required.",
      }
    },
    photo: {
      name: "photo",
      displayName: "Photo",
      type: "model",
      get typeDef() { return (domain.types.Photo as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.PhotoTag as ModelType).props.photoId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Photo as ModelType).props.photoId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Photo as ModelType).props.tags as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    tagId: {
      name: "tagId",
      displayName: "Tag Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Tag as ModelType).props.name as PrimaryKeyProperty },
      get principalType() { return (domain.types.Tag as ModelType) },
      get navigationProp() { return (domain.types.PhotoTag as ModelType).props.tag as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    tag: {
      name: "tag",
      displayName: "Tag",
      type: "model",
      get typeDef() { return (domain.types.Tag as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.PhotoTag as ModelType).props.tagId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Tag as ModelType).props.name as PrimaryKeyProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Tag = domain.types.Tag = {
  name: "Tag",
  displayName: "Tag",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Tag",
  get keyProp() { return this.props.name }, 
  behaviorFlags: 7,
  props: {
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "primaryKey",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
      }
    },
    color: {
      name: "color",
      displayName: "Color",
      type: "string",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    Photo: typeof Photo
    PhotoTag: typeof PhotoTag
    Tag: typeof Tag
  }
  services: {
  }
}

solidify(domain)

export default domain as unknown as AppDomain
