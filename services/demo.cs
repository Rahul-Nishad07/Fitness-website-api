


using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class demo
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Demo(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"select * from pc_student.Demotable where id=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
             
              
                
                 new MySqlParameter("@name",rData.addInfo["name"]),
                   new MySqlParameter("address",rData.addInfo["address"]),
                     new MySqlParameter("@mobileno", rData.addInfo["mobileno"])
                   
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Already Checked the Democlass";
                }
                else
                {
                    var sq=@"insert into pc_student.Demotable(name,address,mobileno) values(@name,@address,@mobileno)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
             
                new MySqlParameter("@name", rData.addInfo["name"]) ,
                 new MySqlParameter("@address",rData.addInfo["address"]),
                   new MySqlParameter("@mobileno",rData.addInfo["mobileno"])
                   
                   
                    };
                    var insertResult = ds.executeSQL(sq, insertParams);

                    resData.rData["rMessage"] = "Thanks For Cheching Our Demo classes";
                    
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return resData;
        }
    }
}



