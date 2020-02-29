using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Camera))]

public class Dynamic_Cam : MonoBehaviour
{
    
	public List<Transform> targets;

	public Vector3 offset;
	public float smoothTime = .5f;

	public float minZoom = 40f;
	public float maxZoom = 10f;
	public float zoomLimiter = 50f;

	private Vector3 velocity;
	private Camera cam;

	void Start()
	{
		if (Game.Instance == null) return;
		cam = GetComponent<Camera>();
		targets = new List<Transform>();
		foreach (Transform player in GameObject.Find("Players").transform)
		{
			targets.Add(player.GetChild(0).GetComponent<Player>().hips.transform);
		}
	}

    public void Update()
    {
        if (transform.position.y > 14.95f)
        {

        }
    }


    public void LateUpdate()
	{
		if (targets.Count == 0)
		{
			return;
		}

		Move();
		Zoom();
	}

	public void Zoom()
	{
		float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
	}

	public void Move()
	{
		Vector3 centerPoint = GetCenterPoint();

		Vector3 newPosition = centerPoint + offset;

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
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
