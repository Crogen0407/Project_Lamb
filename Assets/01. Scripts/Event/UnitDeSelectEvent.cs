using Project_Lamb.Entities.Unit;

namespace Project_Lamb.Event
{
    public struct UnitDeSelectEvent
    {
        public ISelectable Unit { get; private set; }

        public UnitDeSelectEvent(ISelectable unit)
        {
            Unit = unit;
        }
    }
}
