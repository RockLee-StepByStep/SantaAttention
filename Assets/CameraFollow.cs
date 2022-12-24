using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public GameObject santa;
   [SerializeField] Vector2 cameraPos;
    Vector2 santaPos;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        santaPos = new Vector2(santa.transform.position.x, santa.transform.position.y);
        transform.position = santaPos + cameraPos;   
    }
}
