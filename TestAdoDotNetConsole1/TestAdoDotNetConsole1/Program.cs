using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using TestAdoDotNetConsole1.Models;

namespace TestAdoDotNetConsole1
{
    class Program
    {
        //dot net core 2.2
        static void Main(string[] args)
        {
            Console.WriteLine("//dot net core 2.2");

            string ConStr =
                "Data Source=huangyao;Initial Catalog=EEMS;Persist Security Info=False;User ID=sa;Password=cs2019;";
            string CmdStr = string.Empty;

            using (SqlConnection con = new SqlConnection(ConStr))
            {
                con.Open();

                try
                {

                    //-------------------方式1: 直接拼sql---------start--------
                    //先删除TRUNCATE TABLE [cube]
                    using (SqlCommand command = new SqlCommand("TRUNCATE TABLE [cube]", con))
                    {
                        command.ExecuteNonQuery();
                    }


                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start(); //  开

                    /*
                    using (SqlCommand command = new SqlCommand("SELECT top 1 * FROM [dbo].[Cube]", con))
                    {
                        //int k = command.ExecuteNonQuery();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            Console.WriteLine($"执行成功，返回数据: {dr[1].ToString()}");
                        }
                    }
                    */


                    for (int h = 0; h < 10000; h++)
                    {
                        CmdStr += $"INSERT INTO [dbo].[Cube] ([Name],[Description],[PccId],[ClientId]) VALUES ('集装箱{h.ToString()}','集装箱{h.ToString()}', 1, 1);";
                    }

                    using (SqlCommand command = new SqlCommand(CmdStr, con))
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            int k = command.ExecuteNonQuery();
                        }
                    }

                    TimeSpan timespan2 = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
                    double milliseconds2 = timespan2.TotalMilliseconds;  //  总毫秒数
                    Console.WriteLine($"直接用sql写入记录，总毫秒数: {milliseconds2.ToString()}");

                    //-------------------方式1: 直接拼sql---------end--------

                    //-------------------方式2: AdoDotNet---------Start--------
                    using (SqlCommand command = new SqlCommand("TRUNCATE TABLE [cube]", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    Stopwatch stopwatch2 = new Stopwatch();
                    stopwatch2.Start(); //  开
                    DataTable dt = new DataTable();
                    var selectComtText = "select * from [dbo].[Cube]";
                    using (var adapter = new SqlDataAdapter(selectComtText, con))
                    //using (var adapter = DbProviderFactories.GetFactory(con).CreateDataAdapter())
                    {
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey; //会带回自增列的属性，如果不设，数据库的id列是自增，但这里的datatable不是自增，但不影响插入
                        //var selcmd = con.CreateCommand();
                        //selcmd.CommandText = CmdStr;
                        //adapter.SelectCommand = selcmd;
                        //DbProviderFactories.GetFactory(con).CreateDataAdapter();
                        //DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter()
                        //var commandBuilder = DbProviderFactories.GetFactory(con).CreateCommandBuilder();


                        if (adapter.SelectCommand == null)
                            adapter.SelectCommand = con.CreateCommand();
                        adapter.SelectCommand.CommandText = selectComtText;
                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                        adapter.InsertCommand = builder.GetInsertCommand();

                        adapter.Fill(dt);

                        DataRow newRow;
                        for (int h = 0; h < 10000; h++)
                        {
                            newRow = dt.NewRow();
                            newRow["Id"] = h + 100;
                            newRow["Name"] = $"集装箱{h.ToString()}";
                            newRow["Description"] = $"集装箱{h.ToString()}";
                            newRow["PccId"] = "1";
                            newRow["ClientId"] = "1";
                            dt.Rows.Add(newRow);
                        }

                        adapter.Update(dt);
                        //dt.AcceptChanges();

                    }


                    stopwatch2.Stop(); //  停止监视
                    TimeSpan timespan = stopwatch2.Elapsed; //  获取当前实例测量得出的总时间
                    double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数

                    Console.WriteLine($"用datatable写入记录，总毫秒数: {milliseconds.ToString()}");

                    //-------------------方式2: AdoDotNet---------End--------

                    //-------------------方式3: EF Core---------Start--------
                    using (SqlCommand command = new SqlCommand("TRUNCATE TABLE [cube]", con))
                    {
                        command.ExecuteNonQuery();
                    }
                    Stopwatch stopwatch3 = new Stopwatch();
                    stopwatch3.Start(); //  开

                    using (var db = new EEMSContext())
                    {
                        for (int h = 0; h < 10000; h++)
                        {
                            db.Cube.Add(new Cube()
                            {
                                Name = $"集装箱{h.ToString()}",
                                Description = $"集装箱{h.ToString()}",
                                PccId = 1,
                                ClientId = 1
                            });
                        }

                        var count = db.SaveChanges();
                        
                    }

                    stopwatch3.Stop(); //  停止监视
                    TimeSpan timespan3 = stopwatch3.Elapsed; //  获取当前实例测量得出的总时间
                    double milliseconds3 = timespan3.TotalMilliseconds;  //  总毫秒数

                    Console.WriteLine($"用EF Core方式，总毫秒数: {milliseconds3.ToString()}");

                    //-------------------方式3: EF Core---------End--------
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong: {ex.Message}");
                }
            }
            Console.Read();
        }
    }
}
