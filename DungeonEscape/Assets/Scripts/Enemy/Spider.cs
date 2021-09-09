using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    public void Damage()
    {
        Debug.Log("Damaged");
        Health--;
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
    public override void Init()
    {
        base.Init();
        Health = health;
    }
}
