using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{ 
    private Animator animator;
    public List<string> animationNames; // 动画列表
    public string TriggerName;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 播放动画
    public void PlayAnimation(int animationIndex)
    {
        if (animator && animationIndex >= 0 && animationIndex < animationNames.Count)
        {
            string animationName = animationNames[animationIndex];
            animator.Play(animationName);
        }
    }

    // TRIGGER触发动画
    public void OnTriggerButtonClicked()
    {
        animator.SetTrigger(TriggerName); 
    }


}
