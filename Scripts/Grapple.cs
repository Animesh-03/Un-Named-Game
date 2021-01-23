using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    private Camera camera;
    private SpringJoint2D joint;
    private LineRenderer lineRend;
    public LayerMask ground;
    public Transform player;

    private Vector3 mousePos;
    private Vector3 playerPos;
    private Vector3 instMousePos;
    private Vector3 grappleDistVector;
    
    private float grappleDist;
    public float grappleCheckRad;
    public float grappleDistFac;
    public float grappleableDist;

    private bool isGrappleable;
    private bool isGrappling;
    
    
   
    void Start()
    {
        camera = Camera.main;
        joint = GetComponent<SpringJoint2D>();
        lineRend = GetComponent<LineRenderer>();
        joint.enabled = false;
        isGrappling = false;
        joint.distance = grappleDist;
        lineRend.positionCount = 0;

    }

    void Update()
    {
        GetMousePos();
        playerPos = player.transform.position;
        isGrappleable = Physics2D.OverlapCircle(mousePos,grappleCheckRad,ground);
        grappleDistVector = (playerPos - mousePos);
        grappleDist = grappleDistVector.magnitude;

        if (Input.GetMouseButtonDown(0) && isGrappling == false && isGrappleable == true && grappleDist <= grappleableDist)
        {            
            joint.enabled = true;
            joint.distance = grappleDist*grappleDistFac;
            joint.connectedAnchor = mousePos;
            instMousePos = mousePos;
            Debug.Log(grappleDist);
            isGrappling =  true;
            lineRend.positionCount = 2;

        }
        else if(Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            isGrappling =  false;
            lineRend.positionCount = 0;
        }
        DrawLine();

    }

    void GetMousePos()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void DrawLine()
    {
        if(lineRend.positionCount > 0)
        {
            lineRend.SetPosition(0,instMousePos);
            lineRend.SetPosition(1,playerPos);
        }
    }
}
