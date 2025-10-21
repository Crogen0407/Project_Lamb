namespace Project_Lamb.Entities.Unit
{
    public interface ISelectable
    {
        bool IsSelected { get; }
        void Select();
        void DeSelect();
    }
}
