using System.Collections.Generic;
using UnityEngine;

namespace Project_Lamb
{
    [CreateAssetMenu(menuName = "SO/ResourceGroup")]
    public class ResourceSOGroup : ScriptableObject
    {
        public List<ResourceSO> resourceList;

        public ResourceSO GetResource(int id)
            => resourceList.Find(resource => resource.id == id);
    }
}
