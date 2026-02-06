
using UnityEngine;

namespace CameraContent
{
    public class CameraScaler : MonoBehaviour
    {
        /*[SerializeField] private float _targetAspect = 16f / 9f; // Соотношение сторон (например, 9:16 для портретного режима)
        [SerializeField] private float _targetOrthographicSize = 5f; // Базовый размер камеры

        private Camera _camera;

        private void Awake() 
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            float currentAspect = (float)Screen.width / Screen.height;
            float orthographicSize = _targetOrthographicSize * (_targetAspect / currentAspect);
            _camera.orthographicSize = orthographicSize;
        }*/
        
        
        [SerializeField] private float _targetOrthographicSize = 5f; // Базовый размер камеры
        [SerializeField] private float _targetAspectRatio = 16f / 9f; // Целевое соотношение сторон (например, 9:16 для портретного режима)

        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            // Вычисляем текущее соотношение сторон экрана
            float currentAspectRatio = (float)Screen.width / Screen.height;

            // Определяем, по какой оси масштабировать (по минимальной стороне)
            float aspectRatioScale = currentAspectRatio / _targetAspectRatio;

            // Если экран "выше", чем целевое соотношение (например, 9:19), масштабируем по высоте
            if (aspectRatioScale < 1f)
            {
                _camera.orthographicSize = _targetOrthographicSize / aspectRatioScale;
            }
            // Если экран "шире", масштабируем по ширине
            else
            {
                _camera.orthographicSize = _targetOrthographicSize;
            }
        }
    }
}
