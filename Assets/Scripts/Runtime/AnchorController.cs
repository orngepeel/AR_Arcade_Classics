using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AnchorController : MonoBehaviour
{
    [SerializeField] GameObject AnchorPrefab;
    [SerializeField] string ReferenceImageName;
    [SerializeField] GameObject[] inactiveElements;
    private ARTrackedImageManager trackedImageManager;

    void Awake() 
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }
    
    void OnEnable() => trackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => trackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            if(newImage.referenceImage.name == ReferenceImageName)
            {
                var anchorObject = Instantiate(AnchorPrefab, newImage.transform.position, newImage.transform.rotation, newImage.transform);

                foreach (var element in inactiveElements)
                {
                    element.SetActive(true);
                    element.transform.position = anchorObject.transform.position;
                    element.transform.rotation = anchorObject.transform.rotation;
                }
            }
        }
    }
}
