// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Serialization;
//
// public class characterController : MonoBehaviour
// {
//     public float accelaration = 10f;
//
//     public float maxspeed = 10f;
//
//     public float jumpImpulse = 50f;
//
//     public bool isGrounded;
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     private void FixedUpdate()
//     {
//         
//     }
//     
//
//     // Updat
//     // e is called once per frame
//     void Update()
//     {
//         float horizontalMovement = Input.GetAxis("Horizontal");
//         Debug.Log(horizontalMovement);
//         Rigidbody rb = GetComponent<Rigidbody>();
//         rb.velocity += Vector3.right * horizontalMovement * Time.deltaTime * accelaration;
//
//         Collider col = GetComponent<Collider>();
//         float halfHeight = col.bounds.extents.y + 0.00f;
//         
//         Vector3 startPoint = transform.position;
//         Vector3 endPoint = startPoint + Vector3.down * halfHeight;
//         
//         isGrounded = (Physics.Raycast(startPoint, Vector3.down, 1f));
//         Color line = isGrounded ? Color.red : Color.green;
//         Debug.DrawLine(startPoint, endPoint, Color.blue, 0f, true);
//         
//         if ( isGrounded && Input.GetKeyDown(KeyCode.Space))
//         {
//             rb.AddForce(Vector3.up* jumpImpulse, ForceMode.Impulse);
//         }
//         if (Math.Abs(rb.velocity.x) > maxspeed)
//         {
//             Vector3 newval = rb.velocity;
//             newval.x = Math.Clamp(newval,-maxspeed, maxspeed);
//             rb.velocity = newval;
//         }
//
//        
//        
//        
//         
//        
//     }
// }
