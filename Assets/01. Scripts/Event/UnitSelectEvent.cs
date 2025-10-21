using Project_Lamb.Entities.Unit;

namespace Project_Lamb.Event
{
    public struct UnitSelectEvent : IEvent
    {
        public ISelectable Unit { get; private set; }

        public UnitSelectEvent(ISelectable unit)
        {
            Unit = unit;
        }
    }
}
