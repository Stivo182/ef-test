using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test.Models
{
    public class CampaignSceneModel: BaseEntity
    {
        public string Name { get; set; } = "";
        public int SortOrder { get; set; } = 0;
        public int CampaignId { get; set;}
        public CampaignModel CampaignNavigation { get; set; }
    }
}
