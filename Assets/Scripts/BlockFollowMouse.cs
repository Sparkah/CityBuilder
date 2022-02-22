using UnityEngine;

public class BlockFollowMouse : MonoBehaviour
{
    private CanBuildCheckScript[] Blocks;
    private int blocksCanBeBuilt;
    private readonly float reduceHeightAfterBuilt = -0.03f; //Немного опускаем блок вниз, чтобы новые блоки отображались поверх при наведении
    private BuildingInfoManager buildingInfoManager;

    private void Start()
    {
        Blocks = GetComponentsInChildren<CanBuildCheckScript>();
        buildingInfoManager = GameObject.FindObjectOfType<BuildingInfoManager>();
        buildingInfoManager.enabled = false;
    }

    private void Update()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9));

        foreach(var Block in Blocks)
        {
            if (Block.canBuild==true)
            {
                blocksCanBeBuilt += 1;
                if (blocksCanBeBuilt > Blocks.Length)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        buildingInfoManager.enabled = true;
                        Destroy(GetComponent<BlockFollowMouse>());
                        gameObject.transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), transform.position.z-reduceHeightAfterBuilt);
                    }
                }
            }
            if(Block.canBuild==false)
            {
                blocksCanBeBuilt = 0;
            }
        }
    }
}