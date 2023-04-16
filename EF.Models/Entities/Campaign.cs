using EF.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models.Entities;

public partial class Campaign: BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = "";

    [InverseProperty(nameof(CampaignScene.Campaign))]
    public IEnumerable<CampaignScene> CampaignScenes { get; set; } = new List<CampaignScene>();
}
