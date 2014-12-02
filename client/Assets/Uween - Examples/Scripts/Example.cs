using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
    GameObject image;

    void Awake()
    {
        image = transform.Find("Image").gameObject;
    }

    void Start()
    {
        animate();
    }

    void animate()
    {
        // Move X - One Shot
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f));

        // Move X - Repeat (Complete callback)
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).Then(animate);

        // Move X - Repeat - Ease In Out Sine
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).EaseInOutSine().Then(animate);

        // Move X - Repeat - Ease In Out Sine - With Delay
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).EaseInOutSine().Delay(0.5f).Then(animate);

        // Move X - Repeat - Ease In Out Sine - With Delay - With First Position
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).EaseInOutSine().Delay(0.5f).From(0f).Then(animate);
        
        // Move Y - Repeat - Ease In Out Sine - With Delay
        TweenY.Add(image, 1f, Random.Range(Screen.height / -2f, Screen.height / 2f)).EaseInOutSine().Delay(0.5f).Then(animate);
    }
}
