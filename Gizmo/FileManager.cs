using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gizmo
{
    /// <summary>
    /// 负责保存和读写场景
    /// </summary>
    class FileManager
    {
        private BinaryFormatter transfer = new BinaryFormatter();
        //string path = System.Environment.CurrentDirectory + "\\scene.bin";
        private static string path = String.Empty;
        public BinaryFormatter Transfer
        {
            get
            {
                return transfer;
            }

            set
            {
                transfer = value;
            }
        }

        public bool LoadScene(ref Scene scene)
        {
            path = returnChosenPath();
            if(path == String.Empty)
            {
                return false;
            }
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                //获取文件大小
                long size = fs.Length;
                byte[] bytes = new byte[size];
                //将文件读到byte数组中
                fs.Read(bytes, 0, bytes.Length);
                scene = (Scene)DeserializeObject(bytes);
                fs.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool SaveScene(Scene scene)
        {
            path = returnNewFilePath();
            if (path == String.Empty)
                return false;
            try
            {
                byte[] bytes = SerializeObject(scene);
                FileStream fs = new FileStream(path, FileMode.Create);
                //将byte数组写入文件中
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        /// <summary>
        /// 把对象序列化为字节数组
        /// </summary>
        public static byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }

        /// <summary>
        /// 把字节数组反序列化成对象
        /// </summary>
        public static object DeserializeObject(byte[] bytes)
        {
            object obj = null;
            if (bytes == null)
                return obj;
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms);
            ms.Close();
            return obj;
        }
        /// <summary>
        /// 返回选择的文件完整路径
        /// </summary>
        /// <returns></returns>
        public string returnChosenPath()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            string chosenPath = String.Empty;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                chosenPath = fileDialog.FileName;
                //MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return chosenPath;
        }
        /// <summary>
        /// 保存文件的文件完整路径
        /// </summary>
        public string returnNewFilePath()
        {
            //string localFilePath, fileNameExt, newFileName, FilePath;  
            string localFilePath = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //设置文件类型  
            saveFileDialog1.Filter = " bin files(*.bin)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            saveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + "scene.bin";

            //设置默认文件类型显示顺序  
            saveFileDialog1.FilterIndex = 2;

            //保存对话框是否记忆上次打开的目录  
            saveFileDialog1.RestoreDirectory = true;

            //点了保存按钮
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径  
                localFilePath = saveFileDialog1.FileName.ToString();
            }
            return localFilePath;
        }
    }
}