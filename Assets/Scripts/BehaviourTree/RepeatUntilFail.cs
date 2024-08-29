namespace ajc.BehaviourTree
{
    public class RepeatUntilFail : DecoratorNode
    {
        public override STATUS Process(float _deltaTime)
        {
            var status = m_child.Process(_deltaTime);
            return status switch
            {
                STATUS.Running => STATUS.Running,
                STATUS.Failure => STATUS.Success,
                _ => STATUS.Running
            };
        }

        public RepeatUntilFail(string _name="") : base(_name)
        {
        }
    }
}