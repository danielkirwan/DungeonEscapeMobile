using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    //Child object takes over the calling of Init by overriding
    public override void Init()
    {
        base.Init();
    }
}
