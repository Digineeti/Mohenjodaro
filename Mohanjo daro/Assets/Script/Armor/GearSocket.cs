using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearSocket : MonoBehaviour
{

    public Animator myAnimator { get; set; }
    private SpriteRenderer spriteRenderer;
    public AnimatorOverrideController animatorOverrideController;
    private Animator parentAnimator;

    public  Armor equippedArmor;
    private Image icon;

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentAnimator = GetComponentInParent<Animator>();
        myAnimator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(myAnimator.runtimeAnimatorController);
        myAnimator.runtimeAnimatorController = animatorOverrideController;
        //equippedArmor = GetComponent<Armor>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (equippedArmor.AnimationClips != null)
        {
            Equip(equippedArmor.AnimationClips);
        }
    }

    public void Equip(AnimationClip[] animations)
    {
        spriteRenderer.color = Color.white;
        animatorOverrideController["Idle_down"] = animations[0];
        animatorOverrideController["Idle_left"] = animations[1];
        animatorOverrideController["Idle_right"] = animations[2];
        animatorOverrideController["Idle_Up"] = animations[3];

        animatorOverrideController["Walking_down"] = animations[4];
        animatorOverrideController["Walking_Left"] = animations[5];
        animatorOverrideController["Walking_Right"] = animations[6];
        animatorOverrideController["Walking_up"] = animations[7];

        
    }

    public void Dequip()
    {
        animatorOverrideController["Idle_down"] = null;
        animatorOverrideController["Idle_left"] = null;
        animatorOverrideController["Idle_right"] = null;
        animatorOverrideController["Idle_Up"] = null;

        animatorOverrideController["Walking_down"] = null;
        animatorOverrideController["Walking_Left"] = null;
        animatorOverrideController["Walking_Right"] = null;
        animatorOverrideController["Walking_up"] = null;

        Color c = spriteRenderer.color;
        c.a = 0;
        spriteRenderer.color = c;
    }

    public void SetXandY(float x, float y,Vector2 lastMove, bool PlayerMoving)
    {
        if(Globalvariable.Dialogue_Open==false)
        {
            myAnimator.SetFloat("MoveX", x);
            myAnimator.SetFloat("MoveY", y);
            myAnimator.SetBool("PlayerMoving", PlayerMoving);
            myAnimator.SetFloat("LastMoveX", lastMove.x);
            myAnimator.SetFloat("LastMoveY", lastMove.y);
        }
        else
        {            
            myAnimator.SetBool("PlayerMoving", false);
            myAnimator.SetFloat("LastMoveX", lastMove.x);
            myAnimator.SetFloat("LastMoveY", lastMove.y);
        }
        

    }

    public void Activate_Layer(string layerName)
    {
        for(int i=0;i<myAnimator.layerCount;i++)
        {
            myAnimator.SetLayerWeight(i,0);
        }
        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
    }
    //public void EquipArmor(Armor armor)
    //{
    //    if(equippedArmor.AnimationClips!=null)
    //    {
    //        Equip(equippedArmor.AnimationClips);
    //    }
    //}
}
