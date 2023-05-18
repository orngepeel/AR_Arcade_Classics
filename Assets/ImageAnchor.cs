using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageAnchorController : MonoBehaviour
{
    [SerializeField] public ARTrackedImageManager trackedImageManager;
    [SerializeField] public GameObject anchorPrefab;
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
        foreach (var addedImage in eventArgs.added)
        {
            // Check if the added image's name matches the specific reference image name
            if (addedImage.referenceImage.name == specificReferenceImageName)
            {
                // Instantiate a new anchor prefab
                GameObject anchorObject = Instantiate(anchorPrefab, addedImage.transform.position, addedImage.transform.rotation);
                // Attach the anchor object to the tracked image
                anchorObject.transform.SetParent(addedImage.transform);

                // Activate and move the inactive elements to be centered on the anchor
                foreach (var element in inactiveElements)
                {
                    element.SetActive(true);
                    element.transform.position = anchorObject.transform.position;
                    element.transform.rotation = anchorObject.transform.rotation;
                }
            }
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Destroy the anchor object when the tracked image is removed
            Destroy(removedImage.transform.GetChild(0).gameObject);
        }
    }
}
