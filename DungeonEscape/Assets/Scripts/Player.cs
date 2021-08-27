using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpForce = 5f;
    private bool _grounded = false;
    [SerializeField] private LayerMask _ground;
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
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _grounded = false;
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);   
        }else if (!_grounded)
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(this.transform.position, Vector2.down, 0.8f, _ground.value);
            Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.red);
            if (raycastHit2D.collider != null)
            {
                Debug.Log(raycastHit2D.collider.name);
                _grounded = true;
            }
        }
        

        _rb.velocity = new Vector2(horizontalInput, _rb.velocity.y);
    }

}
