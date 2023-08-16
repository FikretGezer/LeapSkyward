using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _spacing = 1f; // How far should camera be in y axis
    [SerializeField] private float _lerpSpeed = 1f; // How far should camera be in y axis
    
    [SerializeField] private bool followCam;
    [SerializeField] private AudioClip _dyingClip;

    [Header("Camera Move Parameters")]
    [SerializeField] private float moveSpeed = 1f;

    private float highestY = -2f;
    private Camera _camera;
    private bool isClipPlayed;

    private void Awake() {
        _camera = Camera.main;
    }
    private void Update() {
        if(followCam)
        {
            var playerPos = _playerTransform.position;
            var camPos = transform.position;


            playerPos.x = 0f;
            playerPos.y += _spacing;

            if(playerPos.y > highestY)
                highestY = playerPos.y;

            if(playerPos.y > highestY)
                camPos = Vector2.Lerp(camPos, playerPos, _lerpSpeed * Time.deltaTime);

            camPos.y = Mathf.Clamp(camPos.y, highestY, Mathf.Infinity);

            transform.position = new Vector3(camPos.x, camPos.y, transform.position.z);
        }
        else
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector2.up);
        }

        Vector3 point = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0f));        
        if(_playerTransform.position.y + 0.7f < point.y)
        {
            Debug.Log("Shit");
            if(!isClipPlayed)
                SoundController.Instance.PlaySoundFX(_dyingClip, transform, 1f);
            isClipPlayed = true;
            ButtonController.Instance.EnableEndGameMenu();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
