
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
    [Route("api/PhotoTag")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class PhotoTagController
        : BaseApiController<CatGallery.Data.Models.PhotoTag, PhotoTagDtoGen, CatGallery.Data.AppDbContext>
    {
        public PhotoTagController(CatGallery.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CatGallery.Data.Models.PhotoTag>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PhotoTagDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<CatGallery.Data.Models.PhotoTag> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<PhotoTagDtoGen>> List(
            ListParameters parameters,
            IDataSource<CatGallery.Data.Models.PhotoTag> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CatGallery.Data.Models.PhotoTag> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<PhotoTagDtoGen>> Save(
            [FromForm] PhotoTagDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CatGallery.Data.Models.PhotoTag> dataSource,
            IBehaviors<CatGallery.Data.Models.PhotoTag> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PhotoTagDtoGen>> Delete(
            int id,
            IBehaviors<CatGallery.Data.Models.PhotoTag> behaviors,
            IDataSource<CatGallery.Data.Models.PhotoTag> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
