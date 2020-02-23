using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Scott : MonoBehaviour
{
    //public Rigidbody projectile;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;
    public LineRenderer lineVisual;
    public int lineSegment = 10;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        lineVisual.positionCount = lineSegment;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        if (Input.GetMouseButton(0))
        {
            Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //This is the point where out mouse cursor is

            if (Physics.Raycast(camRay, out hit, 100f, layer))
            {
                cursor.SetActive(true);
                cursor.transform.position = hit.point + Vector3.up * 0.1f;

                Vector3 vo = CalculateVelocty(hit.point, shootPoint.position, 1f);

                Visualize(vo);

                //transform.rotation = Quaternion.LookRotation(vo);
            }
        }
    }

    void Visualize(Vector3 vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, i / (float)lineSegment);
            lineVisual.SetPosition(i, pos);
        }
    }

    Vector3 CalculateVelocty(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first                 --------x---------Horizontal        |y| vertical

        Vector3 distance = target - origin;
        Vector3 distanceXz = distance; //Distance on the x&Z plane....This is the same vector as the X, only the y component of the Vector is zeroed out.
        distanceXz.y = 0f;

        //create a float to represent our distance
        float sY = distance.y; //vertical distance (peak) of the arc. Y.
        float sXz = distanceXz.magnitude; //

        //Horizontal velocity.......sxz xz plane distance
        float Vxz = sXz * time;
        //vertical velocity......
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        //get the normalized distance of the xz plane. Direction is returned. length will be 1 (normalized).
        Vector3 result = distanceXz.normalized;
        result *= Vxz; //multiply that direction by the horizontal plane velocity
        result.y = Vy; //Set its Y value to velocity of Y

        return result;
    }

    Vector3 CalculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        Vector3 result = shootPoint.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shootPoint.position.y;

        result.y = sY;

        return result;
    }
}