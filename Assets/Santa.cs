using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    [SerializeField] int Health = 5;
    [SerializeField] int Speed = 2;
    [SerializeField] int currentWayPoint = 0;
    float accuray = 1f;
    
    Vector2 SantaPosition;
    BoxCollider2D boxCollider2;
    Rigidbody2D RB2D;

    public GameObject[] waypoints;

    private void Start()
    {
        boxCollider2 = GetComponent<BoxCollider2D>();
        RB2D = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (waypoints.Length == 0) return;
        Vector2 LookAtGoal = new Vector2(waypoints[currentWayPoint].transform.position.x, 
                                            waypoints[currentWayPoint].transform.position.y);
        SantaPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 MoveToGoal = LookAtGoal - SantaPosition;

        if (MoveToGoal.magnitude < accuray)
        {
            currentWayPoint++;
            if (currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }

        }     
        if(CheckGround2D())
       RB2D.AddForce(MoveToGoal.normalized * Time.fixedDeltaTime * Speed);
    }

    public void Jump(float X,float Y)
    {
        RB2D.AddForce(new Vector2(X,Y),ForceMode2D.Impulse);
    }

     bool CheckGround2D()
    {
        float HeightExtra = 0.5f;
       RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2.bounds.center, Vector2.down, boxCollider2.bounds.extents.y + HeightExtra);       
        Debug.DrawLine(boxCollider2.bounds.center, Vector2.down * (boxCollider2.bounds.extents.y + HeightExtra));
        return raycastHit.collider != null;
    }
}
