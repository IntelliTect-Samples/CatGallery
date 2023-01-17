
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

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<PhotoDtoGen>> Delete(
            int id,
            IBehaviors<CatGallery.Data.Models.Photo> behaviors,
            IDataSource<CatGallery.Data.Models.Photo> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        // Methods from data class exposed through API Controller.

        /// <summary>
        /// Method: Upload
        /// </summary>
        [HttpPost("Upload")]
        [Authorize]
        public virtual async Task<ItemResult<PhotoDtoGen>> Upload(
            [FromServices] Microsoft.Extensions.Configuration.IConfiguration configuration,
            Microsoft.AspNetCore.Http.IFormFile file,
            [FromForm(Name = "isPublic")] bool isPublic,
            [FromForm(Name = "tags")] string[] tags)
        {
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(User);
            var _methodResult = await CatGallery.Data.Models.Photo.Upload(Db, User, configuration, file == null ? null : new IntelliTect.Coalesce.Models.File { Name = file.FileName, ContentType = file.ContentType, Length = file.Length, Content = file.OpenReadStream() }, isPublic, tags.ToArray());
            var _result = new ItemResult<PhotoDtoGen>();
            _result.Object = Mapper.MapToDto<CatGallery.Data.Models.Photo, PhotoDtoGen>(_methodResult, _mappingContext, includeTree);
            return _result;
        }

        /// <summary>
        /// Method: Download
        /// </summary>
        [HttpGet("Download")]
        [Authorize]
        public virtual async Task<ActionResult<ItemResult<IntelliTect.Coalesce.Models.IFile>>> Download(
            [FromServices] IDataSourceFactory dataSourceFactory,
            int id,
            int etag)
        {
            var dataSource = dataSourceFactory.GetDataSource<CatGallery.Data.Models.Photo, CatGallery.Data.Models.Photo>("Default");
            var (itemResult, _) = await dataSource.GetItemAsync(id, new ListParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult<IntelliTect.Coalesce.Models.IFile>(itemResult);
            }
            var item = itemResult.Object;

            var _currentVaryValue = item.PhotoId;
            if (_currentVaryValue != default)
            {
                var _expectedEtagHeader = new Microsoft.Net.Http.Headers.EntityTagHeaderValue('"' + Microsoft.AspNetCore.WebUtilities.Base64UrlTextEncoder.Encode(System.Text.Encoding.UTF8.GetBytes(_currentVaryValue.ToString())) + '"');
                var _cacheControlHeader = new Microsoft.Net.Http.Headers.CacheControlHeaderValue { Private = true, MaxAge = TimeSpan.Zero };
                if (etag != default && _currentVaryValue == etag)
                {
                    _cacheControlHeader.MaxAge = TimeSpan.FromDays(30);
                }
                Response.GetTypedHeaders().CacheControl = _cacheControlHeader;
                Response.GetTypedHeaders().ETag = _expectedEtagHeader;
                if (Request.GetTypedHeaders().IfNoneMatch.Any(value => value.Compare(_expectedEtagHeader, true)))
                {
                    return StatusCode(StatusCodes.Status304NotModified);
                }
            }

            var _methodResult = await item.Download();
            await Db.SaveChangesAsync();
            if (_methodResult != null)
            {
                string _contentType = _methodResult.ContentType;
                if (string.IsNullOrWhiteSpace(_contentType) && (
                    string.IsNullOrWhiteSpace(_methodResult.Name) ||
                    !(new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider().TryGetContentType(_methodResult.Name, out _contentType))
                ))
                {
                    _contentType = "application/octet-stream";
                }
                return File(_methodResult.Content, _contentType, _methodResult.Name, !(_methodResult.Content is System.IO.MemoryStream));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
