using AtlanticProductDesing.Application.Models;

namespace AtlanticProductDesing.Infrastruture.Utilitys
{
    static public class ListEnum
    {
        public static List<EnumItem> GetEnumList<T>() where T : Enum
        {
            var enumList = new List<EnumItem>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                enumList.Add(new EnumItem
                {
                    Value = (int)value,
                    Name = Enum.GetName(typeof(T), value)
                });
            }
            return enumList;
        }
    }
}
