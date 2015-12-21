using UnityEngine;
using System.Collections;


public class CuboidWander : State<Cuboid>
{
    float wanderRadious = 4f;
    float wanderDistance = 1;
    float wanderJitter = 15f;
    float updateTargetTime = 2f;
    Vector3 wanderTarget = Vector3.zero;
    Vector3 jitterTarget = Vector3.zero;

    Coroutine wanderingCoroutine;

    public CuboidWander(Cuboid _owner) : base(_owner)
    {
    }

    public override void Enter()
    {
        wanderingCoroutine = owner.StartCoroutine(UpdateWanderTarget());
    }

    public override void Exit()
    {
        owner.StopCoroutine(wanderingCoroutine);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sm.ChangeState(new CuboidIdle(owner));
        }

        wanderTarget = owner.transform.position + (owner.transform.forward * wanderDistance) + (jitterTarget * wanderRadious);
        Debug.DrawLine(owner.transform.position, wanderTarget, Color.red);
        owner.LookAt(wanderTarget);
        owner.AddForce(owner.transform.forward);
    }

    IEnumerator UpdateWanderTarget()
    {
        while(true)
        {
            jitterTarget += new Vector3(Random.value * wanderJitter, 0, Random.value * wanderJitter);
            jitterTarget = jitterTarget.normalized;
            yield return new WaitForSeconds(updateTargetTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(wanderTarget,1);
    }
}

