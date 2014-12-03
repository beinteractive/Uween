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
        Debug.Log("Animate");

        // Move X - One Shot
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f));

        // Move X - Repeat (Complete callback)
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).Then(animate);

        // Move X - Repeat - Ease In Out Sine
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).EaseInOutSine().Then(animate);

        // Move X - Repeat - Ease In Out Sine - With Delay
        TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).EaseInOutSine().Delay(0.5f).Then(animate);

        // Move X - Repeat - Ease In Out Sine - With Delay - With First Position
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).EaseInOutSine().Delay(0.5f).From(0f).Then(animate);
        
        // Move X - Repeat - Ease In Out Sine - From Specified Position to Current Position
        // TweenX.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f)).FromThat().EaseInOutSine().Then(animate);
        
        // Move X - Repeat - Ease In Out Sine - To Position that Current Position + Specified Position
        // TweenX.Add(image, 1f, 60f).By().EaseInOutSine().Then(animate);
        
        // Move X - Repeat - Ease In Out Sine - From Specified Position + Current Position to Current Position
        // TweenX.Add(image, 1f, 60f).FromThatBy().EaseInOutSine().Then(animate);

        // Move Y - Repeat - Ease In Out Sine - With Delay
        // TweenY.Add(image, 1f, Random.Range(Screen.height / -2f, Screen.height / 2f)).EaseInOutSine().Delay(0.5f).Then(animate);
        
        // Move X,Y - Repeat - Ease In Out Sine - With Delay
        // TweenXY.Add(image, 1f, Random.Range(Screen.width / -2f, Screen.width / 2f),  Random.Range(Screen.height / -2f, Screen.height / 2f)).EaseInOutSine().Delay(0.5f).Then(animate);

        // Scale X - Repeat - Ease In Out Sine - With Delay
        // TweenSX.Add(image, 1f, Random.Range(0.5f, 2f)).EaseInOutSine().Delay(0.5f).Then(animate);
        
        // Scale Y - Repeat - Ease In Out Sine - With Delay
        // TweenSY.Add(image, 1f, Random.Range(0.5f, 2f)).EaseInOutSine().Delay(0.5f).Then(animate);
        
        // Scale X,Y - Repeat - Ease In Out Sine - With Delay
        // TweenSXY.Add(image, 1f, Random.Range(0.5f, 2f), Random.Range(0.5f, 2f)).EaseInOutSine().Delay(0.5f).Then(animate);

        // Rotation Z - Repeat - Ease In Out Sine - With Delay
        // TweenRZ.Add(image, 1f, Random.Range(-360f, 360f)).EaseInOutSine().Delay(0.5f).Then(animate);

        // Simply Wait & Callback
        // TweenNull.Add(image, 1f).Then(animate);
    }
}
