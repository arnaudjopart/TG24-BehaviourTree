namespace ajc.BehaviourTree
{
    public abstract class DecoratorNode : Node
    {
        public Node m_child;
        public abstract override STATUS Process(float _deltaTime);

        protected DecoratorNode(string _name) : base(_name)
        {
        }
    }
}