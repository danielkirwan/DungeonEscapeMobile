﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    public virtual void Attack()
    {

    }

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

    }

    public virtual void Update() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            return;
        }

        Movement();
    }
}
