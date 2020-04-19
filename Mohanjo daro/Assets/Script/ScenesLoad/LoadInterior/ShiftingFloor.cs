using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ShiftingFloor : MonoBehaviour
{
    //public Tilemap InteriorgroundFloor;
    //public Tilemap InteriorProps;
    //public Tilemap InteriorFirstFloor;

    //public GameObject FirstFloor;
    //public GameObject GroundFloor;

    //public GameObject stair;
    //public GameObject stair2;

    public GameObject Visible_floor;
    public GameObject Hide_Floor;




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

        Visible_floor.SetActive(true);
        Hide_Floor.SetActive(false);

        GameObject Exterior_Door1 = GameObject.Find("ExteriorDoor");
        GameObject Exterior_Door2 = GameObject.Find("ExteriorDoor2");

        //Exterior_Door1.SetActive(false);
        //Exterior_Door2.SetActive(false);


        Exterior_Door1.GetComponent<SpriteRenderer>().color= new Color(1f, 1f, 1f, 0f); 
        Exterior_Door2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

        if (Visible_floor.name== "GroundFloor")
        {
            Exterior_Door1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            Exterior_Door2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            //if(Visible_floor.activeSelf)
            //{
            //    Exterior_Door1.SetActive(true);
            //    Exterior_Door2.SetActive(true);
            //}

        }
        //if (Hide_Floor.name == "GroundFloor")
        //{
        //    if (Hide_Floor.activeSelf)
        //    {
        //        Exterior_Door1.SetActive(true);
        //        Exterior_Door2.SetActive(true);
        //    }          
        //}


        //Globalvariable.FloorShifting = !Globalvariable.FloorShifting;
        //if (FirstFloor.gameObject.activeSelf)
        //{
        ////FirstFloor.SetActive(false);
        ////GroundFloor.SetActive(true);
        ////InteriorFirstFloor.gameObject.SetActive(true);
        ////stair.GetComponent<EdgeCollider2D>().isTrigger = true;
        //////stair2.GetComponent<EdgeCollider2D>().isTrigger = true;
        ////InteriorgroundFloor.transform.GetChild(0).GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.3f);
        ////InteriorgroundFloor.transform.GetChild(1).GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.3f);
        ////InteriorgroundFloor.transform.GetChild(0).GetComponent<CompositeCollider2D>().isTrigger = true;

        ////InteriorProps.gameObject.SetActive(true);
        //}


    }
}
