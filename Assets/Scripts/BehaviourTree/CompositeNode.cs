using System.Collections.Generic;

namespace ajc.BehaviourTree
{
    public abstract class CompositeNode : Node
    {

        public List<Node> m_children;
        public abstract override STATUS Process(float _deltaTime);

        protected CompositeNode(string _name) : base(_name)
        {
            m_children = new List<Node>();
        }

        public void AddNode(Node _node)
        {
            m_children.Add(_node);
        }
    }
}