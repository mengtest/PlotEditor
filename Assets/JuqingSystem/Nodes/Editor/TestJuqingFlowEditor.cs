using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode.Examples.JuqingGraph;

namespace XNodeEditor.Examples
{
    [CustomNodeEditor(typeof(TestJuqingFlow))]
    public class TestJuqingFlowEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
            JuqingGraph graph = target.graph as JuqingGraph;
            if (GUILayout.Button("Move to Start"))
            {
                graph.ResetToStart();
            }

            List<JuqingData> data = graph.current.exit;
            for (int i = 0; i < data.Count; i++)
            {
                JuqingData value = data[i];
                if (GUILayout.Button($"{value.talkString}"))
                {
                    graph.Continue(value);
                }
            }
        }
    }
}

