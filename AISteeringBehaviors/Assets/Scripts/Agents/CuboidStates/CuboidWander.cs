using UnityEngine;
using System.Collections;


public class CuboidWander : State<Cuboid>
{

    public CuboidWander(Cuboid _owner) : base(_owner)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sm.ChangeState(new CuboidIdle(owner));
        }


    }
    
    void OnDrawGizmosSelected()
    {
    }
}

