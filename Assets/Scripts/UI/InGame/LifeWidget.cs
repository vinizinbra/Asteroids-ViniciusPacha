using UnityEngine;

namespace UI.InGame
{
    public class LifeWidget : MonoBehaviour
    {
        public GameObject[] lifeObjects;

        public void Setup(int lives)
        {
            for (int i = 0; i < lifeObjects.Length; i++)
            {
                lifeObjects[i].SetActive(i<lives);
            }
        }
    };
}