using UnityEngine;

public class PreventDoubleBuild : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Built>()==null)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void ResetGroundCollider()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out RaycastHit hit, Mathf.Infinity) == true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}