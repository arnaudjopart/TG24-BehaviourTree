
using System;
using System.Collections.Generic;

namespace ajc.BehaviourTree
{
    public class BehaviourTree
    {
        public BehaviourTree()
        {
            m_nodes = new List<Node>();
        }
        public List<Node> m_nodes;
        private int m_index;
        
        public void Tick(float _deltaTime)
        {
            var status = m_nodes[m_index].Process(_deltaTime);
            switch (status)
            {
                case Node.STATUS.Success:
                    m_index++;
                    m_index %= m_nodes.Count;
                    break;
                case Node.STATUS.Failure:
                    m_index = 0;
                    break;
                case Node.STATUS.Running:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void AddNode(Node _node)
        {
            m_nodes.Add(_node);
        }
    }
}