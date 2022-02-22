using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float smooth = 0.1f;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * smooth;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * smooth;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * smooth;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * smooth;
        }
    }
}
