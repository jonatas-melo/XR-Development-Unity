using UnityEngine;

namespace _0_Food_Throw.Scripts.Utils
{
    public class ToggleEmissiveMaterial : MonoBehaviour
    {

        [SerializeField] private Material target;

        public void ToggleEmission()
        {
            if (target.IsKeywordEnabled("_EMISSION"))
            {
                target.DisableKeyword("_EMISSION");
            }
            else
            {
                target.EnableKeyword("_EMISSION");
            }
        }
    }
}
