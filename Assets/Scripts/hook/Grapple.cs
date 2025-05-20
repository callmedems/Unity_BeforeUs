using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour{

    Rigidbody2D rb;
    LineRenderer lr;
    DistanceJoint2D dj;
    public LayerMask grappleLayer;
    public bool isGrappling;
    Vector3 point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        dj = GetComponent<DistanceJoint2D>();
        lr.enabled = false;
        dj.enabled = false;

        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.grey;
        lr.endColor = Color.grey;
        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;

    }

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0; 
            if(Physics2D.OverlapCircle(point,0.1f, grappleLayer)){
                isGrappling = true;
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, point);

                dj.enabled = true;
                dj.connectedAnchor = point;
            }
        }
        if(Input.GetMouseButtonUp(0)){
            isGrappling = false;
            lr.enabled = false;
            dj.enabled = false;
        }
        if(isGrappling){
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, point);
        }
    }
}
