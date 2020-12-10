using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    protected int index=0;
    protected GameObject mainCamera;
    public Animator doorAnimator;
    // Start is called before the first frame update
    protected void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    protected void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.transform.parent.gameObject.GetComponent<MainLogic>().setCurrentRoom(this);
        print("You enter the room number "+index);
        mainCamera.transform.position = this.transform.position + new Vector3(0,0,-100);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        this.transform.parent.gameObject.GetComponent<MainLogic>().setCurrentRoom(null);
        print("You leave the room number " + index);
    }

    public virtual void Event(string objName)
    {  
        // To override
    }

    public virtual string GetRoomVariablesToDisplay()
    {
        // To override
        print("aled");
        return null;
    }

    public virtual string GetRoomCodeToDisplay()
    {
        // To override
        print("aled2");
        return null;
    }

    public string convertBool (bool b)
    {
        if(b)
        {
            return "<color=green>" + "True" + "</color>";
        }
        else
        {
            return "<color=red>" + "False" + "</color>";
        }
    }




}
