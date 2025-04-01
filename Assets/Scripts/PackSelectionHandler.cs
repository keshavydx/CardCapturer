using UnityEngine;
using UnityEngine.UI; // If using UI Buttons

public class PackSelectionHandler : MonoBehaviour
{
    // Assign these PackData assets in the Inspector
    public PackData firePackData;
    public PackData grassPackData;
    public PackData waterPackData;

    // You can link these methods directly to your Button's OnClick() event in the Inspector

    public void OnFirePackSelected()
    {
        if (GameManager.Instance != null && firePackData != null)
        {
            GameManager.Instance.SelectPackAndLoadOpeningScene(firePackData);
        }
        else
        {
            Debug.LogError("GameManager Instance or Fire Pack Data is missing!");
        }
    }

    public void OnGrassPackSelected()
    {
        if (GameManager.Instance != null && grassPackData != null)
        {
            GameManager.Instance.SelectPackAndLoadOpeningScene(grassPackData);
        }
        else
        {
            Debug.LogError("GameManager Instance or Grass Pack Data is missing!");
        }
    }

    public void OnWaterPackSelected()
    {
        if (GameManager.Instance != null && waterPackData != null)
        {
            GameManager.Instance.SelectPackAndLoadOpeningScene(waterPackData);
        }
        else
        {
            Debug.LogError("GameManager Instance or Water Pack Data is missing!");
        }
    }
}