using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public void SaveData()
    {
        StreamWriter writer = new StreamWriter("SavedData.txt"); ///Users/timpie/Desktop/Git/CityBuilder/SavedData
        SaveThisObject[] yourObjects = FindObjectsOfType<SaveThisObject>();

        for (int i = 0; i < yourObjects.Length; i++)
        {
            Vector3 objPosition = new Vector3(yourObjects[i].transform.position.x, yourObjects[i].transform.position.y, yourObjects[i].transform.position.z);
            writer.Write(objPosition.ToString());

            string objName = yourObjects[i].gameObject.name;
            writer.Write(objName.ToString());
        }
        writer.Close();
    }

    private bool canLoadLoadedMap;
    public void LoadData()
    {
        canLoadLoadedMap = false;
        StreamReader reader = new StreamReader("SavedData.txt"); ///Users/timpie/Desktop/Git/CityBuilder/SavedData
        string readAllData = reader.ReadToEnd();
        if (readAllData.Contains("(Clone)"))
        {
            string fixedDataFormat = readAllData.Replace("(Clone)", ";");
            StructureLoadData(fixedDataFormat);
        }
    }

    private void StructureLoadData(string fixedDataFormat)
    {
        if (canLoadLoadedMap == false)
        {
            DeleteCurrentMap();
        }

        if (canLoadLoadedMap == true)
        {
            string[] dataPieces = fixedDataFormat.Split(';');
            for (int i = 0; i < dataPieces.Length; i++)
            {
                if(dataPieces[i].Contains("(") && dataPieces[i].Contains(",") && dataPieces[i].Contains(")"))
                {
                    string dataPiecesFormatted1 = dataPieces[i].Replace("(", "");
                    string dataPiecesFormatted2 = dataPiecesFormatted1.Replace(",", "");
                    string dataPiecesFormatted3 = dataPiecesFormatted2.Replace(")", " ");

                    BuildLoadedMap(dataPiecesFormatted3);
                }
            }
        }
    }

    private void DeleteCurrentMap()
    {
        SaveThisObject[] yourObjects = FindObjectsOfType<SaveThisObject>();
        for(int i =0; i<yourObjects.Length;i++)
        {
            Destroy(yourObjects[i].gameObject);
        }
        canLoadLoadedMap = true;
    }

    private void BuildLoadedMap(string dataPieceFormatted3)
    {
        string[] buildingData = dataPieceFormatted3.Split(' ');

        string blockName = buildingData[3];
        GameObject Block = GameObject.FindWithTag(blockName);
        decimal x = Convert.ToDecimal(buildingData[0]);
        decimal y = Convert.ToDecimal(buildingData[1]);
        decimal z = Convert.ToDecimal(buildingData[2]);

        if (Block != null)
        {
            GameObject LoadedBlock = Instantiate(Block, new Vector3((float)x, (float)y, (float)z), Quaternion.identity);
            LoadedBlock.GetComponent<SaveThisObject>().enabled = true;
            if (LoadedBlock.GetComponent<BoxCollider>() != null)
            {
                LoadedBlock.GetComponent<BoxCollider>().enabled = true;
            }
            if (LoadedBlock.GetComponentsInChildren<BoxCollider>() != null)
            {
                foreach(var ChildBlock in LoadedBlock.GetComponentsInChildren<BoxCollider>())
                {
                    ChildBlock.GetComponent<BoxCollider>().enabled = true;
                }
            }
            if (LoadedBlock.GetComponentInChildren<CanBuildCheckScript>() != null)
            {
                CanBuildCheckScript[] CanBuildCheckScriptBlocks = LoadedBlock.GetComponentsInChildren<CanBuildCheckScript>();
                foreach (CanBuildCheckScript block in CanBuildCheckScriptBlocks)
                {
                    block.GetComponent<CanBuildCheckScript>().enabled = true;
                }
            }
        }
    }
}