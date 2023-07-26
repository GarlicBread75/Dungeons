using UnityEngine;

public class LookTowardsMouse : MonoBehaviour
{
    [SerializeField] GameObject crosshair;
    [SerializeField] float lerpSpeed;
    [SerializeField] Camera cam;

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        crosshair.transform.position = Vector2.Lerp(crosshair.transform.position, mousePos, lerpSpeed * Time.deltaTime);
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = dir;
    }
}
