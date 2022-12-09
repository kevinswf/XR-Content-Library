using UnityEngine;

public class DebugWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject DebugUI;
    [SerializeField]
    private Transform UIAnchor;
    private bool UIActive;

    // Start is called before the first frame update
    void Start()
    {
        DebugUI.SetActive(false);
        UIActive = false;
    }

    void Update()
    {
        // attach debug window to hand
        if (UIActive)
        {
            DebugUI.transform.position = UIAnchor.position;
            DebugUI.transform.eulerAngles = new Vector3(UIAnchor.eulerAngles.x, UIAnchor.eulerAngles.y, 0);
        }
    }

    public void ToggleDebugWindow()
    {
        UIActive = !UIActive;
        DebugUI.SetActive(UIActive);
    }
}
