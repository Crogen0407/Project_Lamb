using UnityEngine;

namespace TechTree
{
    public class TestNodeSO : NodeSO
    {
        public string testString;

        public override void OnEnableNode()
        {
            Debug.Log($"{nodeName} node enabled! {testString}");
        }
    }
}
