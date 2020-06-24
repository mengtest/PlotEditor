using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.Examples.JuqingGraph
{
    public class TalkAndChoseNode : Node
    {
        public string question = "";
        [Input] public JuqingData enter;
        [Output(ShowBackingValue.Never, ConnectionType.Multiple, true)] public List<JuqingData> exit = new List<JuqingData>();

        public void MoveNextTalk(JuqingData next)
        {
            JuqingGraph mGraph = graph as JuqingGraph;
            if (mGraph.current != this)
            {
                Debug.LogWarning("TalkAndChoseNode MoveNextTalk maybe config error");
                return;
            }

            int nextId = exit.IndexOf(next);
            NodePort nextPort = GetOutputPort($"exit {nextId}");

            if (!nextPort.IsConnected)
            {
                // todo 理论上对话end
                Debug.LogWarning("TalkAndChoseNode MoveNextTalk IsConnected error");
                mGraph.End();
                return;
            }

            TalkAndChoseNode target = nextPort.Connection.node as TalkAndChoseNode;
            target.OnEnter();
        }

        public void OnEnter()
        {
            JuqingGraph fmGraph = graph as JuqingGraph;
            fmGraph.current = this;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }

    [Serializable]
    public class JuqingData
    {
        [SerializeField]
        public string talkString = "";
    }
}

