using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode.Examples.JuqingGraph;

namespace XNodeEditor.Examples
{
    [CustomNodeGraphEditor(typeof(JuqingGraph))]
    public class JuqingGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(System.Type type)
        {
            if (type.Namespace == "XNode.Examples.JuqingGraph")
            {
                string allName = base.GetNodeMenuName(type);
                return allName.Replace("X Node/Examples/Juqing Graph/", "");
            }
            else
            {
                return null;
            }
        }
    }
}

