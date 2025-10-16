using System.Collections.Generic;
using UnityEngine;

namespace TechTree
{
    public abstract class NodeSO : ScriptableObject
    {
        [HideInInspector] public string guid;
        [HideInInspector] public Vector2 position;

        [HideInInspector] public int id;
        [HideInInspector] public List<NodeSO> nextNodes;
        [HideInInspector] public NodeSO prevNode;

        public Sprite icon;
        public string nodeName;
        [TextArea]
        public string nodeExplain;

        public abstract void OnEnableNode();
    }
}
