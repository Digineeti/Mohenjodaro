using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ShiftingGroundfloor : MonoBehaviour
{

    public Tilemap InteriorgroundFloor;
    public Tilemap InteriorProps;
    public Tilemap InteriorFirstFloor;

    public GameObject FirstFloor;
    public GameObject GroundFloor;

    public GameObject stair;
    public GameObject stair2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {

            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {

        yield return new WaitForSeconds(0f);
        //Globalvariable.FloorShifting = !Globalvariable.FloorShifting;
        FirstFloor.SetActive(true);
        GroundFloor.SetActive(false);
        stair.GetComponent<EdgeCollider2D>().isTrigger = false;
        stair2.GetComponent<EdgeCollider2D>().isTrigger = false;

        InteriorFirstFloor.gameObject.SetActive(false);
        InteriorgroundFloor.transform.GetChild(0).GetComponent<Tilemap>().color = new Color(1, 1, 1, 1f);
        InteriorgroundFloor.transform.GetChild(1).GetComponent<Tilemap>().color = new Color(1, 1, 1, 1f);
        InteriorgroundFloor.transform.GetChild(0).GetComponent<CompositeCollider2D>().isTrigger = false;



    }

}
