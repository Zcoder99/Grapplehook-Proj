using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : HeroKnight
{

    private Camera p_camera;
    private LineRenderer p_lineRenderer;
    private DistanceJoint2D p_distanceJoint2D;

    // Start is called before the first frame update
    void Start()
    {
        p_distanceJoint2D.enabled = false;
    }
    public Grappler(Camera p_camera, LineRenderer p_lineRenderer, DistanceJoint2D p_distanceJoint2D)
    {
        this.p_camera = p_camera;
        this.p_lineRenderer = p_lineRenderer;
        this.p_distanceJoint2D = p_distanceJoint2D;
    }


    // Update is called once per frame
    void Update()
    {
        
        // on "e" key press set distancejoin ancor to mouse position
        if (Input.GetKeyDown(KeyCode.E))
        {
            // mousepoiner object represents the vector poin that will be set to the mouses position.
            Vector2 mousepointer = (Vector2)p_camera.ScreenToViewportPoint(Input.mousePosition);

            p_lineRenderer.SetPosition(0, mousepointer); // Draws the vertex 
            p_lineRenderer.SetPosition(1, transform.position);
            p_distanceJoint2D.connectedAnchor = mousepointer;
            p_distanceJoint2D.enabled = true;
            p_lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            p_distanceJoint2D.enabled = false;
            p_lineRenderer.enabled = false;
        }
        if (p_distanceJoint2D.enabled)
        {
            p_lineRenderer.SetPosition(1, transform.position);
        }
    }
}
