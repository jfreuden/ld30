using UnityEngine;
using System.Collections;

public class EnemyMeleeControl : MonoBehaviour
{

    int hp = 4;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            GameObject.Destroy(this.gameObject); //TODO: animate if time
    }
}
