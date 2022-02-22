using UnityEngine;

public class BuildingInfoManager : MonoBehaviour
{
    private int a = 0;
    private UIManager uI;

    private void Start()
    {
        uI = GameObject.FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null && hit.collider.GetComponent<CanBuildCheckScript>()!=null)
                {
                    Vector3 buildingPos = hit.collider.transform.position;
                    uI.DisplayBuildingInfo();
                    Transform MainBlock = hit.collider.gameObject.transform.parent;
                    MainBlock.gameObject.AddComponent<BlockCanBeDeletedScript>();
                    CanBuildCheckScript[] Blocks = MainBlock.GetComponentsInChildren<CanBuildCheckScript>();
                    foreach(CanBuildCheckScript Block in Blocks)
                    {
                        a += 1;
                    }

                    uI.BlockNumberText.text = a.ToString();
                    a = 0;
                    uI.KeepUIAtBuildingPosition(buildingPos);
                }
            }
        }
    }

    public void DeleteBlock()
    {
        if(FindObjectOfType<BlockCanBeDeletedScript>()!=null)
        {
            Destroy(FindObjectOfType<BlockCanBeDeletedScript>().gameObject);
            PreventDoubleBuild[] Ground = FindObjectsOfType<PreventDoubleBuild>();
            for(int i =0;i<Ground.Length;i++)
            {
                Ground[i].ResetGroundCollider();
            }
        }
    }

    public void RemoveDeletionScript()
    {
        BlockCanBeDeletedScript DeleteThisGameObj = GameObject.FindObjectOfType<BlockCanBeDeletedScript>();
        if (DeleteThisGameObj != null)
        {
            Destroy(DeleteThisGameObj);
        }
    }
}
