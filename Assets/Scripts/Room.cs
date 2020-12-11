using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    protected int index=0;

    protected GameObject mainCamera;
    public Animator doorAnimator;

    public GameObject door;
    private bool levelFinished = false;

    public Text explanationTab;
    public Text explanation;
    public Text explanationVariable;


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
        setRoomHelpText(index);
        

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

    public virtual void setRoomHelpText(int index)
    {
        if(index == 0)
        {
            explanationTab.text = "Welcome !";
            explanation.text = "Welcome to CodeLocks !\n" +
                "Your goal is to escape from this house, by gathering all the keys scattered around." +
                "This menu is here to help you, but only if you need it :)\n" +
                "Press ESCAPE or the ? button to open or close me.";
        }
        if(index == 1)
        {
            explanationTab.text = "IF THEN";
            explanation.text = "If is called an operator. It works like + or -, except it only needs one object.\n" +
                "[If(Something) Then] tests if Something is true or false. If it is, you need to do everything inside the Then box.\n" +
                "Else, you skip over the instructions.\n\n" +
                "Try for yourself !";
        }

        //TODO KEVIN : faire toutes les explications + tab
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
