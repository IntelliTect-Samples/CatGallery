using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CatGallery.Web.Models
{
    public partial class TagDtoGen : GeneratedDto<CatGallery.Data.Models.Tag>
    {
        public TagDtoGen() { }

        private string _Name;
        private string _Color;

        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Color
        {
            get => _Color;
            set { _Color = value; Changed(nameof(Color)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(CatGallery.Data.Models.Tag obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.Name = obj.Name;
            this.Color = obj.Color;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(CatGallery.Data.Models.Tag entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Color))) entity.Color = Color;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override CatGallery.Data.Models.Tag MapToNew(IMappingContext context)
        {
            var entity = new CatGallery.Data.Models.Tag();
            MapTo(entity, context);
            return entity;
        }
    }
}
