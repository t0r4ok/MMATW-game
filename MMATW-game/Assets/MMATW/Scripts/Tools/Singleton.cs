using UnityEngine;

namespace MMATW.Scripts.Tools
{
    public class Singleton<S> : MonoBehaviour where S : Component
    {
        private static S _instance;

        public static S Instance
        {
            get
            {
                if (_instance == null)
                {
                    S[] array = Object.FindObjectsOfType(typeof(S)) as S[];
                    if (array.Length != 0)
                    {
                        _instance = array[0];
                    }

                    if (array.Length > 1)
                    {
                        Debug.LogError($"There is more than one {typeof(S).Name} in the scene.");
                    }

                    if (_instance == null)
                    {
                        _instance = new GameObject
                        {
                            name = $"_{typeof(S).Name}"
                        }.AddComponent<S>();
                    }
                }

                return _instance;
            }
        }
    }
}