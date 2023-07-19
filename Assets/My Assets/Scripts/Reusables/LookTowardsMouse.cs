using UnityEngine;

public class LookTowardsMouse : MonoBehaviour
{
    [SerializeField] GameObject crosshair;
    Camera cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        crosshair.transform.position = mousePos;
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = dir;
    }
}
