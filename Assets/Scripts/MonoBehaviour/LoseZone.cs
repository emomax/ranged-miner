using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoseZone : MonoBehaviour
{
  [SerializeField]
  private UnityEvent OnLoseZoneEnterCallback;

  private void OnTriggerEnter2D(Collider2D other)
  {
    OnLoseZoneEnterCallback.Invoke();
  }
}
