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

    public bool touchOverride = true;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    public void Update(){

        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            RaycastHit hit;

          if (Physics.Raycast(ray, out hit)){
              Debug.Log(hit.point);
            }

        var curPosition = transform.position.With(y: 0);

        var hitPos = hit.point.With(y: 0);

        var touchDir = (hitPos - curPosition);

        touchDir = Vector3.Normalize(touchDir);

        touchDirection = touchDir;

        Debug.Log(touchDirection);

        } else if (Input.touchCount == 0){
            touchDirection = Vector3.zero;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!touchOverride){
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");
        } else {
            moveH = touchDirection.x;
            moveV = touchDirection.z;
        }


        

        Vector3 movement = new Vector3(moveH, 0f, moveV);

        rb.AddForce(movement * speed);
        
    }
}
