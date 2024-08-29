namespace ajc.BehaviourTree
{
    public class Leaf : Node
    {
        private readonly IStrategy m_strategy;

        public Leaf(string _name, IStrategy _strategy) : base(_name)
        {
            m_strategy = _strategy;
            
        }
        public override STATUS Process(float _deltaTime)
        {
            return m_strategy.Process(_deltaTime);
        }
    }
}