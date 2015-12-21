using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Cuboid : MonoBehaviour
{
    public Stats stats;
    private StateMachine<Cuboid> sm;
    public Rigidbody rig;

	void Awake ()
    {
        rig = GetComponent<Rigidbody>();
        stats = new Stats(100, 5, 0.5f, 100, 100);
        sm = new StateMachine<Cuboid>(new CuboidWander(this));
	}
	
	void FixedUpdate ()
    {
        if (sm != null)
        {
            sm.Update();
        }
    }

    public void LookAt(Vector3 _target)
    {
        Vector3 lookTarget = Vector3.Normalize(_target - transform.position);
        Quaternion lookRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookTarget), stats.TurnSpeed);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.2f);
    }

    public void AddForce(Vector3 _direction)
    {
        rig.AddForce(_direction.normalized * stats.Speed);
    }
}
