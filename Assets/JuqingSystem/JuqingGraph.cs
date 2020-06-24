using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.Examples.JuqingGraph
{
    [CreateAssetMenu(fileName = "New Juqing Graph", menuName = "xNode Examples/Juqing Graph")]
    public class JuqingGraph : NodeGraph
    {
        public TalkAndChoseNode start;
        public TalkAndChoseNode current;

        // public TalkAndChoseNode last;

        public void ResetToStart()
        {
            if (!CheckStart())
            {
                return;
            }

            current = start;
        }

        public void Continue(JuqingData next)
        {
            if (!CheckStart())
            {
                return;
            }

            if (!current)
            {
                Debug.LogError("JuqingGraph Continue: lost current");
                return;
            }

            current.MoveNextTalk(next);
        }

        public void End()
        {
            // todo
            current = null;
        }

        private bool CheckStart()
        {
            if (start)
            {
                return true;
            }

            Debug.LogError("JuqingGraph CheckStart: please set start node");
            return false;
        }
    }
}

