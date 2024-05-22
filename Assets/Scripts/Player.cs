using UnityEngine;

[RequireComponent (typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [Header("-- Player Stats --")]
    [Space(5)]
    [SerializeField] private float moveSpeed = 5f;

    // references
    private PlayerController controller;
    private Camera viewCamera;
    private LayerMask groundLayerMask;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        groundLayerMask = LayerMask.GetMask("Ground");
        viewCamera = Camera.main;
    }

    private void Update()
    {
        // movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        // mouse pos
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayerMask))
        {
            Vector3 point = hit.point;
            Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }
    }
}
