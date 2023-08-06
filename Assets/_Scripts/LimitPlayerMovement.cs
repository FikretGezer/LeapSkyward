using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayerMovement : MonoBehaviour
{
    private Camera _camera;

    private Vector2 screenBounds;
    private float objectWidth;
    
    private void Awake() {
        _camera = Camera.main;
        screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x  / 2;
    }
    private void LateUpdate() {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1f - objectWidth);
        transform.position = viewPos;
    }
}
