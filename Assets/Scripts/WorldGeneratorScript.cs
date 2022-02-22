using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneratorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject GrassBlock;
    [SerializeField]
    private GameObject SandBlock;
    [SerializeField]
    private GameObject SwampBlock; //5% = 500
    [SerializeField]
    private GameObject WaterBlock; //5% = 500
    [SerializeField]
    private GameObject BuildingBlock; //10% = 1,000

    private int swampBlockCounter = 500;
    private int waterBlockCounter = 500;
    private int buildingBlockCounter = 1000;

    private readonly int buildingBlockInstantiate = 1;
    private readonly int buildingSpread = 6; //Чем больше значение - тем дальше друг от друга будут сгенерированы дома

    private readonly int mapSizeX = 100;
    private readonly int mapSizeY = 100;

    private float heightDifference = -0.15f; //Чем меньше значение, тем более шершавая карта

    void Start()
    {
        List<GameObject> Blocks = new List<GameObject>
        {
            GrassBlock,
            SandBlock,
            SwampBlock,
            WaterBlock
        };

        for (int i = 0; i < mapSizeX; i++)
        {
            for (int j = 0; j < mapSizeY; j++)
            {
                GameObject NewBlock = Instantiate(Blocks[Random.Range(0,Blocks.ToArray().Length)], new Vector3(i,j,Random.Range(heightDifference,-0.1f)), Quaternion.identity);
                if (NewBlock.tag == SwampBlock.tag)
                {
                    swampBlockCounter -= 1;
                }
                if (NewBlock.tag == WaterBlock.tag)
                {
                    waterBlockCounter -= 1;
                }
                if (waterBlockCounter == 0)
                {
                    Blocks.Remove(WaterBlock);
                }
                if (swampBlockCounter == 0)
                {
                    Blocks.Remove(SwampBlock);
                }

                if(NewBlock.CompareTag("SandBlock") || NewBlock.CompareTag("GrassBlock"))
                {
                    if(buildingBlockCounter>0)
                    {
                        if (buildingBlockInstantiate == Random.Range(0, buildingSpread))
                        {
                            Instantiate(BuildingBlock, new Vector3(i, j, Random.Range(-0.8f, -0.99f)), Quaternion.identity);
                            buildingBlockCounter -= 1;
                        }
                    }
                }
            }
        }
    }
}