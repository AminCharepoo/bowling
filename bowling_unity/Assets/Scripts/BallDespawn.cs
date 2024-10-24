using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallDespawn : MonoBehaviour
{
    private bool onAlley = false;
    private Rigidbody bRB;
    public float stopMovementThreshold = 0.1F;
    float elapsedTime = 0f;
    public float stopTime = 4f;
    float ultimateRemoveTimer = 20f;
    float ultimateTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bRB = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("alley"))
        {
            onAlley = true;
            Debug.Log("Ball touch alley");
        }

   
    
    }



    void  Update()
    {
        if (onAlley)
        {
            ultimateTime +=  Time.deltaTime;
            if (bRB.velocity.magnitude < stopMovementThreshold)
            {
                elapsedTime += Time.deltaTime;
                
            }
            else
            {
                elapsedTime = 0f;
            }

            if ((elapsedTime >= stopTime) || (ultimateTime >= ultimateRemoveTimer))
            {
                gameObject.SetActive(false);
            }
        }
    }
        
    
}
