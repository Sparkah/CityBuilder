using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas BlockInfo;

    [SerializeField]
    private Button InfoButton;

    public TextMeshProUGUI BlockNumberText;

    [SerializeField]
    private Image BlockNumberImage;

    [SerializeField]
    private Button DeleteBlockButton;

    [SerializeField]
    private Button CloseBlockInfoButton;

    private BuildingInfoManager buildingInfoManager;

    Vector3 fixDistanceInfoButton = new Vector3(-1, 0, -1.5f);
    Vector3 fixDistanceDeleteButton = new Vector3(1, 0, -1.5f);

    private void Start()
    {
        buildingInfoManager = FindObjectOfType<BuildingInfoManager>();
    }

    public void DisplayBuildingInfo()
    {
        buildingInfoManager.gameObject.SetActive(false);
        BlockInfo.gameObject.SetActive(true);
        CloseBlockInfoButton.gameObject.SetActive(true);
        DeleteBlockButton.gameObject.SetActive(true);
        InfoButton.gameObject.SetActive(true);
    }

    public void HideBuildingInfo()
    {
        buildingInfoManager.gameObject.SetActive(true);
        InfoButton.gameObject.SetActive(true);
        BlockInfo.gameObject.SetActive(false);
        CloseBlockInfoButton.gameObject.SetActive(false);
    }

    public void KeepUIAtBuildingPosition(Vector3 buildingPos)
    {
        InfoButton.transform.position = new Vector3(buildingPos.x, buildingPos.y, 0) + fixDistanceInfoButton;
        BlockNumberImage.transform.position = new Vector3(buildingPos.x, buildingPos.y, 0) + fixDistanceInfoButton;
        DeleteBlockButton.transform.position = new Vector3(buildingPos.x, buildingPos.y, 0) + fixDistanceDeleteButton;
    }

    public void DeleteBuildingBlock()
    {
        buildingInfoManager.DeleteBlock();
    }
}