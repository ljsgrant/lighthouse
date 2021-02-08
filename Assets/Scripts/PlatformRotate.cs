using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{

    public Transform platform;
    public float platformRotateSpeed = 1.5f;
    public Transform rotateAround;
    private Vector3 rotate;
    [SerializeField] private int xRotate;
    [SerializeField] private int yRotate;
    [SerializeField] private int zRotate;

    // Start is called before the first frame update
    void Start()
    {
        rotate = new Vector3(xRotate, yRotate, zRotate);
    }

    // Update is called once per frame
    void Update()
    {
        platform.Rotate(rotate * platformRotateSpeed * Time.deltaTime);
    }
}
