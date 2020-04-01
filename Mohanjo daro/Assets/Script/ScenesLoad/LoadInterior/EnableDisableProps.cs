using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableProps : MonoBehaviour
{
    public static EnableDisableProps instance;

    public EnableDisableProps()
    {
        instance = this;
    }

    public void makeActive()
    {
        gameObject.SetActive(true);
    }
    public void makeInActive()
    {
        gameObject.SetActive(false);
    }
}
