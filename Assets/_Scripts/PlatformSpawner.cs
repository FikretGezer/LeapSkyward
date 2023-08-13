using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platform")]
    [SerializeField] private Transform[] platforms;
    [SerializeField] private Transform _controlPoint;

    [Header("Background")]
    [SerializeField] private Transform[] backgrounds;
    private void Update() {  
        // foreach(var platform in platforms)
        // {
        //     if(platform.transform.position.y < _controlPoint.position.y)
        //     {
        //         platform.gameObject.SetActive(false);
        //         platform.position = new Vector2(platform.position.x, 2f * platforms.Length + platform.position.y);
        //         platform.gameObject.SetActive(true);
        //     }
        // }
        // foreach(var bg in backgrounds)
        // {
        //     if(bg.transform.position.y + 5f < _controlPoint.position.y)
        //     {
        //         bg.gameObject.SetActive(false);
        //         bg.position = new Vector2(bg.position.x, 10f * backgrounds.Length + bg.position.y);
        //         bg.gameObject.SetActive(true);
        //     }
        // }
        Repeater(platforms, 2f, 0f);
        Repeater(backgrounds, 10f, 5f);
    }
    private void Repeater(Transform[] objects, float height, float decider)
    {
        foreach(var obj in objects)
        {
            if(obj.transform.position.y + decider < _controlPoint.position.y)
            {
                obj.gameObject.SetActive(false);
                obj.position = new Vector2(obj.position.x, height * objects.Length + obj.position.y);
                obj.gameObject.SetActive(true);
            }
        }
    }
}
