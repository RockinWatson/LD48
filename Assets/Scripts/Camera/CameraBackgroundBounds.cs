using Cinemachine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundBounds : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

    private PolygonCollider2D _collider2D = null;

    public Bounds GetBounds() { return _collider2D.bounds; }

    private static CameraBackgroundBounds _instance = null;
    public static CameraBackgroundBounds Get() { return _instance; }

    private Vector3 _cameraOffset = Vector2.zero;

    private void Awake()
    {
        _instance = this;

        _collider2D = this.GetComponent<PolygonCollider2D>();
    }

    private void FixedUpdate()
    {
        var position = this.transform.position;
        var playerPosition = Player.Get().transform.position;
        this.transform.position = new Vector3(position.x, playerPosition.y, position.z) + _cameraOffset;
    }

    public void SetFinalCamera()
    {
        StartCoroutine(Coroutine_AdjustFinalCamera());
    }

    private IEnumerator Coroutine_AdjustFinalCamera()
    {
        var startingOffset = _cameraOffset;
        var endingOffset = new Vector2(0, 6f);

        var startingSize = virtualCamera.m_Lens.OrthographicSize;
        var endingSize = 10f;

        var totalTime = 10f;
        var timer = 0f;

        while (!Mathf.Approximately(virtualCamera.m_Lens.OrthographicSize, endingSize))
        {
            timer += Time.deltaTime;
            var time = timer / totalTime;

            var newOffset = Vector2.Lerp(startingOffset, endingOffset, time);
            _cameraOffset = newOffset;

            var newSize = Mathf.SmoothStep(startingSize, endingSize, time);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Min(newSize, endingSize);

            yield return null;
        }
        yield return null;
    }
}
