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
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundObjectTransform;
    [SerializeField] private float _groundDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rb;
    private bool isGrounded;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isGrounded = Grounded();
        if(isGrounded)
            MoveWithPlatform();
    }
    private void FixedUpdate() {
        KeyboardControls();
        TouchControls();
    }
    private void KeyboardControls()
    {
        float hor = Input.GetAxis("Horizontal");
        if(hor != 0)
            _rb.velocity = new Vector2(hor * _movementSpeed * Time.deltaTime, _rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            _rb.AddForce(Vector2.up * _jumpForce);
    }
    private void TouchControls()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began && isGrounded)
                _rb.AddForce(Vector2.up * _jumpForce);
        }
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
        Collider2D[] colObjects = Physics2D.OverlapCircleAll(_groundObjectTransform.position, _groundDistance, _groundLayer);
        foreach(var colObj in colObjects)
        {
            if(colObj.gameObject != gameObject) 
            {
                return true;
            }
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(isGrounded && other.gameObject.tag == "platform")
            _currentPlatform = other.transform;
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(!isGrounded && other.gameObject.tag == "platform")
            _currentPlatform = null;
    }
    private void OnDrawGizmos() {
        Gizmos.color = isGrounded ? Color.blue : Color.red;
        Gizmos.DrawWireSphere(_groundObjectTransform.position, _groundDistance);
    }
}
