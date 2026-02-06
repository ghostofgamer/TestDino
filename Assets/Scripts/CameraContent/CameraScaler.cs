
using UnityEngine;

namespace CameraContent
{
    public class CameraScaler : MonoBehaviour
    {
        [SerializeField] private float _targetOrthographicSize = 5f; 
        [SerializeField] private float _targetAspectRatio = 16f / 9f; 

        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            float currentAspectRatio = (float)Screen.width / Screen.height;
            float aspectRatioScale = currentAspectRatio / _targetAspectRatio;
            
            if (aspectRatioScale < 1f)
                _camera.orthographicSize = _targetOrthographicSize / aspectRatioScale;
            else
                _camera.orthographicSize = _targetOrthographicSize;
        }
    }
}
