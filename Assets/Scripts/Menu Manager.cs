using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas options;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            options.gameObject.SetActive(!options.gameObject.activeSelf);
        }
    }
}
