using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCubeMovement : MonoBehaviour
{
    public Transform person;
    public Transform portal1;
    public Transform portal2;

    [SerializeField]
    float speed;

    float personDistance;
    float portal1Distance;
    float portal2Distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        personDistance = Vector3.Distance(transform.position, person.position);
        portal1Distance = Vector3.Distance(transform.position, portal1.position);
        portal2Distance = Vector3.Distance(transform.position, portal2.position);
        if (personDistance <= (portal1Distance + portal2Distance))
        {
            transform.position = Vector3.Lerp(transform.position, person.position, speed * Time.deltaTime);
        }
        else
        {
            if (portal1Distance < portal2Distance)
            {
                transform.position = Vector3.Lerp(transform.position, portal1.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, portal2.position, speed * Time.deltaTime);
            }
        }
    }
}
