using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class MenuManager : MonoBehaviour
    {
        #region Singleton
        public static MenuManager Instance
        {
            get
            {
                if (!_instance)
                    throw new MissingComponentException("MenuManager was not attached or " +
                        "enabled on any GameObject!");
                return _instance;
            }
        }

        private static MenuManager _instance;

        private void Awake()
        {
            if (_instance && _instance != this) Destroy(gameObject);
            else _instance = this;
        }
        #endregion
        [SerializeField]
        private Text textElementPrefab;
        [SerializeField]
        private Canvas canvas;
        public Text CreateTextElement() => Instantiate(textElementPrefab, canvas.transform);
    }
}
