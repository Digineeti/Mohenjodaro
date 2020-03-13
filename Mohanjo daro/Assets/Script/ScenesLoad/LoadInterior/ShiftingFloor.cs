using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShiftingFloor : MonoBehaviour
{
    public Tilemap InteriorgroundFloor;
    public Tilemap InteriorProps;
    public Tilemap InteriorFirstFloor;

    public GameObject FirstFloor;
    public GameObject GroundFloor;

    public Tilemap stair;


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
        //if (FirstFloor.gameObject.activeSelf)
        //{
        FirstFloor.SetActive(false);
        GroundFloor.SetActive(true);
        InteriorFirstFloor.gameObject.SetActive(true);
        stair.GetComponent<CompositeCollider2D>().isTrigger = true;
        InteriorgroundFloor.transform.GetChild(0).GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.3f);
        InteriorgroundFloor.transform.GetChild(1).GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.3f);
        InteriorgroundFloor.transform.GetChild(0).GetComponent<CompositeCollider2D>().isTrigger = true;

        InteriorProps.gameObject.SetActive(true);
        //}
      
        
    }
}
