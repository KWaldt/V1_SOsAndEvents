using UnityEngine;

namespace KristinaWaldt
{
    [CreateAssetMenu(fileName = "IntObject", menuName = "Data/Variables/Int")]
    public class IntObject : VariableObject<int>
    {
        [ContextMenu("Add")]
        public void DebugAdd()
        {
            RuntimeValue += 10;
        }

        [ContextMenu("Remove")]
        public void DebugRemove()
        {
            RuntimeValue -= 10;
        }
    }
}