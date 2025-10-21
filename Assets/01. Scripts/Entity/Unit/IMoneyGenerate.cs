namespace Project_Lamb.Entities.Unit
{
    public interface IMoneyGenerate
    {
        float BaseRate { get; }
        float GenerateMoney(float deltaTime);
        float GetProductionRate();
    }
}


