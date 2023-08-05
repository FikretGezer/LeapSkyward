using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Transform _platformsParent;
    [SerializeField] private GameObject _platformPrefab;
    private int platformSpawnCount = 10;

    private void Awake() {

        Vector2 startPos = new Vector2(0, -1.5f);
        for(int i = 0; 0 < platformSpawnCount; i++) 
        {
            Instantiate(_platformPrefab, startPos, Quaternion.identity);
            startPos.y += 2f;
        }
    }
}
