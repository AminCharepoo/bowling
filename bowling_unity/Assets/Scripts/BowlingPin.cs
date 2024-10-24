using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private bool isFallen = false;
    public float fallenThreshold = 45f;
    private Rigidbody RB;
    public float stopMovementThreshold = 0.1F;
    float elapsedTime = 0f;
    public float stopTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFallen && (Mathf.Abs(transform.eulerAngles.x) > fallenThreshold || Mathf.Abs(transform.eulerAngles.z) > fallenThreshold))
        {
            isFallen = true;
            Debug.Log("Pin has fallen!");
            BowlingManager.Instance.AddScore(1);
        }

        if (isFallen)
        {
            if (RB.velocity.magnitude < stopMovementThreshold)
            {
                elapsedTime += Time.deltaTime;
                
            }
            else
            {
                elapsedTime = 0f;
            }

            if (elapsedTime >= stopTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
