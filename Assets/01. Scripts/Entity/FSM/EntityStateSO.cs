using UnityEngine;

namespace Project_Lamb.Entities.FSM
{
    [CreateAssetMenu(fileName = "StateSO", menuName = "SO/FSM/StateSO")]
    public class EntityStateSO : ScriptableObject
    {
        public FSMState stateName;
        public string className;
        //public AnimParamSO animParam;
    }
}