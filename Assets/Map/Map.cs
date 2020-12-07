using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject player;
    public int height;
    public int width;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale =  new Vector3(width,height,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
