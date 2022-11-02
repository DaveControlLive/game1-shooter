using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Shooter.Core
{
    public class CameraFX : MonoBehaviour
    {
        [SerializeField] float shakeDuration = 0.2f;
        [SerializeField] float shakeMagnitude = 0.3f;
        [SerializeField] float maxAberration = 0.3f;

        Vector3 initialPosition;
        PostProcessVolume postProcessVolume;
        ChromaticAberration chromaticAberration;


        void Start()
        {
            initialPosition = transform.position;
            postProcessVolume = GetComponent<PostProcessVolume>();
            postProcessVolume.profile.TryGetSettings(out chromaticAberration);
        }

        public void Play()
        {
            StartCoroutine(Shake());
        }

        IEnumerator Shake()
        {
            float elapsedTime = 0;
            while (elapsedTime < shakeDuration)
            {
                transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            transform.position = initialPosition;
        }

        public void UpdateAberration(float i)
        {
            if (i >= 1)
            {
                chromaticAberration.active = false;
            }
            else if (i > 0)
            {
                chromaticAberration.active = true;
                chromaticAberration.intensity.value = (maxAberration / i);
            }
        }
    }

}