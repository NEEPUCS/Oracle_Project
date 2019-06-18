using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;//
using System.Configuration;
using System.IO;//

namespace xscj
{
    public partial class Form1 : Form
    {
        /**获取Oracle 12c数据库连接字符串（位于项目App.config文件中）*/
        protected string connStr = ConfigurationManager.ConnectionStrings["xscj.Properties.Settings.ConnectionString"].ConnectionString;
        protected string filename = "";  //照片文件名
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“dSKcm.KC”中。您可以根据需要移动或删除它。
         // this.kCTableAdapter.Fill(this.dSKcm.KC);

        }

        private void btnQue_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(connStr);	        //创建Oracle连接
            string orclStrSelect = "select XM, XB, TO_CHAR(CSSJ, 'YYYY-MM-DD') AS CSSJ, KCS, ZP from XS where XM ='" + tBxXm.Text.Trim() + "'";
                                                                            //设置查询SQL语句
            string orclStrView = "select KCM AS 课程名, CJ AS 成绩 from XMCJ_VIEW";
                                                                            //查询视图的SQL语句
            try
            {
                /**查询学生信息*/
                conn.Open();							                    //打开数据库连接
                OracleCommand myCommand = new OracleCommand(orclStrSelect, conn);
                //创建 DataReader 对象以读取学生信息
                OracleDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())							                //读取数据不为空
                {
                    /*查询到的学生信息赋值给界面上的各表单控件显示*/
                    tBxXm.Text = reader["XM"].ToString();			        //姓名
                    string sex = reader["XB"].ToString();                   //性别
                    if (sex == "男")
                        rBtnMale.Checked = true;
                    else
                        rBtnFemale.Checked = true;
                    string birthday = reader["CSSJ"].ToString();            //出生年月
                    dTPCssj.Value = DateTime.ParseExact(birthday, "yyyy-MM-dd", null);
                    tBxKcs.Text = reader["KCS"].ToString();                 //课程数
                    //读取照片
                    if (pBxZp.Image != null)
                        pBxZp.Image.Dispose();
                    byte[] data = (byte[])reader["ZP"];
                    MemoryStream ms = new MemoryStream(data);
                    pBxZp.Image = Image.FromStream(ms);                     //照片
                    ms.Close();
                    lblMsg1.Text = "查找成功！";
                }
                else
                {
                    lblMsg1.Text = "该学生不存在！";
                    tBxXm.Text = "";
                    rBtnMale.Checked = true;
                    dTPCssj.Value = DateTime.Now;
                    pBxZp.Image = null;
                    tBxKcs.Text = "";
                    dGVKcCj.DataSource = null;
                    return;
                }
                /**执行存储过程*/
                OracleCommand proCommand = new OracleCommand();             //创建SQL命令对象
                /*设置SQL命令各参数*/
                proCommand.Connection = conn;                               //所用的数据连接
                proCommand.CommandType = CommandType.StoredProcedure;	    //命令类型为“存储过程”
                proCommand.CommandText = "CJ_PROC";		                    //存储过程名
                OracleParameter OrclXm = proCommand.Parameters.Add("xm", OracleDbType.Char, 8);
                //添加存储过程的参数
                OrclXm.Direction = ParameterDirection.Input;		        //参数类型为“输入参数”
                OrclXm.Value = tBxXm.Text.Trim();
                proCommand.ExecuteNonQuery();				                //执行命令，生成视图
                /**访问视图*/
                OracleDataAdapter mda = new OracleDataAdapter(orclStrView, conn);
                DataSet ds = new DataSet();
                mda.Fill(ds, "XMCJ_VIEW");					                //视图数据先读取到数据集中
                dGVKcCj.DataSource = ds.Tables["XMCJ_VIEW"].DefaultView;    //动态设置数据源
            }
            catch
            {
                lblMsg1.Text = "查找成功！";
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            string orclStr;
            if (filename != "")             	                                //如果选择了照片
            {
                orclStr = "insert into XS values(:Name, :Sex, :Born, 0, NULL, :Photo)";
                //设置SQL语句（带照片插入）
            }
            else
            {                                                	            //如果没选择照片
                orclStr = "insert into XS values(:Name, :Sex, :Born, 0, NULL, NULL)";
                //设置SQL语句（不带照片插入）
            }
            OracleCommand cmd = new OracleCommand(orclStr, conn);           //新建操作数据库的命令对象
            /*为命令添加参数*/
            cmd.Parameters.Add(":Name", OracleDbType.Char, 8).Value = tBxXm.Text.Trim();	        //姓名
            if (rBtnMale.Checked)                                                                   //性别
                cmd.Parameters.Add(":Sex", OracleDbType.Char, 2).Value = rBtnMale.Text.Trim();
            else
                cmd.Parameters.Add(":Sex", OracleDbType.Char, 2).Value = rBtnFemale.Text.Trim();
            cmd.Parameters.Add(":Born", OracleDbType.Date).Value = dTPCssj.Value;		            //出生年月
            if (filename != "")                                             //如果选择了照片则加入参数:Photo
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                MemoryStream ms = new MemoryStream();
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                cmd.Parameters.Add(":Photo", OracleDbType.Blob);	        //这里选择Blob类型
                cmd.Parameters[":Photo"].Value = data;	                    //给:Photo参数赋值
                filename = "";
            }
            try
            {
                conn.Open();                					            //打开数据库连接
                cmd.ExecuteNonQuery();                		                //执行SQL语句
                this.btnQue_Click(null, null);                		        //查询后回显该生信息
                lblMsg1.Text = "添加成功！";
            }
            catch
            {
                lblMsg1.Text = "添加失败，请检查输入信息！";
            }
            finally
            {
                conn.Close();                              	                //关闭数据库连接
            }
        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfDlg = new OpenFileDialog();
            opfDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            opfDlg.Filter = "JPEG图片|*.jpg|GIF图片|*.gif|全部文件|*.*";
            if(opfDlg.ShowDialog(this)==DialogResult.OK)
            {
                filename = opfDlg.FileName;
                pBxZp.Image = Image.FromFile(filename);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            string orclStr = "update XS set";					            //设置修改学生信息的SQL语句
            orclStr += " CSSJ=TO_DATE('" + dTPCssj.Value + "', 'YYYY-MM-DD hh24:mi:ss'),";
                                                                            //更新“出生年月”字段
            if (filename != "")			                                    //如果选择了照片
            {
                orclStr += " ZP =:Photo,";					                //更新“照片”字段
            }
            if (rBtnMale.Checked)                                           //获取“性别”选项值
                orclStr += "XB ='" + rBtnMale.Text.Trim() + "'";
            else
                orclStr += "XB ='" + rBtnFemale.Text.Trim() + "'";
            orclStr += " where XM ='" + tBxXm.Text.Trim() + "'";
            OracleCommand cmd = new OracleCommand(orclStr, conn);	        //新建操作数据库的命令对象
            //读取新照片
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            MemoryStream ms = new MemoryStream();
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, (int)fs.Length);
            cmd.Parameters.Add(":Photo", OracleDbType.Blob);		        //这里选择Blob类型
            cmd.Parameters[":Photo"].Value = data;                          //给:Photo参数赋值
            filename = "";
            try
            {
                conn.Open();								                //打开数据库连接
                cmd.ExecuteNonQuery();			             	            //执行SQL语句
                this.btnQue_Click(null, null);                   	        //查询后回显该生信息
                lblMsg1.Text = "更新成功！";
            }
            catch
            {
                lblMsg1.Text = "更新失败，请检查输入信息！";
            }
            finally
            {
                conn.Close();								                //关闭数据库连接
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            string orclStr = "Delete From XS where XM =:Name";	            //设置删除的SQL语句
            OracleCommand cmd = new OracleCommand(orclStr, conn);	        //新建操作数据库的命令对象
            cmd.Parameters.Add(":Name", OracleDbType.Char, 8).Value = tBxXm.Text.Trim();
                                                                            //添加参数
            try
            {
                conn.Open();								                //打开数据库连接
                int a = cmd.ExecuteNonQuery();				                //执行SQL语句
                if (a == 1)								                    //返回值为1表示操作成功
                {
                    this.btnQue_Click(null, null);
                    lblMsg1.Text = "删除成功！";
                }
                else
                {
                    lblMsg1.Text = "该学生不存在！";
                }
            }
            catch
            {
                lblMsg1.Text = "删除失败，请检查操作权限！";
            }
            finally
            {
                conn.Close();                                	            //关闭数据库连接
            }

        }

        private void btnQueCj_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(connStr);		    //创建Oracle连接
            string orclStr = "select XM AS 姓名, CJ AS 成绩 from CJ where KCM ='" + cBxKcm.SelectedValue + "'";
                                                                            //设置查询SQL语句
            try
            {
                conn.Open();								                //打开数据库连接
                OracleDataAdapter mda = new OracleDataAdapter(orclStr, conn);
                DataSet ds = new DataSet();
                mda.Fill(ds, "KCCJ");						                //查询的数据读取到数据集中
                dGVXmCj.DataSource = ds.Tables["KCCJ"].DefaultView;
            }
            catch
            {
                lblMsg2.Text = "查找数据出错！";
            }
            finally
            {
                conn.Close();								                //关闭数据连接
            }
        }

        private void btnInsCj_Click(object sender, EventArgs e)
        {
            //先查询是否已有该成绩记录，避免重复录入
            if (SearchScore(cBxKcm.SelectedValue.ToString(), tBxName.Text.Trim()))
            {
                lblMsg2.Text = "该记录已经存在！";
                return;
            }
            else
            {
                OracleConnection conn = new OracleConnection(connStr);   	//创建Oracle连接
                String orclStr = "insert into CJ(XM, KCM, CJ) values('" + tBxName.Text.Trim() + "','" + cBxKcm.SelectedValue + "'," + tBxCj.Text.Trim() + ")";
                                                                            //设置插入SQL语句
                try
                {
                    conn.Open();								            //打开数据库连接
                    OracleCommand cmd = new OracleCommand(orclStr, conn);   //新建操作数据库命令对象
                    if (cmd.ExecuteNonQuery() > 0)	                        //命令执行返回>0表示操作成功
                    {
                        lblMsg2.Text = "添加成功！";
                        tBxName.Text = "";
                        tBxCj.Text = "";
                        this.btnQueCj_Click(null, null);            		//查询后回显成绩表信息
                    }
                    else
                        lblMsg2.Text = "添加失败，请确保有此学生！";
                }
                catch
                {
                    lblMsg2.Text = "操作数据出错！";
                }
                finally
                {
                    conn.Close();								            //关闭连接
                }
            }
        }

        private void btnDelCj_Click(object sender, EventArgs e)
        {
            //先查询是否有该成绩记录，有才能删
            if (SearchScore(cBxKcm.SelectedValue.ToString(), tBxName.Text.Trim()))
            {
                OracleConnection conn = new OracleConnection(connStr);   	//创建Oracle连接
                String orclStr = "delete from CJ where XM ='" + tBxName.Text + "' and KCM ='" + cBxKcm.SelectedValue + "'";
                                                                            //设置删除SQL语句
                try
                {
                    conn.Open();								            //打开数据库连接
                    OracleCommand cmd = new OracleCommand(orclStr, conn);
                    if (cmd.ExecuteNonQuery() > 0)			                //命令执行返回>0表示操作成功
                    {
                        lblMsg2.Text = "删除成功！";
                        tBxName.Text = "";
                        this.btnQueCj_Click(null, null);                 	//查询后回显成绩表信息
                    }
                    else
                        lblMsg2.Text = "删除失败，请检查操作权限！";
                }
                catch
                {
                    lblMsg2.Text = "操作数据出错！";
                }
                finally
                {
                    conn.Close();								            //关闭数据库连接
                }
            }
            else
                lblMsg2.Text = "该记录不存在！";
        }
        protected bool SearchScore(string kc, string xm)
        {
            bool exist = false;									            //记录存在标识
            OracleConnection conn = new OracleConnection(connStr);        	//创建Oracle连接
            string orclStr = "select * from CJ where KCM ='" + kc + "' and XM ='" + xm + "'";
            //查询SQL语句
            conn.Open();									   	            //打开数据库连接
            OracleCommand cmd = new OracleCommand(orclStr, conn);		    //新建操作数据库命令对象
            OracleDataReader reader = cmd.ExecuteReader();				    //读取数据
            if (reader.Read())									            //读取不为空表示存在该记录
                exist = true;
            conn.Close();										            //关闭连接
            return exist;										            //返回存在标识
        }
   
        private void dGVXmCj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cBxKcm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tBxXm_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
