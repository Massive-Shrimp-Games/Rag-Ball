using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject Cube;
    public void SpawnCube()
    {
        GameObject cube = Instantiate(Cube, transform.position, Quaternion.identity);
        cube.GetComponent<Rigidbody>().AddForce(Random.Range(100, 500), 0, Random.Range(100, 500));
    }
}
