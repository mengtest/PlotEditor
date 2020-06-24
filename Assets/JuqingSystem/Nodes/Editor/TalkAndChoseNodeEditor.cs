using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using XNode.Examples.JuqingGraph;

namespace XNodeEditor.Examples
{
    [CustomNodeEditor(typeof(TalkAndChoseNode))]
    public class TalkAndChoseNodeEditor : NodeEditor
    {
        public override void OnHeaderGUI()
        {
            GUI.color = Color.white;
            TalkAndChoseNode node = target as TalkAndChoseNode;
            JuqingGraph graph = node.graph as JuqingGraph;
            if (graph.current == node) GUI.color = Color.blue;
            string title = target.name;
            GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
            GUI.color = Color.white;
        }

        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
            TalkAndChoseNode node = target as TalkAndChoseNode;
            JuqingGraph graph = node.graph as JuqingGraph;
            if (GUILayout.Button("set to current"))
            {
                graph.current = node;
            }
        }
    }
}

