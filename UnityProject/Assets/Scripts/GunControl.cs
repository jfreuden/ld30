using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour
{
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

        if (Input.GetMouseButtonDown(0)) //Shoot
        {

            Vector3 dir = relMouseNorm;
            Ray2D hitScan = new Ray2D(this.transform.position, dir);
            RaycastHit2D scan = Physics2D.Raycast(transform.position, dir);
            if (scan != null)
            {
                GameObject.Destroy(scan.collider.gameObject);
            }
            Debug.DrawRay(transform.position, relMouseNorm, Color.red, 10.0f, true);

        }
    }
}
