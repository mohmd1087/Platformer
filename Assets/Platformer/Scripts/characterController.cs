using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class characterController : MonoBehaviour
{
    public float accelaration = 10f;

    public float maxspeed = 10f;

    public float jumpImpulse = 50f;
    public float jumpboost = 3f;
    public bool coinHit = false;
    public bool fall = false;
    public bool isGrounded;
    public bool headContact = false;
    public bool facingRight = true;
    private Rigidbody body;
    private Collider coll;
    private Transform transform;
    
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI scoreText;

    private static int _coinCount = 0;
    private static int _score = 0;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {

    }



    void Update()
    {
        float castDistancefeet = coll.bounds.extents.y + 1f;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, castDistancefeet);

        float castDistanceHead = coll.bounds.extents.y + 1f;
        headContact = Physics.Raycast(transform.position, Vector3.up, castDistanceHead);

        if (headContact)
        {
            Debug.Log("Head hit");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.up, out hit, 2f))
            {
                Debug.Log("Hit object: " + hit.transform.name);
            }
            

            if (hit.transform.CompareTag("brick"))
            {
                Destroy(hit.collider.gameObject);
                _score += 100;
                Debug.Log($"Score is {_score}");
                scoreText.text = $"Score\n{_score}";
            }
            else if (hit.transform.CompareTag("Question") && !fall)
            {
                Debug.Log("Hit Question");
                coinHit = true;
                fall = true;
                
            }
            else if (hit.transform.name == "Water(Clone)")
            {
                Debug.Log("Drowned in water");
                body.transform.position = new Vector3(4f, 0.57f, 0f);
            }
            else if (hit.transform.name == "Goal(Clone)")
            {
                Debug.Log("You have won");
            }
        }

        if (coinHit)
        {
            _coinCount++;
            _score += 100;
            coinsText.text = $"Coins\n{_coinCount}";
            scoreText.text = $"Score\n{_score}";
            coinHit = false;
        }

        float axis = Input.GetAxis("Horizontal");
        body.velocity += Vector3.right * axis * Time.deltaTime * accelaration;
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            body.AddForce(Vector3.up*jumpImpulse, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up*jumpboost, ForceMode.Force);
        }
      

        if (Math.Abs(body.velocity.x) > maxspeed)
        {
            float newval = maxspeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newval, body.velocity.y, body.velocity.z);
        }

        if (Math.Abs(axis) < 0.1)
        {
            float newval = body.velocity.x * (1f - Time.deltaTime * 5f);
            body.velocity = new Vector3(newval, body.velocity.y, body.velocity.z);
        }
        
        float speed = body.velocity.x;
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("Speed", Math.Abs(speed));
        anim.SetBool("In Air", !isGrounded);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxspeed = 15f;
            float newval = maxspeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newval, body.velocity.y, body.velocity.z);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxspeed = 10f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && facingRight)
        {
            transform.Rotate(Vector3.up * -180);
            facingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !facingRight)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = true;
        }

      


        // float horizontalMovement = Input.GetAxis("Horizontal");
        // Debug.Log(horizontalMovement);
        // Rigidbody rb = GetComponent<Rigidbody>();
        // rb.velocity += Vector3.right * horizontalMovement * Time.deltaTime * accelaration;
        //
        // Collider col = GetComponent<Collider>();
        // float halfHeight = col.bounds.extents.y + 0.03f;
        //
        // Vector3 startPoint = transform.position;
        // Vector3 endPoint = startPoint + Vector3.down * halfHeight;
        //
        // isGrounded = (Physics.Raycast(startPoint, Vector3.down, halfHeight));
        // Color line = (isGrounded) ? Color.red : Color.blue;
        // Debug.DrawLine(startPoint, endPoint, line, 0f, false);
        //
        // if ( isGrounded && Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.AddForce(Vector3.up* jumpImpulse, ForceMode.Impulse);
        // }
        // else if (!isGrounded && Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (rb.velocity.y > 0)
        //     {
        //         rb.AddForce(Vector3.up * jumpboost, ForceMode.Force);
        //     }
        //
        // }
        // if (Math.Abs(rb.velocity.x) > maxspeed)
        // {
        //     Vector3 newval = rb.velocity;
        //     newval.x = Math.Clamp(newval.x,-maxspeed, maxspeed);
        //     rb.velocity = newval;
        // }
        //
        // if (isGrounded && Math.Abs(horizontalMovement) < 0.5f)
        // {
        //     Vector3 newval = rb.velocity;
        //     newval.x *= 1f - Time.deltaTime;
        //     rb.velocity = newval;
        //
        // }
        // rb.velocity *= Math.Abs(horizontalMovement);
        //
        // float yaw = (rb.velocity.x > 0) ? 90 : -90;
        // transform.rotation = Quaternion.Euler(0f, yaw, 0f);
        //






    }
}