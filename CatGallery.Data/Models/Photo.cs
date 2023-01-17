namespace CatGallery.Data.Models;

#nullable disable

public class Photo
{
    public int PhotoId { get; set; }

    public DateTimeOffset UploadDate { get; set; }
    public string UploadedById { get; set; }
    public string UploadedByName { get; set; }

    public string OriginalFileName { get; set; }
    public string StorageUrl { get; set; }

    public bool IsPublic { get; set; }

    public ICollection<PhotoTag> PhotoTags { get; set; }
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

    public string Color { get; set; }
}