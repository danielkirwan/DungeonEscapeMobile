using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(float speed)
    {
        _anim.SetFloat("Speed", Mathf.Abs(speed));
    }

    public void JumpPlayer(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
        Debug.Log("Jumping is " + jumping);
    }


}
