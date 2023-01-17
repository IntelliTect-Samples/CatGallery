using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.Utilities;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace CatGallery.Data.Models;

#nullable disable

[Create(SecurityPermissionLevels.DenyAll)]
[Edit(SecurityPermissionLevels.DenyAll)]
[Delete(SecurityPermissionLevels.DenyAll)]
public class Photo
{
    [DefaultOrderBy(OrderByDirection = DefaultOrderByAttribute.OrderByDirections.Descending)]
    public int PhotoId { get; set; }

    [Read]
    public DateTimeOffset UploadDate { get; set; }
    [Read]
    public string UploadedById { get; set; }
    [Read]
    public string UploadedByName { get; set; }

    [InternalUse]
    public string OriginalFileName { get; set; }
    [InternalUse]
    public string StorageUrl { get; set; }

    [Read]
    public bool IsPublic { get; set; }

    [ManyToMany("Tags")]
    public ICollection<PhotoTag> PhotoTags { get; set; }

    [Coalesce]
    public static async Task<Photo> Upload(
        AppDbContext db,
        ClaimsPrincipal user,
        [Inject] IConfiguration configuration,
        IFile file,
        bool isPublic,
        string[] tags
    )
    {
        var containerClient = new BlobContainerClient(new Uri(configuration["Storage:ContainerUri"]), AzureCredential);
        BlobClient blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString());

        await blobClient.UploadAsync(file.Content, true);

        var photo = new Photo
        {
            UploadDate = DateTimeOffset.Now,
            UploadedById = user.GetUserId(),
            UploadedByName = user.Identity.Name,
            OriginalFileName = file.Name,
            StorageUrl = blobClient.Uri.ToString(),
            IsPublic = isPublic,
            PhotoTags = tags.Select(t => new PhotoTag { TagId = t }).ToList()
        };
        db.Add(photo);
        await db.SaveChangesAsync();

        return photo;
    }

    [Coalesce, ControllerAction(
        Method = IntelliTect.Coalesce.DataAnnotations.HttpMethod.Get,
        VaryByProperty = nameof(PhotoId)
    )]
    public async Task<IFile> Download()
    {
        var blobClient = new BlobClient(new Uri(StorageUrl), AzureCredential);
        return new IntelliTect.Coalesce.Models.File()
        {
            Content = await blobClient.OpenReadAsync(),
            Name = OriginalFileName,
            ContentType = "image/" + Path.GetExtension(OriginalFileName).Trim('.'),
        };
    }

    private static TokenCredential AzureCredential = new DefaultAzureCredential();
}

public class PhotoTag
{
    public int PhotoTagId { get; set; }

    public int PhotoId { get; set; }
    public Photo Photo { get; set; }

    public string TagId { get; set; }
    public Tag Tag { get; set; }
}

public class Tag
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Name { get; set; }

    [DataType("Color")]
    public string Color { get; set; }
}