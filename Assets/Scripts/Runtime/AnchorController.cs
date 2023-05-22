using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AnchorController : MonoBehaviour
{
    [SerializeField] GameObject AnchorPrefab;
    [SerializeField] ARTrackedImageManager trackedImageManager;
    
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

                Instantiate(AnchorPrefab, newImage.transform);

            }
        }
    }
}
