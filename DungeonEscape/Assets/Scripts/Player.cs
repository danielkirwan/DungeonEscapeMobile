using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _speed;
    private bool _grounded = false;
    [SerializeField] private LayerMask _ground;
    private bool _resetJump = false;
    [SerializeField] private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);
        _anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);
        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    bool Grounded()
    {
       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _ground.value);
        
        if(hitInfo.collider != null)
        {
            if (!_resetJump)
            {
                return true;
            }
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

}
