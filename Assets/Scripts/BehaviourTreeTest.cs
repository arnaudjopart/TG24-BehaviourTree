using System;
using System.Collections.Generic;
using UnityEngine;
using ajc.BehaviourTree;
public class BehaviourTreeTest : MonoBehaviour
{
    private BehaviourTree m_behaviourTree;

    private Player m_player;
    [SerializeField] private int m_testHealth;
    [SerializeField] private float m_playerCurrentHealth;
    [SerializeField] private bool m_apply;

    private void Start()
    {
        m_player = new Player();
        m_player.SetHealth(m_testHealth);

        var firstSequence = new SequenceNode("Sequence #1")
        {
            m_children = new List<Node>()
            {
                new Leaf("Message 1", new TellSomethingStrategy("Sequence #1- Hello")),
                new Leaf("Message 1", new TellSomethingStrategy("Sequence #1- Second Message")),
                new Leaf("Waiting", new TellSomethingAfterSecondsStrategy("Sequence #1- Third Message", 1)),
            }
        };

        var secondSequence = new SequenceNode("Sequence #2")
        {
            m_children = new List<Node>()
            {
                new RepeatUntilFail()
                {

                    m_child = new SequenceNode("Check Health")
                    {
                        m_children = new List<Node>()
                        {
                            new Leaf("Check Player Health", new Condition(() => m_player.GetHealth() < 50)),
                            new Leaf("Heal Player", new HealPlayerStrategy(m_player)),
                            new Leaf("Player Health", new TellSomethingStrategy("Sequence #2- Player is Healed")),

                        }
                    }

                },
                new Leaf("Player Health", new TellSomethingStrategy("Sequence #2- Player Has Enough Health")),


            }
        };

        m_behaviourTree = new BehaviourTree();
        m_behaviourTree.AddNode(firstSequence);
        m_behaviourTree.AddNode(secondSequence);
    }

    private void Update()
    {
        m_behaviourTree.Tick(Time.deltaTime);
        if (m_apply)
        {
            m_apply = false;
            m_player.SetHealth(m_testHealth);
        }
        m_playerCurrentHealth = m_player.GetHealth();
    }
}

internal class HealPlayerStrategy : IStrategy
{
    private readonly IManageHealth m_agent;

    public HealPlayerStrategy(IManageHealth _agent)
    {
        m_agent = _agent;
    }
    public Node.STATUS Process(float _deltaTime)
    {
        var currentHealth = m_agent.GetHealth();
        currentHealth += 5 * _deltaTime;
        m_agent.SetHealth(currentHealth);
        return currentHealth > 90 ? Node.STATUS.Success : Node.STATUS.Running;
    }
}

public class Condition : IStrategy
{
    private readonly Func<bool> m_test;

    public Condition(Func<bool> _test)
    {
        m_test = _test;
    }

    public Node.STATUS Process(float _deltaTime) => m_test() ? Node.STATUS.Success : Node.STATUS.Failure;
}

public class ActionStrategy : IStrategy
{
    private readonly Action m_action;

    public ActionStrategy(Action _doSomething)
    {
        m_action = _doSomething;
    }

    public Node.STATUS Process(float _deltaTime)
    {
        m_action();
        return Node.STATUS.Success;
    } 
    
}
internal class Player : IManageHealth
{
    private float m_health;

    public Player()
    {
        
    }
    public float GetHealth()
    {
        return m_health;
    }

    public void SetHealth(float _amount)
    {
        m_health = _amount;
    }
}

internal interface IManageHealth
{
    public float GetHealth();
    public void SetHealth(float _amount);
    
}