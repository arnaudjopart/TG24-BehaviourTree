namespace ajc.BehaviourTree
{
    public interface IStrategy
    {
        Node.STATUS Process(float _deltaTime);
    }
}