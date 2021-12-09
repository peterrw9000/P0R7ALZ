using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public Transform portal1;
    public Transform portal2;

    [SerializeField]
    float speed = 1;
    [SerializeField]
    float jump = 1;
    [SerializeField]
    Transform cam;

    private bool grounded;
    float portal1RotationNum;
    float portal2RotationNum;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();
        Vector3 moveDirection = (camForward * v * speed) + (camRight * h * speed);
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                Jump();
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Ray r = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(r,out hit))
            {
                if(hit.transform.tag == "Wall")
                {
                    portal1.position = hit.point;
                    portal1.transform.rotation = Quaternion.FromToRotation(transform.forward, hit.normal * -1);
                    portal1.transform.rotation = Quaternion.FromToRotation(transform.up, transform.up * -1);
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Ray r = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.transform.tag == "Wall")
                {
                    portal2.position = hit.point;
                    portal2.transform.rotation = Quaternion.FromToRotation(transform.forward, hit.normal * -1);
                    portal2.transform.rotation = Quaternion.FromToRotation(transform.up, transform.up * -1);
                    //portal2.transform.forward = transform.Translate(transform.forward, 10);
                }
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathZone")
        {
            SceneManager.LoadScene(1);
            GameManager.instance.score = 0;
            GameManager.instance.lives = 0;
        }
        else if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.lives -= 1;
            if(GameManager.instance.lives == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
