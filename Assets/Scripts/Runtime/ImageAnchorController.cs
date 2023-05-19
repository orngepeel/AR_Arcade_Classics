using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageAnchorController : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject anchorPrefab;
    [SerializeField] public GameObject[] inactiveElements;
    [SerializeField] public string specificReferenceImageName;

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            // Handle added event
            if (newImage.referenceImage.name == specificReferenceImageName)
            {
                CreateAnchor(newImage);
                break;
            }
        }
    }

    private void CreateAnchor(ARTrackedImage trackedImage)
    {
        GameObject anchorObject = Instantiate(anchorPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
        anchorObject.transform.SetParent(trackedImage.transform);

        foreach (var element in inactiveElements)
        {
            element.SetActive(true);
            element.transform.position = anchorObject.transform.position;
            element.transform.rotation = anchorObject.transform.rotation;
        }
    }
}
