using UnityEngine;

namespace Project_Lamb
{
    public abstract class ResourceSO : ScriptableObject
    {
        [field: SerializeField] public int id { get; private set; }
        [field: SerializeField] public string resourceName { get; private set; }
        [field: SerializeField] public string description { get; private set; }
        [field: SerializeField] public long maxAmount { get; private set; }
    }
}
