using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    public float moveH;
    public float moveV;

    public Vector3 touchDirection;

    public bool touchOverride = false;

    public Collider col;

    public LayerMask ground;

    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    public void Update(){

        touchOverride = false;

        if (Input.touchCount > 0){

            touchOverride = true;

            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            RaycastHit hit;

          if (Physics.Raycast(ray, out hit)){
              //Debug.Log(hit.point);
            }

        var curPosition = transform.position.With(y: 0);

        var hitPos = hit.point.With(y: 0);

        var touchDir = (hitPos - curPosition);

        touchDir = Vector3.Normalize(touchDir);

        touchDirection = touchDir;

        //Debug.Log(touchDirection);

        } else if (Input.touchCount == 0){
            touchDirection = Vector3.zero;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        velocity = rb.velocity;

        if (!touchOverride){
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");
        } else {
            moveH = touchDirection.x;
            moveV = touchDirection.z;
        }

        Vector3 moveVector = new Vector3(moveH, 0, moveV);
        moveVector = moveVector.normalized;

        RaycastHit hit2 = new RaycastHit();

        Vector3 transformCastPoint = transform.position + new Vector3(0, -col.bounds.extents.y + 0.01f, 0);

        Physics.Raycast(transformCastPoint, moveVector, out hit2, 1f, ground);


        float yVelocity = 0f;

        if (hit2.transform != null && hit2.collider != null){
            Debug.Log(hit2.normal);

            float slopeNormalX = Mathf.Abs(hit2.normal.x);
            float slopeNormalY = Mathf.Abs(hit2.normal.z);
            
            yVelocity = slopeNormalX;

            if (slopeNormalY > slopeNormalX){
                yVelocity = slopeNormalY;
            }
        }

        Vector3 movement = new Vector3(moveH, yVelocity, moveV);

        

        Debug.Log("Movement Vector3: " + movement);

        rb.AddForce(movement * speed);
        
    }
}
