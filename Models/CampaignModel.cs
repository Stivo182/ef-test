using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test.Models
{
    public class CampaignModel: BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<CampaignSceneModel> Scenes { get; set; } = new List<CampaignSceneModel>();
    }
}
