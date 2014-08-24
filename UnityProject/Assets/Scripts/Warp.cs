using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (this.name)
        {
            case "Warp1":
                Application.LoadLevel("infil");
                break;
            case "Warp2":
                Application.LoadLevel("escape");
                break;
            case "Warp3":
                Application.LoadLevel("ending");
                break;
        }	
    }	
    // Update is called once per frame
    void Update()
    {

    }
}
