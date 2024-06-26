using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity
{
    [Header("-- Player Stats --")]
    [Space(5)]
    [SerializeField] private float moveSpeed = 5f;

    // references
    private PlayerController controller;
    private GunController gunController;
    private Camera viewCamera;

    protected override void Start()
    {
        base.Start();
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }

    private void Update()
    {
        // movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            controller.LookAt(point);
        }

        // weapon input
        if (Input.GetMouseButton(0))
        {
            // change to event for SOLID principles
            gunController.Shoot();
        }
    }
}
