using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Callingscriptableobject : MonoBehaviour
{
    #region variable
    public ScriptableUI Attribute;
    public TMP_Text Name;
    public Slider HPHealthBar;
    public Slider HPValue;
    public Slider SPValue;
    public TMP_Text Level;
    public TMP_Text EXP;
    public TMP_Text DEF;
    public TMP_Text MAT;
    public TMP_Text MDF;
    public TMP_Text AGI;
    public TMP_Text LUK;

    #endregion

    private void Start()
    {
        Name.text               = Attribute.name;

        HPHealthBar.maxValue    = Attribute.HPMax;
        HPHealthBar.value       = Attribute.HPMax;         //after call the current value here from playerpreref.
        HPValue.maxValue        = Attribute.HPMax;
        HPValue.value           = Attribute.HPMax;         //after call the current value here from playerpreref.
        SPValue.maxValue        = Attribute.SPMax;
        SPValue.value           = Attribute.SPMax;         //after call the current value here from playerpreref.

        Level.text              = Attribute.Level.ToString();
        EXP.text                = Attribute.Exp.ToString();
        DEF.text                = Attribute.DEF.ToString();
        MAT.text                = Attribute.MAT.ToString();
        MDF.text                = Attribute.MDF.ToString();
        AGI.text                = Attribute.AGI.ToString();
        LUK.text                = Attribute.Luk.ToString();

    }

}
