using EF.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Entities;

public partial class SceneObject: BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = "";

    public int SortOrder { get; set; }

    [Required]
    public int CampaignSceneId { get; set; }

    [ForeignKey(nameof(CampaignSceneId))]
    public CampaignScene CampaignScene { get; set; }
}
