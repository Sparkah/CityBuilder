using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBuildingBlocks : MonoBehaviour
{
    [SerializeField]
    private GameObject BuildingBlock1x1;
    [SerializeField]
    private GameObject BuildingBlock2x2;
    [SerializeField]
    private GameObject BuildingBlock3x3;

    public void InstantiateBuildingBlock1x1()
    {
        GameObject Block = Instantiate(BuildingBlock1x1, new Vector3(0,0,0), Quaternion.identity);
        FollowMousePointer(Block);
    }

    public void InstantiateBuildingBlock2x2()
    {
        GameObject Block = Instantiate(BuildingBlock2x2, new Vector3(0, 0, 0), Quaternion.identity);
        FollowMousePointer(Block);
    }

    public void InstantiateBuildingBlock3x3()
    {
        GameObject Block = Instantiate(BuildingBlock3x3, new Vector3(0, 0, 0), Quaternion.identity);
        FollowMousePointer(Block);
    }

    private void FollowMousePointer(GameObject Block)
    {
        Block.AddComponent<BlockFollowMouse>();
    }
}