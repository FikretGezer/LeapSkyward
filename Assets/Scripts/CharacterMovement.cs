using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    [Header("Grounded Properties")]
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundObjectTransform;
    [SerializeField] private float _groundDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb;
    private Vector2 velocity;
    private bool isGrounded;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        
        isGrounded = Grounded();
        Debug.Log(isGrounded);
        if(hor != 0)
            _rb.velocity = new Vector2(hor * _movementSpeed * Time.deltaTime, _rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
        
    }
    private bool Grounded()
    {
        Collider2D col = Physics2D.OverlapCircle(_groundObjectTransform.position, _groundDistance, _groundLayer);
        if(col.gameObject != gameObject) return true;
        else return false;
    }
}
