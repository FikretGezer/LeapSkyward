using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _currentPlatform;

    [Header("Grounded Properties")]
    [SerializeField] private Transform _groundObjectTransform;
    [SerializeField] private float _groundDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb;
    private bool isGrounded;
    private bool isJumped;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveWithPlatform();
        Controls();
    }
    private void FixedUpdate() {
        float hor = Input.GetAxis("Horizontal");
        isGrounded = Grounded();
        FundamentalMovements(hor);
        ResetParameters();
    }
    private void Controls()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumped = true;
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
                isJumped = true;
        }
    }
    private void FundamentalMovements(float hor)
    {
        if(hor != 0)
        {
            _rb.velocity = new Vector2(hor * _movementSpeed, _rb.velocity.y);
        }
        if(isJumped && isGrounded)
            _rb.AddForce(Vector2.up * _jumpForce);
    }
    private void ResetParameters()
    {
        isJumped = false;
    }
    private void MoveWithPlatform()
    {
        if(_currentPlatform != null)
            transform.parent  = _currentPlatform;
        else
            transform.parent = null;
    }
    private bool Grounded()
    {
        if(_rb.velocity.y <= 0)
        {
            Collider2D[] colObjects = Physics2D.OverlapCircleAll(_groundObjectTransform.position, _groundDistance, _groundLayer);
            foreach(var colObj in colObjects)
            {
                if(colObj.gameObject != gameObject) 
                {
                    return true;
                }
            }
        }
        return false;
        
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(isGrounded && other.gameObject.tag == "platform")
        {
            _currentPlatform = other.transform;
            ScoreManager.Instance.UpdateScore();
        }
        if(other.gameObject.tag == "wall")
        {
            var collingPoint = other.transform.position;
            var dir = transform.position - collingPoint;

        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(!isGrounded || other.gameObject.tag == "platform")
            _currentPlatform = null;
    }
    private void OnDrawGizmos() {
        Gizmos.color = isGrounded ? Color.blue : Color.red;
        Gizmos.DrawWireSphere(_groundObjectTransform.position, _groundDistance);
    }
}
