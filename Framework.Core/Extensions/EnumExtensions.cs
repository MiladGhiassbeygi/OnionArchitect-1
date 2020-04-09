using System;

namespace Framework.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {

            Type genericEnumType = @enum.GetType();
            System.Reflection.MemberInfo[] memberInfo =
                        genericEnumType.GetMember(@enum.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {

                var attributes = memberInfo[0].GetCustomAttributes
                      (typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)attributes[0]).Description;
                }
            }

            return @enum.ToString();
        }
    }
}
