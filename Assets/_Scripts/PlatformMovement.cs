using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 1f;
    [SerializeField] private Vector2[] _movementPositions;
    
    private float _current, _target;
    private Vector2 _moveTarget, startPos;

    private void Awake() {
        _lerpSpeed = Random.Range(0.5f, 0.7f);

        startPos = _movementPositions[Random.Range(0, _movementPositions.Length)];

        if(_movementPositions[0] == startPos) _moveTarget = _movementPositions[1];
        else _moveTarget = _movementPositions[0];

        _moveTarget.y = startPos.y = transform.position.y;

        transform.position = startPos;
    }
    private void Start() {
    }
    void Update()
    {
        if(_current == _target) _target = _current == 1 ? 0 : 1;        
        _current = Mathf.MoveTowards(_current, _target, _lerpSpeed * Time.deltaTime);
        
        transform.position = Vector2.Lerp(startPos, _moveTarget, _current);
    }
}
