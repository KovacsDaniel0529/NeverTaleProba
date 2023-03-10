using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector2 margin;
    public Vector2 smoothing;
    public BoxCollider2D bounds;

    private Vector3 _min, _max;

    void Start()
    {
        _min = bounds.bounds.min;
        _max = bounds.bounds.max;
    }

    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;

        if (Mathf.Abs(x - player.position.x) > margin.x)
            x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);

        if (Mathf.Abs(y - player.position.y) > margin.y)
            y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);

        var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
