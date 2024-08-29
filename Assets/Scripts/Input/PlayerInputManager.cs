using System.Collections;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private CustomEvent _characterCreatedE;

    private void  OnEnable()
    {
        StartCoroutine(NotifyOfCreation());
    }

    private IEnumerator NotifyOfCreation()
    {
        yield return 0;
        _characterCreatedE.Invoke(gameObject);

    }
}
