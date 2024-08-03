using arbovirose.Domain.Enums;
using arbovirose.Domain.Exceptions;

namespace arbovirose.Domain.ValueObjects
{
    public class TypeInfo
    {
        public string Value { get; set; } = "";
        public TypeInfo() { }
        public TypeInfo(string typeInfo)
        {
            if (!IsValid(typeInfo)) throw new InvalidTypeInfoException();
            this.Value = typeInfo;
        }
        public bool IsValidTypeInfo(string typeInfo)
        {
            if (typeInfo != TypeInfoHome.Article.ToString() && typeInfo != TypeInfoHome.Video.ToString() && typeInfo != TypeInfoHome.New.ToString()) return false;

            return true;
        }

        public bool IsValid(string typeInfo)
        {
            if(IsValidTypeInfo(typeInfo)) return true;

            return false;
        }
    }
}
