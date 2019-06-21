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
            // TODO: 这行代码将数据加载到表“dZYJ.DDXX”中。您可以根据需要移动或删除它。
            this.dDXXTableAdapter.Fill(this.dZYJ.DDXX);
            // TODO: 这行代码将数据加载到表“dZYJ.SCXX”中。您可以根据需要移动或删除它。
            this.sCXXTableAdapter.Fill(this.dZYJ.SCXX);
            // TODO: 这行代码将数据加载到表“dZYJ.YJXX”中。您可以根据需要移动或删除它。
            this.yJXXTableAdapter.Fill(this.dZYJ.YJXX);

        }

        private void btnQue_Click(object sender, EventArgs e)   //查询按键
        {
            OracleConnection conn = new OracleConnection(connStr);	        //创建Oracle连接
            string orclStrSelect = "select YJM, DJ, TO_CHAR(SCRQ, 'YYYY-MM-DD') AS SCRQ,TP from YJXX where YJM ='" + tBxYJM.Text.Trim() + "'";
                                                                            //设置查询SQL语句
            try
            {
                /**查询元件信息*/ 
                conn.Open();							                    //打开数据库连接
                OracleCommand myCommand = new OracleCommand(orclStrSelect, conn);
                //创建 DataReader 对象以读取元件信息
                OracleDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())							                //读取数据不为空
                {
                    /*查询到的学生信息赋值给界面上的各表单控件显示*/
                    tBxYJM.Text = reader["YJM"].ToString();			        //元件名
                    tBDJ.Text= reader["DJ"].ToString();                   //单价
                    string day = reader["SCRQ"].ToString();            //生产日期
                    dTPSCRQ.Value = DateTime.ParseExact(day, "yyyy-MM-dd", null);

                    //读取图片
                    if (pBxTP.Image != null)
                    {
                        pBxTP.Image.Dispose();
                    }
                        byte[] data = (byte[])reader["TP"];
                        MemoryStream ms = new MemoryStream(data);
                        pBxTP.Image = Image.FromStream(ms);                     //照片
                        ms.Close();
                   
                        
                    lblMsg1.Text = "查找成功！";
                }
                else
                {
                    lblMsg1.Text = "该元件不存在！";
                    dTPSCRQ.Value = DateTime.Now;
                    pBxTP.Image = null;
                    return;
                }
       
            }
            catch
            {
                lblMsg1.Text = "查找！";
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnIns_Click(object sender, EventArgs e)      //插入按键
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            string orclStr;
            if (filename != "")             	                                //如果选择了照片
            {
                orclStr = "insert into YJXX values(:YJ,:DJJ, :SC,:Photo)";
                //设置SQL语句（带照片插入）
            }
            else
            {                                                	            //如果没选择照片
                orclStr = "insert into YJXX values(:YJ,:DJJ,:SC,NULL)";
                //设置SQL语句（不带照片插入）
            }
            OracleCommand cmd = new OracleCommand(orclStr, conn);           //新建操作数据库的命令对象
            /*为命令添加参数*/
            cmd.Parameters.Add(":YJ", OracleDbType.Char, 20).Value = tBxYJM.Text.Trim();	        //元件名称
            cmd.Parameters.Add(":DJJ", OracleDbType.Decimal).Value = tBDJ.Text.Trim();            //单价
            cmd.Parameters.Add(":SC", OracleDbType.Date).Value = dTPSCRQ.Value;		            //生产日期
            
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
            this.Form1_Load(null,null);
        }       

        private void btnLoadPic_Click(object sender, EventArgs e)         //图片加载
        {
            OpenFileDialog opfDlg = new OpenFileDialog();
            opfDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            opfDlg.Filter = "JPEG图片|*.jpg|GIF图片|*.gif|全部文件|*.*";
            if(opfDlg.ShowDialog(this)==DialogResult.OK)
            {
                filename = opfDlg.FileName;
                pBxTP.Image = Image.FromFile(filename);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)      //更新按键
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            string orclStr = "update YJXX set";					            //设置修改元件信息的SQL语句
            orclStr += " SCRQ=TO_DATE('" + dTPSCRQ.Value + "', 'YYYY-MM-DD hh24:mi:ss'),";//更新“生产日期”字段
            orclStr += "DJ=" + tBDJ.Text.Trim();


            if (filename != "")			                                    //如果选择了照片
            {
                orclStr += " ,TP =:Photo";					                //更新“图片”字段
            }
            orclStr += " where YJM ='" + tBxYJM.Text.Trim() + "'";
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
                this.btnQue_Click(null, null);                   	        //查询后回显该元件信息
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

        private void btnDel_Click(object sender, EventArgs e)      //删除按键
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            string orclStr = "Delete From YJXX where YJM =:Name";	            //设置删除的SQL语句
            OracleCommand cmd = new OracleCommand(orclStr, conn);	        //新建操作数据库的命令对象
            cmd.Parameters.Add(":Name", OracleDbType.Char, 8).Value = tBxYJM.Text.Trim();
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
                    lblMsg1.Text = "该元件不存在！";
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
            this.Form1_Load(null, null);
        }

        private void btnQueCj_Click(object sender, EventArgs e)    // 查询按键
        {
            OracleConnection conn = new OracleConnection(connStr);		    //创建Oracle连接
            string orclStr = "select YJM , NUM  from SCXX where YJM ='" + cBxYJM.SelectedValue + "'";
                                                                            //设置查询SQL语句
            try
            {
                conn.Open();								                //打开数据库连接
                OracleDataAdapter mda = new OracleDataAdapter(orclStr, conn);
                DataSet ds = new DataSet();
                mda.Fill(ds, "NUM");						                //查询的数据读取到数据集中
                dGVYJSC.DataSource = ds.Tables["NUM"].DefaultView;
            
               
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

        private void btnInsCj_Click(object sender, EventArgs e)    //生产按键
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            //先查询是否已有该元件记录，避免重复录入
            if (SearchScore(cBxYJM.SelectedValue.ToString()))
            {
                //lblMsg2.Text = "该记录已经存在！";

                string orclStr = "update SCXX set ";                             //设置修改元件信息的SQL语句
                orclStr += " NUM = NUM+" + tBxNUM.Text.Trim();
                orclStr += " where YJM ='" + cBxYJM.SelectedValue.ToString() + "'";
                
                try
                {
                    conn.Open(); //打开数据库连接
                    OracleCommand cmd = new OracleCommand(orclStr, conn);                                               
                    cmd.ExecuteNonQuery();                                      //执行SQL语句
                    lblMsg2.Text = cBxYJM.SelectedValue.ToString()+"成功添加"+ tBxNUM.Text.Trim()+"个!";
                }
                catch
                {
                    lblMsg2.Text = "失败，请检查输入信息！";
                }
                finally
                {
                    conn.Close();                                               //关闭数据库连接
                }

            }
            else
            {
                String orclStr = "insert into SCXX(YJM, NUM) values('" + cBxYJM.SelectedValue + "'," + tBxNUM.Text.Trim() + ")";
                                                                            //设置插入SQL语句
                try
                {
                    conn.Open();								            //打开数据库连接
                    OracleCommand cmd = new OracleCommand(orclStr, conn);   //新建操作数据库命令对象
                    if (cmd.ExecuteNonQuery() > 0)	                        //命令执行返回>0表示操作成功
                    {
                        lblMsg2.Text = cBxYJM.SelectedValue+ " 成功添加到生产队列中！";
                        tBxNUM.Text = "";
                        this.btnQueCj_Click(null, null);            		//查询后回显生产表信息
                    }
                    else
                        lblMsg2.Text = "失败，请确保有此元件！";
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

        private void btnDelCj_Click(object sender, EventArgs e)    //删除按键
        {
            //先查询是否有该成绩记录，有才能删
            if (SearchScore(cBxYJM.SelectedValue.ToString()))
            {
               OracleConnection conn = new OracleConnection(connStr);   	//创建Oracle连接
            String orclStr = "delete from SCXX where YJM ='" + cBxYJM.SelectedValue + "'";
                                                                            //设置删除SQL语句
                try
                {
                    conn.Open();								            //打开数据库连接
                    OracleCommand cmd = new OracleCommand(orclStr, conn);
                    if (cmd.ExecuteNonQuery() > 0)			                //命令执行返回>0表示操作成功
                    {
                        lblMsg2.Text = "销毁成功！";
                        this.btnQueCj_Click(null, null);                 	//查询后回显成生产表信息
                    }
                    else
                        lblMsg2.Text = "销毁失败，请检查操作权限！";
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
        protected bool SearchScore(string yj)            //返回查询结果
    {
        bool exist = false;                                             //记录存在标识
        OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
        string orclStr = "select * from SCXX where YJM ='" + yj +  "'";
        //查询SQL语句
        conn.Open();                                                    //打开数据库连接
        OracleCommand cmd = new OracleCommand(orclStr, conn);           //新建操作数据库命令对象
        OracleDataReader reader = cmd.ExecuteReader();                  //读取数据
        if (reader.Read())                                              //读取不为空表示存在该记录
            exist = true;
        conn.Close();                                                   //关闭连接
        return exist;                                                   //返回存在标识
    }

        private void cBYJ_SelectedIndexChanged(object sender, EventArgs e)            //读取单价
        {
            OracleConnection conn = new OracleConnection(connStr);		    //创建Oracle连接
            string orclStr = "select DJ  from YJXX where YJM ='" + cBYJ.Text.Trim() + "'";
            //设置查询SQL语句
            conn.Open();
            OracleCommand myCommand = new OracleCommand(orclStr, conn);
            //创建 DataReader 对象以读取元件信息
            OracleDataReader reader = myCommand.ExecuteReader();
           string s="";
            int a = 0;
            if (reader.Read())
            {
                s= reader["DJ"].ToString ();
            }
            
            txtBDj.Text = s;
            try
            {
                a = Convert.ToInt32(txtBDj.Text);
            }
            catch
            {
                ;
            }
            finally
            {
                conn.Close();
            }
        }     

        private void button1_Click(object sender, EventArgs e)                     //提交购物项
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            string orclStr;
            orclStr = "insert into DDXX values(:YJ,:NUM,:DJJ,:XJ)";
            OracleCommand cmd = new OracleCommand(orclStr, conn);           //新建操作数据库的命令对象
            cmd.Parameters.Add(":YJ", OracleDbType.Char, 20).Value = cBYJ.Text.Trim();	        //元件名称
            cmd.Parameters.Add(":NUM", OracleDbType.Decimal).Value = nuNUM.Text.Trim();            
            cmd.Parameters.Add(":DJJ", OracleDbType.Decimal).Value = txtBDj.Text.Trim();                    
            cmd.Parameters.Add(":XJ", OracleDbType.Decimal).Value = tBJE.Text.Trim();		            

            try
            {
                conn.Open();                					            //打开数据库连接
                cmd.ExecuteNonQuery();                                      //执行SQL语句

                tBMG.Text = "已添加到清单！";
            }
            catch
            {
                tBMG.Text = "添加到清单失败！";
            }
            finally
            {
                conn.Close();                              	                //关闭数据库连接
            }
            this.Form1_Load(null, null);
        }
       
        private void button2_Click(object sender, EventArgs e)                    //提交清单
        {
            OracleConnection conn = new OracleConnection(connStr);          //创建Oracle连接
            
            string orclStr1,orclStr2;
            
            orclStr2 = "select SUM(JE) AS SU from DDXX";
            orclStr1 = "delete from  DDXX where 1=1";
            OracleCommand myCommand = new OracleCommand(orclStr2, conn);
            //创建 DataReader 对象以读取元件信息
            
            
            

            try
            {
                conn.Open();//打开数据库连接
                OracleDataReader reader = myCommand.ExecuteReader();

                OracleCommand cmd = new OracleCommand(orclStr1, conn);
                cmd.ExecuteNonQuery();              		                //执行SQL语句
                if (reader.Read()) 
                MessageBox.Show("提交成功！订单总额为" + reader["SU"].ToString() + "元") ;
            }
            catch
            {
                MessageBox.Show ("提交失败,没有选择物品！");
            }
            finally
            {
                conn.Close();                              	                //关闭数据库连接
            }
            this.Form1_Load(null, null);
        }

        private void nuNUM_ValueChanged(object sender, EventArgs e)              //计算金额
        {
            OracleConnection conn = new OracleConnection(connStr);		    //创建Oracle连接
            string orclStr = "select DJ  from YJXX where YJM ='" + cBYJ.Text.Trim() + "'";
            //设置查询SQL语句
            conn.Open();
            OracleCommand myCommand = new OracleCommand(orclStr, conn);
            //创建 DataReader 对象以读取元件信息
            OracleDataReader reader = myCommand.ExecuteReader();
            string s = "";
            int a = 0;
            if (reader.Read())
            {
                s = reader["DJ"].ToString();
            }
            try
            {
                a = Convert.ToInt32(txtBDj.Text);
            }
            catch
            {
                ;
            }
            finally
            {
                conn.Close();
            }
            tBJE.Text = (nuNUM.Value * a).ToString();
        }
    }
}
