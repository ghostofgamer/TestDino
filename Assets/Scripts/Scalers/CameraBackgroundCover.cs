using UnityEngine;

namespace Scalers
{
    public class CameraBackgroundCover : MonoBehaviour
    {
        [SerializeField] private float overscan = 1.03f;

        private SpriteRenderer _sprite;
        private Camera _camera;
        private float _factor = 2f;
        private float _worldScreenHeight;
        private float _worldScreenWidth;
        private float _scale;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _camera = Camera.main;
            Resize();
        }

        private void LateUpdate()
        {
            Resize();
        }

        private void Resize()
        {
            _worldScreenHeight = _camera.orthographicSize * _factor;
            _worldScreenWidth = _worldScreenHeight * _camera.aspect;
            Vector2 spriteSize = _sprite.sprite.bounds.size;
            _scale = Mathf.Max(_worldScreenWidth / spriteSize.x, _worldScreenHeight / spriteSize.y);
            _scale *= overscan;
            transform.localScale = new Vector3(_scale, _scale, 1f);
        }
    }
}