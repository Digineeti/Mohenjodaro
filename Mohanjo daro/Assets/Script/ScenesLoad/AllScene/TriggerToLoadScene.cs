using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToLoadScene : MonoBehaviour
{
    public string LoadName;
    public string UnloadName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LoadName != "")
            AllMainSceneLoad.Instance.Load(LoadName);

        if (UnloadName != "")
            StartCoroutine("UnloadScene");
    }

    IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(.01f);
        AllMainSceneLoad.Instance.Unload(UnloadName);
    }
}
