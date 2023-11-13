using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
using UnityEngine.AI;

[Action("MyActions/Hide")]
[Help("Get the Vector3 for hiding.")]
public class HideBB : BasePrimitiveAction
{
    [InParam("game object")]
    [Help("Game object to add the component, if no assigned the component is added to the game object of this behavior")]
    public GameObject targetGameobject;

    [OutParam("hide")]
    [Help("Vector3 for higing.")]
    public Vector3 hide;

    public override TaskStatus OnUpdate()
    {
        AIMovement moves = targetGameobject.GetComponent<AIMovement>();
        Animator animator = targetGameobject.GetComponent<Animator>();
        NavMeshAgent navMeshAgent = targetGameobject.GetComponent<NavMeshAgent>();

        navMeshAgent.speed = 4;

        if (navMeshAgent.remainingDistance < 0.2)
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", false);
        }

        moves.Hide();
        
        hide = moves.hideValue;

        return TaskStatus.COMPLETED;
    }
}

