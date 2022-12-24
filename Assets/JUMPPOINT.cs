using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUMPPOINT : MonoBehaviour
{
    [SerializeField] float powerOfJumpX;
    [SerializeField] float powerOfJumpY;

    [SerializeField] bool CanJump = true;
    

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SANTA"))
        {
            

            
             print(1);
             collision.gameObject.GetComponent<Santa>().Jump(powerOfJumpX, powerOfJumpY);
             
            
            

        }
    }

}
