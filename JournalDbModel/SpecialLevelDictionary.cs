using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalDbModel
{
    public class SpecialLevelDictionary
    {
        static Dictionary<string, int> _dict = new Dictionary<string, int>
        {
            {"Настройка",0},
            {"Проверка", 1},
            {"Сопутствующие", 2 },
            {"Ремонт", 3},
            {"Неисправность", 4}
        };
        
        public static int GetSpecialLevelByName(string name)
        {
            if (!_dict.Keys.Contains(name)) return -1;
            return _dict[name];
        }
    }
}
