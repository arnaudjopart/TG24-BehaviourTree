
namespace ajc.BehaviourTree
{
    public abstract class Node
    {
        public Node(string _name)
        {
            Name = _name;
        }

        public readonly string Name;

        public enum STATUS
        {
            Running,
            Success,
            Failure
        }
        
        
        
        public abstract STATUS Process(float _deltaTime);
    }
}