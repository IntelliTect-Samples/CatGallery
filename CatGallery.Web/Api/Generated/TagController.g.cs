
using CatGallery.Web.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CatGallery.Web.Api
{
    [Route("api/Tag")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class TagController
        : BaseApiController<CatGallery.Data.Models.Tag, TagDtoGen, CatGallery.Data.AppDbContext>
    {
        public TagController(CatGallery.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CatGallery.Data.Models.Tag>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<TagDtoGen>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<CatGallery.Data.Models.Tag> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<TagDtoGen>> List(
            ListParameters parameters,
            IDataSource<CatGallery.Data.Models.Tag> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CatGallery.Data.Models.Tag> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<TagDtoGen>> Save(
            [FromForm] TagDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CatGallery.Data.Models.Tag> dataSource,
            IBehaviors<CatGallery.Data.Models.Tag> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<TagDtoGen>> Delete(
            string id,
            IBehaviors<CatGallery.Data.Models.Tag> behaviors,
            IDataSource<CatGallery.Data.Models.Tag> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
