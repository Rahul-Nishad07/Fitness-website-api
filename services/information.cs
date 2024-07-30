
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class information
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Information(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"select * from pc_student.information where id=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
             
                new MySqlParameter("@fname", rData.addInfo["fname"]) ,
                 new MySqlParameter("@lname",rData.addInfo["lname"]),
                   new MySqlParameter("@email",rData.addInfo["email"]),
                     new MySqlParameter("@phone",rData.addInfo["phone"]),
                       new MySqlParameter("@dateOfbirth",rData.addInfo["dateOfbirth"]),
                         new MySqlParameter("@address",rData.addInfo["address"]),
                           new MySqlParameter("@message",rData.addInfo["message"])
                 
                };


                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Already Exists";
                }
                else
                {
                    var sq=@"insert into pc_student.information(fname,lname,email,phone,dateOfbirth,address,message) values(@fname,@lname,@email,@phone,@dateOfbirth,@address,@message)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                         new MySqlParameter("@fname", rData.addInfo["fname"]),
                          new MySqlParameter("@lname",rData.addInfo["lname"]),
                            new MySqlParameter("@email",rData.addInfo["email"]),
                             new MySqlParameter("@phone",rData.addInfo["phone"]),
                              new MySqlParameter("@dateOfbirth",rData.addInfo["dateOfbirth"]),
                               new MySqlParameter("@address",rData.addInfo["address"]),
                                 new MySqlParameter("@message",rData.addInfo["message"])
                    };
                    var insertResult = ds.executeSQL(sq, insertParams);

                    resData.rData["rMessage"] = "Information Added";
                    
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