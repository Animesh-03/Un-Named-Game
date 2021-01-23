using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedGrapple : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 playerPos;
    private Vector3 direction;
    private Vector3 localPos;

    private Camera camera;
    public GameObject player;
    public LayerMask ground;
    private SpringJoint2D springJoint;
    private GameObject hitObj;
    private LineRenderer lineRenderer;

    public float grappleDistLimit;
    public float grappleDistFac;

    private bool isGrappling;



    void Start() 
    {
        camera = Camera.main;
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
        isGrappling = false;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }
    


     void Update() 
    {
        GetMousePos();
        playerPos = player.transform.position;
        direction = mousePos - playerPos;
        RaycastHit2D hit = Physics2D.Raycast(playerPos,direction,Mathf.Infinity,ground);
        

        if(hit.collider != null)
        {
            if(hit.distance <= grappleDistLimit)
            {
                if(Input.GetMouseButtonDown(0) && isGrappling == false)
                {
                    hitObj = hit.collider.gameObject;
                    localPos = hit.point - (Vector2)hit.transform.position;
                    springJoint.enabled = true;
                    springJoint.distance = direction.magnitude*grappleDistFac;
                    isGrappling = true;
                    lineRenderer.positionCount = 2;
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            springJoint.connectedAnchor = hitObj.transform.position + localPos;
            DrawLine();
        }
        
        if (Input.GetMouseButtonUp(0) && isGrappling == true)
        {
            springJoint.enabled = false;
            isGrappling = false;
            lineRenderer.positionCount = 0;
        }


    }
    
    void GetMousePos()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void DrawLine()
    {
        lineRenderer.SetPosition(0,playerPos);
        lineRenderer.SetPosition(1,hitObj.transform.position + localPos);
    }
}
