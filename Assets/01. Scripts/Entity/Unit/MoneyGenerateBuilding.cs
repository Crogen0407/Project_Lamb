using UnityEngine;

namespace Project_Lamb.Entities.Unit
{
    public class MoneyGenerateBuilding : BaseBuilding, IMoneyGenerate, IUpgradeable
    {
        public int Level { get; private set; } = 1;

        public float BaseRate { get; private set; } = 10f;

        [SerializeField] private float _monney;


        private void Update()
        {
            _monney += GenerateMoney(Time.deltaTime);
        }

        public float GenerateMoney(float deltaTime)
        {
            Debug.Log(_monney);
            return GetProductionRate() * deltaTime;
        }

        public float GetProductionRate()
        {
            return BaseRate* Level;
        }

        public float GetUpgradeCost()
        {
            return 100 * Level;
        }

        public void Upgrade()
        {
            Level++;
        }
    }
}
