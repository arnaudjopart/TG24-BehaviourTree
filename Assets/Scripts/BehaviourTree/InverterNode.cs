namespace ajc.BehaviourTree
{
    public class InverterNode : DecoratorNode
    {
        public override STATUS Process(float _deltaTime)
        {
            var status = m_child.Process(_deltaTime);
            if (status == STATUS.Success) return STATUS.Failure;
            if (status == STATUS.Failure) return STATUS.Success;
            return STATUS.Running;
        }

        public InverterNode(string _name) : base(_name)
        {
        }
    }
}