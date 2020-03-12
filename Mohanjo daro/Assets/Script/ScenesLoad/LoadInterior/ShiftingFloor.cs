using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShiftingFloor : MonoBehaviour
{
    public Tilemap InteriorgroundFloor;
    public Tilemap InteriorProps;
    public Tilemap InteriorFirstFloor;

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
        Globalvariable.FloorShifting = !Globalvariable.FloorShifting;
        if (Globalvariable.FloorShifting)
        {
            InteriorFirstFloor.gameObject.SetActive(true);

            InteriorgroundFloor.transform.GetChild(0).GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.2f);
            InteriorgroundFloor.transform.GetChild(1).GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.2f);
            InteriorgroundFloor.transform.GetChild(0).GetComponent<CompositeCollider2D>().isTrigger = true; 
            InteriorProps.gameObject.SetActive(true);
        }
        else
        {
            InteriorFirstFloor.gameObject.SetActive(false);
            InteriorgroundFloor.transform.GetChild(0).GetComponent<Tilemap>().color = new Color(1, 1, 1, 1f);
            InteriorgroundFloor.transform.GetChild(1).GetComponent<Tilemap>().color = new Color(1, 1, 1, 1f);
            InteriorgroundFloor.transform.GetChild(0).GetComponent<CompositeCollider2D>().isTrigger = false;
          
        }

        
    }
}
