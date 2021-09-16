using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] private GameObject _acidPrefab;
    [SerializeField] Transform _acidFiringPosition;
    private bool _attack = true;
    public int Health { get; set; }

    public void Damage()
    {
        Debug.Log("Damaged");
        Health--;
        if (Health < 1)
        {
            anim.SetTrigger("death");
            Destroy(this.gameObject, 1.5f);
        }
    }
    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public override void Movement()
    {
        
    }

    public override void Attack()
    {
        GameObject acid = Instantiate(_acidPrefab, _acidFiringPosition.position, Quaternion.identity);
    }

    IEnumerator SpiderAttack()
    {
        //_attack = true;
        yield return new WaitForSeconds(2f);
        _attack = false;
        anim.SetBool("attack", _attack);
        yield return new WaitForSeconds(2f);
        _attack = true;
    }

    public override void Update()
    {
        if (_attack)
        {
            anim.SetBool("attack", _attack);
            StartCoroutine(SpiderAttack());
        }
    }

}
