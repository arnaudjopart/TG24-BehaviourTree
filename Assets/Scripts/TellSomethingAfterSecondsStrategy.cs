using ajc.BehaviourTree;
using UnityEngine;

internal class TellSomethingAfterSecondsStrategy : IStrategy
{
    private readonly string m_text;
    private readonly float m_timerData;
    private float m_timeLeft;

    public TellSomethingAfterSecondsStrategy(string _sequenceThirdMessage, float _i)
    {
        m_text = _sequenceThirdMessage;
        m_timerData = _i;
        m_timeLeft = _i;
    }

    public Node.STATUS Process(float _deltaTime)
    {
        m_timeLeft -= _deltaTime;
        if (!(m_timeLeft <= 0)) return Node.STATUS.Running;
            
        Debug.Log("TellSomethingAfterSecondsLeaf - "+m_text);
        Reset();
        return Node.STATUS.Success;
    }

    private void Reset()
    {
        m_timeLeft = m_timerData;
    }
}