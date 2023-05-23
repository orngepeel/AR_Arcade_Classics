using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameActivator : MonoBehaviour
{
    [SerializeField] GameObject GameContainer;
    [SerializeField] ARTrackedImageManager trackedImageManager;
    [SerializeField] ARSession arSession;

    void OnEnable()
    {
        arSession.Reset();
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
            GameContainer.SetActive(true);
            GameContainer.transform.SetParent(newImage.transform);
        }
    }
}
