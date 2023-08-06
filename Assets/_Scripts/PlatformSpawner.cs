using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] platforms;
    [SerializeField] private Transform _controlPoint;
    private void Update() {  
        foreach(var platform in platforms)
        {
            if(platform.transform.position.y < _controlPoint.position.y)
            {
                platform.gameObject.SetActive(false);
                platform.position = new Vector2(platform.position.x, 2f * platforms.Length + platform.position.y);
                platform.gameObject.SetActive(true);
            }
        }
    }
}
