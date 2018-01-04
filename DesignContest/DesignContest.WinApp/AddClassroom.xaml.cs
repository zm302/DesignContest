using DesignContest.Common.SystemVar;
using DesignContest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesignContest.WinApp
{
    /// <summary>
    /// AddClassroom.xaml 的交互逻辑
    /// </summary>
    public partial class AddClassroom : Window
    {
        public delegate void ReloadData();
        public ReloadData reloadData;
        public AddClassroom()
        {
            InitializeComponent();
            List<string> type = getClassroomType();
            for (int i = 0; i < type.Count; i++)
            {
                cmBoxClassroomType.Items.Add(type[i]);
            }
            cmBoxClassroomType.SelectedIndex = 0;
        }
        public List<string> getClassroomType()
        {
            List<string> classroomType = new List<string>();
            classroomType = new BLL.Dictionary().getAllDictionaryValue("实验室类型");
            return classroomType;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtClassroomName.Text.Trim() == "")
            {
                new FailureWindows("请输入实验室名称！").ShowDialog();
                return;
            }
            string[] info = new string[8];
            bool isDelete = false;
            info[0] = Guid.NewGuid().ToString();
            info[1] = txtClassroomName.Text.Trim();
            info[2] = cmBoxClassroomType.Text;
            info[3] = txtClassFunction.Text;
            if (radioBtnYes.IsChecked==true)
            {
                isDelete = true;
            }
            else
            {
                isDelete = false;
            }
            info[4] = cmBoxBuilding.Text + txtClassroomLocation.Text;
            info[5] = txtClassDescription.Text;
            info[6] = txtClassroomRemark.Text;
            info[7] = txtRemark.Text;
            string message = new BLL.ClassRoom().addClassRoom(info, isDelete);
            if (message.Equals(SystemVar.Failure))
            {
                new FailureWindows("添加失败！").ShowDialog();
                return;
            }
            MessageBox.Show("添加成功！");
            btnCancel_Click(sender,e);
            reloadData();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtClassroomName.Text = txtClassroomLocation.Text = txtClassDescription.Text
                = txtClassFunction.Text = txtClassroomRemark.Text = txtRemark.Text = "";
            cmBoxBuilding.SelectedIndex = cmBoxClassroomType.SelectedIndex = 0;
            radioBtnYes.IsChecked = true;

        }
    }
}
