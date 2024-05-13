using UnityEngine;

namespace MMATW.Scripts.Tools
{
    public class Singleton<TS> : MonoBehaviour where TS : Component
    {
        private static TS _instance;

        public static TS Instance
        {
            get
            {
                if (_instance == null)
                {
                    TS[] array = Object.FindObjectsOfType(typeof(TS)) as TS[];
                    if (array.Length != 0)
                    {
                        _instance = array[0];
                    }

                    if (array.Length > 1)
                    {
                        Debug.LogError($"There is more than one {typeof(TS).Name} in the scene.");
                    }

                    if (_instance == null)
                    {
                        _instance = new GameObject
                        {
                            name = $"_{typeof(TS).Name}"
                        }.AddComponent<TS>();
                    }
                }

                return _instance;
            }
        }
    }
}