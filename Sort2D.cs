using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Sort2D : MonoBehaviour
{
    private Scene currentScene;

    void Start() => currentScene = SceneManager.GetActiveScene();

    void FixedUpdate()
    {
        Transform[] rootGameObjects = currentScene.GetRootGameObjects()
            .Select(gObject => gObject.transform).ToArray();

        Array.Sort(rootGameObjects, (Transform a, Transform b) =>
        b.position.z.CompareTo(a.position.z));

        for (int i = 0; i < rootGameObjects.Length; i++)
            SetSortingOrderDeep(rootGameObjects[i], i);
    }

    private void SetSortingOrderDeep(Transform transform, int sortingOrder)
    {
        if (transform.TryGetComponent(out SortingGroup group)) group.sortingOrder = sortingOrder;
        else
        {
            if (transform.TryGetComponent(out SpriteRenderer sr))
                sr.sortingOrder = sortingOrder;
            if (transform.TryGetComponent(out ParticleSystemRenderer psr))
                psr.sortingOrder = sortingOrder;
            foreach (Transform child in transform)
                SetSortingOrderDeep(child, sortingOrder);
        }
    }
}
