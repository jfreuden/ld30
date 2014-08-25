using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public bool running = false;
    int moveSpeed = 8;
    public bool mirror;
    public AudioClip jumpSound1;
    public AudioClip jumpSound2;
    public AudioClip jumpSound3;
    public AudioClip run1;
    public AudioClip run2;
    public AudioClip run3;
    public AudioClip run4;
    // Use this for initialization
    void Start()
    {
        mirror = false;
        //new WaitForSeconds (1);
    }

    void Update()
    {
        float horizont = Input.GetAxis("Horizontal");
        Animator stateAnim = this.GetComponent<Animator>();
        if (horizont == 0)
        {
            stateAnim.SetBool("running", false);
        } else
        {
            running = true;
            stateAnim.SetBool("running", true);
            switch (Random.Range(0, 3))
            {
                case 0:
                    if (!audio.isPlaying)
                    {
                        audio.clip = run1;
                        if ((!stateAnim.GetBool("falling")) & (!stateAnim.GetBool("jumping")))
                            audio.Play();
                    }

                    break;
                case 1:
                    if (!audio.isPlaying)
                    {
                        audio.clip = run2;
                        if ((!stateAnim.GetBool("falling")) & (!stateAnim.GetBool("jumping")))
                            audio.Play();
                    }
                    ;
                    break;
                case 2:
                    if (!audio.isPlaying)
                    {
                        audio.clip = run3;
                        if ((!stateAnim.GetBool("falling")) & (!stateAnim.GetBool("jumping")))
                            audio.Play();
                    }
                    break;
                case 3:
                    if (!audio.isPlaying)
                    {
                        audio.clip = run4;
                        if ((!stateAnim.GetBool("falling")) & (!stateAnim.GetBool("jumping")))
                            audio.Play();
                    }
                    break;

            }
        }
        if (horizont < 0)
        {
            mirror = true;
        } else if (horizont > 0)
        {
            mirror = false;
        }
        //determine direction of mouse pointing
        Vector3 mousePos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        Vector3 relMouse = mousePos - transform.position;
        Vector3 relMouseNorm = relMouse.normalized;
        if (relMouseNorm .x > 0)
        {
            mirror = false;
        } else
        {
            mirror = true;
        }
        if (mirror)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        this.transform.Translate(horizont * moveSpeed * Vector2.right * Time.deltaTime);

        //clamp location to map bounds (TODO: figure out what makes this screw up so often)
        CameraControl cameraScript = ScriptableObject.FindObjectOfType<CameraControl>();

        float clampedX = Mathf.Clamp(transform.position.x, cameraScript.levelBounds.min.x, cameraScript.levelBounds.max.x);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        if ((rigidbody2D.velocity.y < 0.01f) & (rigidbody2D.velocity.y > -0.01f))
        { //If not jumping (or otherwise moving up/down)
            stateAnim.SetBool("jumping", false);
            stateAnim.SetBool("falling", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                switch (Random.Range(0, 2))
                {
                    case 0:
                        audio.clip = jumpSound1;
                        break;
                    case 1:
                        audio.clip = jumpSound2;
                        break;
                    case 2:
                        audio.clip = jumpSound3;
                        break;
                }


                audio.Play();
            }
        } else if (rigidbody2D.velocity.y > 0)
        {
            stateAnim.SetBool("jumping", true);
            stateAnim.SetBool("falling", false);
        } else if (rigidbody2D.velocity.y < 0)
        {
            stateAnim.SetBool("falling", true);
            stateAnim.SetBool("jumping", false);
        }
    }
}
