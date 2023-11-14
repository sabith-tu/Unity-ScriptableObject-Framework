using System;

namespace SABI.SOA
{
    [System.Serializable]
    public class BaseReferenceValue
    {
        public AllReferenceTypesEnum mode = AllReferenceTypesEnum.Constant_Value;

        public void SetNotifyOnChange(bool value) => NotifyOnChange = value;

        public bool NotifyOnChange = true;

        public Action ActionOnBaseVariableValueChange;

    }
}