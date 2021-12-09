using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndResults : MonoBehaviour
{
    [SerializeField]
    Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        CheckResult();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckResult()
    {
        if (GameManager.instance.lives == 0)
        {
            GetComponent<Text>().color = Color.red;
            resultText.text = "You Died";
        }
        else
        {
            GetComponent<Text>().color = Color.green;
            resultText.text = "You Winner";
        }
    }
}
