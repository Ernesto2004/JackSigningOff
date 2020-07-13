using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraMain : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    public float smoothTime = .5f;

    private Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 30f;
    public float zoomLimiter = 60f;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {


        if (targets.Count == 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null){
                targets[0] = player.transform;
            }else{
                print("Couldn't find the player object.");
            }
            return;
        }

        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
