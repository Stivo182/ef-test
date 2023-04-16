using EF.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Entities;

public partial class CampaignScene: BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = "";

    public int SortOrder { get; set; }

    [Required]
    public int CampaignId { get; set; }

    [ForeignKey(nameof(CampaignId))]
    public Campaign Campaign { get; set; }

    [InverseProperty(nameof(SceneObject.CampaignScene))]
    public IEnumerable<SceneObject> SceneObjects { get; set; } = new List<SceneObject>();
}
