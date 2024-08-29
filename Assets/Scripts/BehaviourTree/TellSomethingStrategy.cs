using UnityEngine;

namespace ajc.BehaviourTree
{
    public class TellSomethingStrategy : IStrategy
    {
        private readonly string m_text;

        public TellSomethingStrategy(string _text)
        {
            m_text = _text;
        }
        public Node.STATUS Process(float _deltaTime)
        {
            Debug.Log(m_text);
            return Node.STATUS.Success;
        }
        
        
        
    }

    public class MoveToDestinationStrategy : IStrategy
    {

        public MoveToDestinationStrategy(IMovableAgent _agent,Transform _destination)
        {
            
        }
        public Node.STATUS Process(float _deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IMovableAgent
    {
    }
}