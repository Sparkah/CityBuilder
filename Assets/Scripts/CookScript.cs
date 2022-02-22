using UnityEngine;

public class CookScript : MonoBehaviour
{
    [SerializeField]
    private GameObject SandBlock;
    [SerializeField]
    private GameObject WaterBlock;
    [SerializeField]
    private GameObject SwampBlock;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    if(hit.collider.CompareTag("WaterBlock"))
                    {
                        Instantiate(SandBlock, hit.transform.position, Quaternion.identity);
                        Destroy(hit.collider.gameObject);
                    }
                    if (hit.collider.CompareTag("SwampBlock"))
                    {
                        Instantiate(WaterBlock, hit.transform.position, Quaternion.identity);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
