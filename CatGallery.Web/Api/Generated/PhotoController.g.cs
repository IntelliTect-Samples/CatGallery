
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
    [Route("api/Photo")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class PhotoController
        : BaseApiController<CatGallery.Data.Models.Photo, PhotoDtoGen, CatGallery.Data.AppDbContext>
    {
        public PhotoController(CatGallery.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<CatGallery.Data.Models.Photo>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PhotoDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<CatGallery.Data.Models.Photo> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<PhotoDtoGen>> List(
            ListParameters parameters,
            IDataSource<CatGallery.Data.Models.Photo> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<CatGallery.Data.Models.Photo> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<PhotoDtoGen>> Save(
            [FromForm] PhotoDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<CatGallery.Data.Models.Photo> dataSource,
            IBehaviors<CatGallery.Data.Models.Photo> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PhotoDtoGen>> Delete(
            int id,
            IBehaviors<CatGallery.Data.Models.Photo> behaviors,
            IDataSource<CatGallery.Data.Models.Photo> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
