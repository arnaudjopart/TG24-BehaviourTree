

namespace ajc.BehaviourTree
{
    public class RepeaterNode : DecoratorNode
    {
        public RepeaterNode(string _name,float _nbOfLoops=-1) : base(_name)
        {
            
        }
    
        public override STATUS Process(float _deltaTime)
        {
            var status = m_child.Process(_deltaTime);
            return STATUS.Success;
        }
    }
}