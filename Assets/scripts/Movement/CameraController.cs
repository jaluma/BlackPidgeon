using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public Vector3 PositionRelativeToObject = new Vector3(0, 0, -45);

    public float followBias = 1.0f;
    private Vector3 _defaultPositionRelativeToObject;

    // Use this for initialization
    void Start()
    {
        _defaultPositionRelativeToObject = PositionRelativeToObject;
    }

    void FixedUpdate()
    {
        var idealCameraPosition = (ObjectToFollow.transform.rotation * PositionRelativeToObject) + ObjectToFollow.transform.position;
        var cameraVelocity = (idealCameraPosition - transform.position) * followBias;
        transform.position += cameraVelocity;
    }

    public void ChangePositionCamera(Vector3 vector)
    {
        this.PositionRelativeToObject = vector;
    }

    public void ResetPositionCamera()
    {
        this.PositionRelativeToObject = _defaultPositionRelativeToObject;
    }
}
