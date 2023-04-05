using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test.Models
{
    public class CampaignScene: BaseEntity
    {
        public string Name { get; set; } = "";
        public int SortOrder { get; set; } = 0;
        public Campaign Campaign { get; set; }
        public IEnumerable<SceneObject> SceneObjects { get; set; } = new List<SceneObject>();
    }
}
