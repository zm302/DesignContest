using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.BLL
{
    public class Environment
    {
        private DAL.Environment dalEnvironment = new DAL.Environment();
        
        public List<string[]> getValue(string F_ClassRoomID,string DictionaryValue)
        {
            List<string[]> Value = new List<string[]>();
            string dictionaryKey = new BLL.Dictionary().getDictionaryKEY(DictionaryValue);
            T_Environment environment = new T_Environment();
            environment.F_SensorType = dictionaryKey;
            environment.F_ClassRoomID = F_ClassRoomID;
            List<T_Environment> environments = new DAL.Environment().SelectPart(environment).ToList();
            foreach (T_Environment envir in environments)
            {
                string[] str = new string[2];
                str[0] = envir.F_DataValue;
                str[1] = envir.F_DataDate.ToShortTimeString();
                Value.Add(str);
            }
            return Value;
        }
       
    }

    
}
