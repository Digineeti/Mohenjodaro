using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA : MonoBehaviour
{
    public GameObject TurnUiPanel;                          //declaring TurnUi State object 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Globalvariable.turnUi == true)
        {
            TurnUiPanel.SetActive(true);
        }
        else
        {
            TurnUiPanel.SetActive(false);
        }
    }
}
