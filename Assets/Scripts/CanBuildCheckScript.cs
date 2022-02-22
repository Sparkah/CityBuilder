using UnityEngine;

public class CanBuildCheckScript : MonoBehaviour
{
    public bool canBuild;
    private BlockFollowMouse blockFollowMouse;
    private BoxCollider[] BuildingBlocks;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.grey;
        blockFollowMouse = GetComponentInParent<BlockFollowMouse>();
        BuildingBlocks = GetComponentsInChildren<BoxCollider>();
        foreach(var Block in BuildingBlocks)
        {
            Block.gameObject.AddComponent<Built>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("SandBlock") || other.CompareTag("GrassBlock"))
        {
            canBuild = true;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            canBuild = false;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        canBuild = false;
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    private void Update()
    {
        if(blockFollowMouse==null)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.grey;
            foreach (var Block in BuildingBlocks)
            {
                Destroy(Block.gameObject.GetComponent<Built>());
            }
        }
    }
}