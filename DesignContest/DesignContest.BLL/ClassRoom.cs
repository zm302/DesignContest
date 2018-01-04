using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignContest.DAL;
using DesignContest.Entity.Models;

namespace DesignContest.BLL
{
    public class ClassRoom
    {
        private DAL.ClassRoom dalClassroom = new DAL.ClassRoom();

        public bool existClassroom(string F_ClassRoomID)
        {
            T_ClassRoom classroom = new T_ClassRoom();
            classroom.F_ClassRoomID = F_ClassRoomID;
            classroom = dalClassroom.Select(classroom);
            if (classroom == null)
            {
                return false;
            }
            else
            {
                if (!classroom.F_ClassRoomID.Equals(null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        public int getClassRoomCount()
        {
            int count = 0;
            List<T_ClassRoom> retClassroom = new List<T_ClassRoom>();
            retClassroom = dalClassroom.SelectAll().ToList();
            count = retClassroom.Count;
            return count;
        }
        
        public string[] getClassroomInfo(string F_ClassRoomID)
        {
            string[] info = new string[10];
            T_ClassRoom classroom = new T_ClassRoom();
            classroom.F_ClassRoomID = F_ClassRoomID;
            classroom = dalClassroom.Select(classroom);
            info[0] = classroom.F_ClassRoomName;
            info[1] = new BLL.Dictionary().getDictionaryValue(classroom.F_ClassTypeCode);
            info[2] = classroom.F_ClassFunction;
            info[3] = classroom.F_ClassRoomLocation;
            info[4] = classroom.F_ClassDescription;
            info[5] = classroom.F_ClassRoomRemark;
            info[6] = classroom.F_Remark;
            info[7] = classroom.F_LastModifier;
            info[8] = classroom.F_LastModifyDate.ToString();
            info[9] = F_ClassRoomID;
            return info;
        }
        public List<T_ClassRoom> getPartClassRoomInfo(string paraName, string parameter)
        {
            List<T_ClassRoom> classroom = new List<T_ClassRoom>();
            if (paraName.Equals("F_ClassRoomName"))
            {
                classroom = dalClassroom.SelectPart(new T_ClassRoom { F_ClassRoomName = parameter }).ToList();
            }
            return classroom;
        }
        public List<T_ClassRoom> getAllClassRoomInfo()
        {
            List<T_ClassRoom> classroom = new List<T_ClassRoom>();
            classroom = dalClassroom.SelectAll().ToList();
            return classroom;
        }
        public List<string> getAllClassroomName()
        {
            List<string> classroomName = new List<string>();
            List<T_ClassRoom> classroom = new List<T_ClassRoom>();
            classroom = dalClassroom.SelectAll().ToList();
            foreach (T_ClassRoom classrooms in classroom)
            {
                classroomName.Add(classrooms.F_ClassRoomName);
            }
            return classroomName;
        }
        public string addClassRoom(string[] info,bool isDelete)
        {
            T_ClassRoom classroom = new T_ClassRoom();
            classroom.F_ClassRoomID = info[0];
            classroom.F_ClassRoomName = info[1];
            classroom.F_ClassTypeCode = new BLL.Dictionary().getDictionaryKEY(info[2]);
            classroom.F_ClassFunction = info[3];
            classroom.F_IsDelete = isDelete;
            classroom.F_ClassRoomLocation = info[4];
            classroom.F_ClassDescription = info[5];
            classroom.F_ClassRoomRemark = info[6];
            classroom.F_Remark = info[7];
            string message = dalClassroom.Insert(classroom);
            return message;
        }
        public string deleteClassroom(string F_ClassRoomID)
        {
            T_ClassRoom classroom = new T_ClassRoom();
            classroom.F_ClassRoomID = F_ClassRoomID;
            classroom = dalClassroom.Select(classroom);
            string message = dalClassroom.Delete(classroom);
            return message;
        }
    }
}
