using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignContest.Entity.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesignContest.DAL
{
    public class DataManage
    {
        //判断用户是否存在
        public bool IsExistUser(string uName)
        {
            bool isExist = false;
            string str = ConfigurationManager.ConnectionStrings["SmartLaboratory"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("existUserByF_UserName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add("@userName", SqlDbType.NVarChar);
                cmd.Parameters["@userName"].Value = uName;

                cmd.Parameters.Add("@isExist", SqlDbType.Int);
                cmd.Parameters["@isExist"].Direction = ParameterDirection.Output;

                cmd.ExecuteReader();
                int outValue = Convert.ToInt32(cmd.Parameters["@isExist"].Value);
                if (outValue == 1)
                    isExist = true;
                else
                    isExist = false;
            }
            return isExist;
        }

        //判断密码是否正确
        public bool IsEquals(string uName, string password)
        {
            bool isEquals = false;
            string code = null;
            string str = ConfigurationManager.ConnectionStrings["SmartLaboratory"].ConnectionString;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getT_UserInfoByF_UserName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add("@userName", SqlDbType.NVarChar);
                cmd.Parameters["@userName"].Value = uName;

                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    code = dr["F_PassWord"].ToString();
                }
            }
            if (code.Equals(password))
            {
                isEquals = true;
            }
            else
                isEquals = false;

            return isEquals;
        }
        //判断实验室编号是否存在
        public bool IsExistClassroom(string classroomID)
        {
            bool isExist = false;
            string str = ConfigurationManager.ConnectionStrings["SmartLaboratory"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("isExistClassroomByF_ClassRoomID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add("@classRoomID", SqlDbType.NVarChar);
                cmd.Parameters["@classRoomID"].Value = classroomID;

                cmd.Parameters.Add("@isExist", SqlDbType.Int);
                cmd.Parameters["@isExist"].Direction = ParameterDirection.Output;

                cmd.ExecuteReader();
                int outValue = Convert.ToInt32(cmd.Parameters["@isExist"].Value);
                if (outValue == 1)
                    isExist = true;
                else
                    isExist = false;
            }
            return isExist;
        }
        //根据实验室编号，获得该实验室信息
        public T_ClassRoom getClassroomInfoByF_ClassRoomID(string classroomID)
        {
            T_ClassRoom classroom = new T_ClassRoom();
            string str = ConfigurationManager.ConnectionStrings["SmartLaboratory"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getClassroomInfoByF_ClassRoomID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                cmd.Parameters.Add("@classRoomID", SqlDbType.NVarChar);
                cmd.Parameters["@classRoomID"].Value = classroomID;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    classroom.F_ClassRoomID = dr[0].ToString();
                    classroom.F_ClassRoomName = dr[1].ToString();
                    classroom.F_ClassTypeCode = dr[2].ToString();
                    classroom.F_ClassFunction = dr[3].ToString();
                    classroom.F_IsDelete = Convert.ToBoolean(dr[4]);
                    classroom.F_ClassRoomLocation = dr[5].ToString();
                    classroom.F_ClassDescription = dr[6].ToString();
                    classroom.F_ClassRoomRemark = dr[7].ToString();
                    classroom.F_Remark = dr[8].ToString();
                    classroom.F_LastModifier = dr[14].ToString();
                    classroom.F_LastModifyDate = Convert.ToDateTime(dr[15]);
                }
            }
            return classroom;
        }
        //添加实验室
        public int addClassroom(T_ClassRoom classroom)
        {
            int n = 0;
            string str = ConfigurationManager.ConnectionStrings["SmartLaboratory"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("addClassRoom", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters = new SqlParameter[]
                                { new SqlParameter("@classroomID",classroom.F_ClassRoomID),
                                new SqlParameter("@classroomName",classroom.F_ClassRoomName),
                                new SqlParameter("@classTypeCode",classroom.F_ClassTypeCode),
                                new SqlParameter("@classFunction",classroom.F_ClassFunction),
                                new SqlParameter("@isDelete",classroom.F_IsDelete),
                                new SqlParameter("@classRoomLocation",classroom.F_ClassRoomLocation),
                                new SqlParameter("@classDescription",classroom.F_ClassDescription),
                                new SqlParameter("@classRoomRemark",classroom.F_ClassRoomRemark),
                                new SqlParameter("@remark",classroom.F_Remark)
                                };
                cmd.Parameters.AddRange(parameters);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }
        //删除实验室
        public int delClassroom(string classroomID)
        {
            int n = 0;
            string str = ConfigurationManager.ConnectionStrings["SmartLaboratory"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delClassroomByF_ClassRoomID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@classRoomID", classroomID);
                cmd.Parameters.Add(parameter);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }
        //获取所有实验室信息
        public List<T_ClassRoom> getClassroom()
        {
            List<T_ClassRoom> classroom = new List<T_ClassRoom>();
            DataTable dt = new DataTable();
            string str = ConfigurationManager.ConnectionStrings["SmartLaboratory"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from T_ClassRoom", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    classroom.Add(new T_ClassRoom
                    {
                        F_ClassRoomID = dr[0].ToString(),
                        F_ClassRoomName = dr[1].ToString(),
                        F_ClassTypeCode = dr[2].ToString(),
                        F_ClassFunction = dr[3].ToString(),
                        F_IsDelete = Convert.ToBoolean(dr[4]),
                        F_ClassRoomLocation = dr[5].ToString(),
                        F_ClassDescription = dr[6].ToString(),
                        F_ClassRoomRemark = dr[7].ToString(),
                        F_Remark = dr[8].ToString(),
                        F_LastModifier = dr[14].ToString(),
                        F_LastModifyDate = Convert.ToDateTime(dr[15])
                    });
                }
                return classroom;
            }
        }

    }
}
