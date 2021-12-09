using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaths : MonoBehaviour
{
    public Transform[] target;

    [SerializeField]
    float speed;

    int index = 0;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target[index].position, speed * Time.deltaTime);
        dist = Vector3.Distance(transform.position,target[index].position);
        if (dist<1)
        {
            index += 1;
            if(index == 4)
            {
                index = 0;
            }
        }
    }
}
