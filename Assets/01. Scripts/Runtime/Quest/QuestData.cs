using Project_Lamb.Core.Utility;
using System;

namespace Project_Lamb.Runtime.Quest
{
    [Serializable]
    public class QuestData : IGameData
    {
        public int QuestNUID { get; set; }
        public EQuestType EQuestType { get; set; }
        public int MaxCompleteCount { get; set; }
        public bool IsStartResetCount { get; set; }
        public string RewardUID { get; set; }
    }

    public enum EQuestType
    {
        Player_LevelUp,
    }
}