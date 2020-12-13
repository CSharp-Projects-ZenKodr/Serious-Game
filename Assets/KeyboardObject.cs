using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MainLogic mainLogic;
    [SerializeField] private string objName;
    private bool inButtonRange = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inButtonRange) {
            if (Input.GetKeyDown(KeyCode.Space))
                mainLogic.Event(this.objName, true);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            inButtonRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            inButtonRange = false;
        }
    }
}
