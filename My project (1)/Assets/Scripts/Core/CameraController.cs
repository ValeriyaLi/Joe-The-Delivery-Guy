using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;
    private float currentPosX;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}