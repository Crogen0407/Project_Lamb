namespace Project_Lamb.Entities.Unit
{
    public interface IUpgradeable
    {
        int Level { get; }
        void Upgrade();
        float GetUpgradeCost();
    }
}
