using UnityEngine;

public class dragobject : MonoBehaviour
{
    private Vector3 offset;

    void OnMouseDown()
    {
        // Calculate the offset between the object's position and the mouse position
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        // Calculate the new position of the object based on the mouse position and the offset
        Vector3 newPosition = GetMouseWorldPos() + offset;

        // Update the position of the object and its children
        gameObject.transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPos()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPos = Input.mousePosition;

        // Calculate the distance from the camera to the object's parent
        float camDistance = Vector3.Distance(Camera.main.transform.position, transform.parent.position);

        // Convert the mouse position from screen space to world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, camDistance));

        return mouseWorldPos;
    }
}
