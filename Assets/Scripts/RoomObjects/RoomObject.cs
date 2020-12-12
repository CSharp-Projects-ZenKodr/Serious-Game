using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
    private MainLogic mainLogic = null;
    public string objName;
    // Start is called before the first frame update
    void Start()
    {
        mainLogic = GameObject.Find("LogicTreatment").GetComponent<MainLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            mainLogic.Event(this.objName,true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            mainLogic.Event(this.objName,false);
        }
    }
    
}
