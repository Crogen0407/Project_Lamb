using Project_Lamb.Event;
using UnityEngine;

namespace Project_Lamb.Entities.Unit
{
    public class BaseBuilding : MonoBehaviour, ISelectable
    {
        [SerializeField] private GameObject decalProjector;

        public bool IsSelected { get; private set; }

        public void Select()
        {
            decalProjector.SetActive(true);
            IsSelected = true;
            Bus<UnitSelectEvent>.Raise(new UnitSelectEvent(this));
        }



        public void DeSelect()
        {
            decalProjector.SetActive(true);
            IsSelected = true;
            Bus<UnitSelectEvent>.Raise(new UnitSelectEvent(this));
        }

        
    }
}
