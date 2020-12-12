using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShow : MonoBehaviour
{
    [SerializeField] private bool active;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleShow()
    {
        active = !active;
        gameObject.SetActive(active);
        //TODO : Disable player movement
    }
}
