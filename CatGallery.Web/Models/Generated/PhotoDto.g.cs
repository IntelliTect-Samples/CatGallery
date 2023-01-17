using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CatGallery.Web.Models
{
    public partial class PhotoDtoGen : GeneratedDto<CatGallery.Data.Models.Photo>
    {
        public PhotoDtoGen() { }

        private int? _PhotoId;
        private System.DateTimeOffset? _UploadDate;
        private string _UploadedById;
        private string _UploadedByName;
        private bool? _IsPublic;
        private System.Collections.Generic.ICollection<CatGallery.Web.Models.PhotoTagDtoGen> _PhotoTags;

        public int? PhotoId
        {
            get => _PhotoId;
            set { _PhotoId = value; Changed(nameof(PhotoId)); }
        }
        public System.DateTimeOffset? UploadDate
        {
            get => _UploadDate;
            set { _UploadDate = value; Changed(nameof(UploadDate)); }
        }
        public string UploadedById
        {
            get => _UploadedById;
            set { _UploadedById = value; Changed(nameof(UploadedById)); }
        }
        public string UploadedByName
        {
            get => _UploadedByName;
            set { _UploadedByName = value; Changed(nameof(UploadedByName)); }
        }
        public bool? IsPublic
        {
            get => _IsPublic;
            set { _IsPublic = value; Changed(nameof(IsPublic)); }
        }
        public System.Collections.Generic.ICollection<CatGallery.Web.Models.PhotoTagDtoGen> PhotoTags
        {
            get => _PhotoTags;
            set { _PhotoTags = value; Changed(nameof(PhotoTags)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(CatGallery.Data.Models.Photo obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.PhotoId = obj.PhotoId;
            this.UploadDate = obj.UploadDate;
            this.UploadedById = obj.UploadedById;
            this.UploadedByName = obj.UploadedByName;
            this.IsPublic = obj.IsPublic;
            var propValPhotoTags = obj.PhotoTags;
            if (propValPhotoTags != null && (tree == null || tree[nameof(this.PhotoTags)] != null))
            {
                this.PhotoTags = propValPhotoTags
                    .OrderBy(f => f.PhotoTagId)
                    .Select(f => f.MapToDto<CatGallery.Data.Models.PhotoTag, PhotoTagDtoGen>(context, tree?[nameof(this.PhotoTags)])).ToList();
            }
            else if (propValPhotoTags == null && tree?[nameof(this.PhotoTags)] != null)
            {
                this.PhotoTags = new PhotoTagDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(CatGallery.Data.Models.Photo entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(PhotoId))) entity.PhotoId = (PhotoId ?? entity.PhotoId);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override CatGallery.Data.Models.Photo MapToNew(IMappingContext context)
        {
            var entity = new CatGallery.Data.Models.Photo();
            MapTo(entity, context);
            return entity;
        }
    }
}
