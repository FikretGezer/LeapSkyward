using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private Transform _smokeEffectHolder;

    private int isJumpedHash;
    private int isRunningHash;
    private int isJumpingHash;

    private Animator _jumpEffectController;
    private Animator _characterAnimator;
    
    public static CharacterAnimations Instance;
    private void Awake() {
        if(Instance == null) Instance = this;

        _jumpEffectController = _smokeEffectHolder.GetChild(0).GetComponent<Animator>();
        _characterAnimator = transform.GetChild(0).GetComponent<Animator>();

        isJumpedHash = Animator.StringToHash("isJumped");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }
    public void JumpingAnimation(bool boolean)
    {
        _characterAnimator.SetBool(isJumpingHash, boolean);
    }
    public void RunningAnimation(bool boolean)
    {
        _characterAnimator.SetBool(isRunningHash, boolean);
    }
    public void PlaySmokeEffect(Vector2 pos)
    {
        _smokeEffectHolder.position = pos;
        _smokeEffectHolder.GetChild(0).gameObject.SetActive(true);
        _jumpEffectController.SetTrigger(isJumpedHash);
    }
    public void StopSmokeEffect()
    {
        _jumpEffectController.ResetTrigger(isJumpedHash);
        _smokeEffectHolder.GetChild(0).gameObject.SetActive(false);
    }
}
