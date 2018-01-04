using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignContest.BLL
{
    public class Dictionary
    {
        private DAL.Dictionary dalDictionary = new DAL.Dictionary();
        public string getDictionaryValue(string F_KEY)
        {
            string dictionaryValue;
            T_Dictionary dictionary = new T_Dictionary();
            dictionary.F_KEY = F_KEY;
            dictionary = dalDictionary.Select(dictionary);
            dictionaryValue = dictionary.F_VALUE;
            return dictionaryValue;
        }
        public List<string> getAllDictionaryValue(string type)
        {
            List<T_Dictionary> dictionarys = new List<T_Dictionary>();
            dictionarys =  dalDictionary.SelectAll().ToList();
            List<string> classroomType = new List<string>();

            foreach (T_Dictionary dictionary in dictionarys)
            {
                if (dictionary.F_Type.Equals(type))
                {
                    classroomType.Add(dictionary.F_VALUE);
                }
            }
            return classroomType;
        }
        public string getDictionaryKEY(string F_VALUE)
        {
            string dictionaryKey;
            T_Dictionary dictionary = new T_Dictionary();
            dictionary.F_VALUE = F_VALUE;
            dictionary = dalDictionary.Select(dictionary);
            dictionaryKey = dictionary.F_KEY;
            return dictionaryKey;
        }
    }
}
