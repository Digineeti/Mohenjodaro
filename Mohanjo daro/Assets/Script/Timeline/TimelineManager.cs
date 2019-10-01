using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{

    private bool fix = false;
    public Animator playerAnimator;
    public RuntimeAnimatorController PlayerAnim;
    public PlayableDirector director;
    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerAnim = playerAnimator.runtimeAnimatorController;
        playerAnimator.runtimeAnimatorController = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(director.state != PlayState.Playing && !fix)
        {
            fix = true;
            playerAnimator.runtimeAnimatorController = PlayerAnim;
        }
    }
}
