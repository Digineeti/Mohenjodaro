using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ArmorType {Cloth,Hair}
[CreateAssetMenu(fileName ="Armor", menuName="Items/Armor",order =2)]
public class Armor : Item
{
    [SerializeField]
    private ArmorType armorType;
    [SerializeField]
    private int intellect;

    [SerializeField]
    private int strenght;
    [SerializeField]
    private int stamina;

    [SerializeField]
    private AnimationClip[] animationClip;

    internal ArmorType MyArmorType
    {
        get { return armorType; }
    }

    public AnimationClip [] AnimationClips
    {
        get
        {
            return animationClip;
        }
    }

    //public override string GetDescription()
    //{
    //    string stats = string.Empty;
    //    if(intellect>0)
    //    {
    //        stats += string.Format("\n+{0} intellect",intellect);
    //    }if(strenght > 0)
    //    {
    //        stats += string.Format("\n+{0} strenght", strenght);
    //    }if(stamina > 0)
    //    {
    //        stats += string.Format("\n+{0} stamina", stamina);
    //    }
    //    return base GetDescription() + stats;
    //}
    
    //public void Equip()
    //{
    //    characterPanel.MyInstance.EquipArmor(this);
    //}
}
