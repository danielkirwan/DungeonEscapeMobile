using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    [SerializeField] private SpriteRenderer _mossSprite;
    [SerializeField] private Animator _mossAnimator;
    private void Start()
    {
        
    }

    public override void Update()
    {
        if(_mossAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            Debug.Log("Animation is idle");
            return;
        }

        MossMovement();
    }

    void MossMovement()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _mossSprite.flipX = false;
            _mossAnimator.SetTrigger("idle");
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _mossSprite.flipX = true;
            _mossAnimator.SetTrigger("idle");
        }

       transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }
}
