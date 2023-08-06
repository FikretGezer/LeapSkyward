using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 1f;
    [SerializeField] private Vector2[] _movementPositions;
    
    private float _current, _target;
    private Vector2 _moveTarget, startPos;

    private void OnEnable() {
        _lerpSpeed = Random.Range(0.1f, 1.5f);

        startPos = _movementPositions[Random.Range(0, _movementPositions.Length)];

        if(_movementPositions[0] == startPos) _moveTarget = _movementPositions[1];
        else _moveTarget = _movementPositions[0];

        _moveTarget.y = startPos.y = transform.position.y;

        transform.position = startPos;
    }
    void Update()
    {
        if(_current == _target) _target = _current == 1 ? 0 : 1;        
        _current = Mathf.MoveTowards(_current, _target, _lerpSpeed * Time.deltaTime);
        //startPos.y = _moveTarget.y = transform.position.y;
        transform.position = Vector2.Lerp(startPos, _moveTarget, _current);
    }
}
