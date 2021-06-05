using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerHealth ph;

    public Camera mainCam;
    public Transform followTransform;
    public float threshold;

    public EdgeCollider2D mapBounds;
    private float xMin, xMax, yMin, yMax;
    private float camY,camX;
    private float camOrthsize;
    private float cameraRatio;

    void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        mainCam.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, -10);
        
        if (ph.currentHealth > 0)
        {
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPos = (followTransform.position + mousePos);

            targetPos.x = Mathf.Clamp(targetPos.x, -threshold + followTransform.position.x, threshold + followTransform.position.x);
            targetPos.y = Mathf.Clamp(targetPos.y, -threshold + followTransform.position.y, threshold + followTransform.position.y);

            // targetPos.y = Mathf.Clamp(targetPos.y, yMin + camOrthsize, yMax - camOrthsize);
            // targetPos.x = Mathf.Clamp(targetPos.x, xMin + cameraRatio, xMax - cameraRatio);
            
            transform.position = targetPos;
        }
    }
}
