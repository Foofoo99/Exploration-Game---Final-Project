using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImages : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //rotate the images on the finishing screen
        transform.Rotate(new Vector3(Mathf.Pow(Random.Range(10, 50), 2) * Time.deltaTime, Mathf.Pow(Random.Range(10, 50), 2) * Time.deltaTime, Mathf.Pow(Random.Range(10, 50), 2) * Time.deltaTime));
    }
}
