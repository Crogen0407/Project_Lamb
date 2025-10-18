using Cysharp.Threading.Tasks;
using Project_Lamb.Core.Utility;
using Project_Lamb.Runtime.Quest;
using UnityEngine;

namespace Project_Lamb
{
    public class TestQuest : MonoBehaviour
    {
        private void Awake()
        {
            Test().Forget();
        }

        private async UniTask Test()
        {
            var asdf = await DataReader.ReadCSV<QuestData>("QuestData.csv");

            foreach (var q in asdf)
            {
                Debug.Log($"{q.QuestNUID} : {q.EQuestType}, {q.RewardUID}");
            }
        }
    }
}