namespace ajc.BehaviourTree
{
    public class SequenceNode : CompositeNode
    {

        private int m_index;
    
        public override STATUS Process(float _deltaTime)
        {
            var childProgressStatus = m_children[m_index].Process(_deltaTime);
            switch (childProgressStatus)
            {
                case STATUS.Failure:
                    m_index = 0;
                    return STATUS.Failure;
                case STATUS.Success:
                {
                    m_index += 1;
                    if (m_index < m_children.Count) return STATUS.Running;
                    m_index = 0;
                    return STATUS.Success;
                }default:
                    return STATUS.Running;
            }
            
        }

        public SequenceNode(string _name) : base(_name)
        {
        }
    }
}