using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPosition.transform.position;
    }

    // called at a fixed framerate
    void FixedUpdate()
    {

    }
    
    public void Move()
    {
        
    }
}
