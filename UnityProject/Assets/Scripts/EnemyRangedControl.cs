using UnityEngine;
using System.Collections;

public class EnemyRangedControl : MonoBehaviour
{

    public int hp = 10;

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
