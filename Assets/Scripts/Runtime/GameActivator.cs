using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameActivator : MonoBehaviour
{
    [SerializeField] GameObject AnchorPrefab;
    [SerializeField] ARTrackedImageManager trackedImageManager;
    [SerializeField] GameObject inactiveObj;
    [SerializeField] GameObject inactiveUI;
    [SerializeField] GameObject inactiveStart;

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnChanged;
    } 
        

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            if(newImage.referenceImage.name == "qrcode")
            {
                // transform.SetParent(newImage.transform);

                inactiveObj.SetActive(true);
                inactiveObj.transform.SetParent(newImage.transform);

                inactiveUI.SetActive(true);
                inactiveStart.SetActive(true);

            }
        }
    }

    public void DeactivateGameStartPrefab()
    {
        inactiveStart.SetActive(false);
    }
}
