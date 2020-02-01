using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindFunnelController : MonoBehaviour
{

    [SerializeField] private bool WindFunnelToggle = false;
    public float speed = 10f;                               // How fast we rotate
    private GameObject fanModel;                             // What we rotate


    private void Start()
    {
        fanModel = gameObject.transform.parent.GetChild(3).gameObject;
    }


    private void OnDisable()
    {
        // Stops the Fan
        fanModel.transform.Rotate(Vector3.up * 0);
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        // Rotates the Fan
        fanModel.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        gameObject.SetActive(true);
    }

}
