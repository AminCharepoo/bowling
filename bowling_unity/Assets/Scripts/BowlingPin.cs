using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private bool isFallen = false;
    public float fallenThreshold = 45f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFallen && (Mathf.Abs(transform.eulerAngles.x) > fallenThreshold || Mathf.Abs(transform.eulerAngles.z) > fallenThreshold))
        {
            isFallen = true;
            Debug.Log("Pin has fallen!");
            BowlingManager.Instance.AddScore(1);
            Destroy(gameObject, 2.0f);
        }
    }
}
