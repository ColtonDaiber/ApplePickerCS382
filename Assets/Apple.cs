using UnityEngine;

public class Apple : MonoBehaviour
{
    public ApplePicker applePicker;
    public static float bottomY = -20;
    void Start()
    {
        applePicker = FindAnyObjectByType<ApplePicker>();
    }

    void Update()
    {
        if(this.transform.position.y < bottomY)
        {
            if(!this.name.Contains("Branch")) applePicker.MissedApple();
            Destroy(this.gameObject);
        }
    }
}
