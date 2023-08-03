using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 1f;
    [SerializeField] private Vector2[] _movementPositions;

    private float _current, _target;
    private Vector2 _moveTarget;
    // Start is called before the first frame update
    private void Awake() {
        _lerpSpeed = Random.Range(0.1f, 0.2f);
    }
    void Start()
    {
        transform.position = _movementPositions[0];
        _moveTarget = _movementPositions[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) _target = _target == 0 ? 1 : 0;
        _current = Mathf.MoveTowards(_current, _target, _lerpSpeed * Time.deltaTime);
        if(_current == _target) _target = _current == 1 ? 0 : 1;        
        
        transform.position = Vector2.Lerp(_movementPositions[0], _movementPositions[1], _current);
    }
}
