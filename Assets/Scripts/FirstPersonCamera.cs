public class FirstPersonCamera : UnityEngine.MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    private float rotY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MouseAiming();
        KeyboardMovement();
    }

 
    private void MouseAiming()
    {
        // Pourquoi nommer cette variable "y" alors qu'elle gère l'axe x ?
        // Parce qu'on parle des axes de rotation 
        // "y" est donc horizontal, et "x" vertical, en quelque sorte
        // Ligne commentée temporairement: float rotY = UnityEngine.Input.GetAxis("Mouse X") * turnSpeed;
        rotY += UnityEngine.Input.GetAxis("Mouse X") * turnSpeed;
        // Pourquoi `+=` plutôt que `=` ?
        // Parce que la variable est mise à jour, incrémentée tout au long
        // de l'exécution du programme
        rotX += UnityEngine.Input.GetAxis("Mouse Y") * turnSpeed;


        rotX = UnityEngine.Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        transform.eulerAngles = new UnityEngine.Vector3(-rotX, rotY, 0);

    }

    private void KeyboardMovement()
    {
        UnityEngine.Vector3 dir = new UnityEngine.Vector3(0, 0, 0);

        dir.x = UnityEngine.Input.GetAxis("Horizontal");
        dir.z = UnityEngine.Input.GetAxis("Vertical");

        transform.Translate(dir * moveSpeed * UnityEngine.Time.deltaTime);
    }
}
