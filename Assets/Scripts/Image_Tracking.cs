using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Image_Tracking : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager _ImageManager;

    private void OnEnable() => _ImageManager.trackedImagesChanged += OnTrackedImagesChanged;

    private void OnDisable() => _ImageManager.trackedImagesChanged -= OnTrackedImagesChanged;


    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach(var item in obj.added)
        {
            Debug.Log(item.referenceImage.name);
        }
    }
}
