using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CatGallery.Web.Models
{
    public partial class PhotoTagDtoGen : GeneratedDto<CatGallery.Data.Models.PhotoTag>
    {
        public PhotoTagDtoGen() { }

        private int? _PhotoTagId;
        private int? _PhotoId;
        private CatGallery.Web.Models.PhotoDtoGen _Photo;
        private string _TagId;
        private CatGallery.Web.Models.TagDtoGen _Tag;

        public int? PhotoTagId
        {
            get => _PhotoTagId;
            set { _PhotoTagId = value; Changed(nameof(PhotoTagId)); }
        }
        public int? PhotoId
        {
            get => _PhotoId;
            set { _PhotoId = value; Changed(nameof(PhotoId)); }
        }
        public CatGallery.Web.Models.PhotoDtoGen Photo
        {
            get => _Photo;
            set { _Photo = value; Changed(nameof(Photo)); }
        }
        public string TagId
        {
            get => _TagId;
            set { _TagId = value; Changed(nameof(TagId)); }
        }
        public CatGallery.Web.Models.TagDtoGen Tag
        {
            get => _Tag;
            set { _Tag = value; Changed(nameof(Tag)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(CatGallery.Data.Models.PhotoTag obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.PhotoTagId = obj.PhotoTagId;
            this.PhotoId = obj.PhotoId;
            this.TagId = obj.TagId;
            if (tree == null || tree[nameof(this.Photo)] != null)
                this.Photo = obj.Photo.MapToDto<CatGallery.Data.Models.Photo, PhotoDtoGen>(context, tree?[nameof(this.Photo)]);

            if (tree == null || tree[nameof(this.Tag)] != null)
                this.Tag = obj.Tag.MapToDto<CatGallery.Data.Models.Tag, TagDtoGen>(context, tree?[nameof(this.Tag)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(CatGallery.Data.Models.PhotoTag entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(PhotoTagId))) entity.PhotoTagId = (PhotoTagId ?? entity.PhotoTagId);
            if (ShouldMapTo(nameof(PhotoId))) entity.PhotoId = (PhotoId ?? entity.PhotoId);
            if (ShouldMapTo(nameof(TagId))) entity.TagId = TagId;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override CatGallery.Data.Models.PhotoTag MapToNew(IMappingContext context)
        {
            var entity = new CatGallery.Data.Models.PhotoTag();
            MapTo(entity, context);
            return entity;
        }
    }
}
