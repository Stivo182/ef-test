using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test.Models
{
    public class Campaign: BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<CampaignScene> Scenes { get; set; } = new List<CampaignScene>();
    }
}
