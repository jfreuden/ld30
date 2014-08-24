using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour
{
    public Sprite normSprite;
    public Sprite fireSprite;
    public AudioClip Shoot1;
    public AudioClip Shoot2;
    void Update()
    {
        PlayerControl playerScript = ScriptableObject.FindObjectOfType<PlayerControl>();
        bool mirror = playerScript.mirror;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Camera.main.ScreenPointToRay (Input.mousePosition).origin;
        mousePos.z = 0;

        Vector3 relMouse = mousePos - transform.position;
        Vector3 relMouseNorm = relMouse.normalized;

        if (mirror)
        {
            relMouseNorm.x *= -1;
        }

        Quaternion rotateToMouse;
        rotateToMouse = Quaternion.FromToRotation(Vector3.right, relMouseNorm);
        transform.rotation = rotateToMouse;

        GetComponent<SpriteRenderer>().sprite = normSprite;

        if (Input.GetMouseButtonDown(0)) //Shoot
        {
            GetComponent<SpriteRenderer>().sprite = fireSprite;

            switch (Random.Range(0, 1))
            {
                case 0:
                    audio.clip = Shoot1;
                    audio.Play();
                    break;
                case 1:
                    audio.clip = Shoot2;
                    audio.Play();
                    break;
            }

            new WaitForSeconds(0.25f);
            Vector3 dir = relMouseNorm;
            //Ray2D hitScan = new Ray2D(, dir);

            //print(transform.position.ToString() + " : " + new Ray2D(transform.position, dir).GetPoint(10.0f).ToString());
            RaycastHit2D scan = Physics2D.Raycast(GetComponentInChildren<Transform>().position, mousePos - GetComponentInChildren<Transform>().position);
            if (scan != null)
            {
                print(scan.collider.gameObject.name);
                if (scan.collider.gameObject.tag == "Enemy")
                    GameObject.Destroy(scan.collider.gameObject);
            }
            Debug.DrawRay(GetComponentInChildren<Transform>().position, mousePos - GetComponentInChildren<Transform>().position, Color.red, 10.0f, true);

        }
    }
}
