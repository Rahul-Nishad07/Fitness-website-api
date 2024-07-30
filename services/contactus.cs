


using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class contactus
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Contactus(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"select * from pc_student.contactus where id=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
               
                   new MySqlParameter("@name",rData.addInfo["name"]),
                     new MySqlParameter("@email", rData.addInfo["email"]),
                       new MySqlParameter("@subject", rData.addInfo["subject"]) ,
                          new MySqlParameter("@message", rData.addInfo["message"]) ,
                         
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Already User Contact us";
                }
                else
                {
                    var sq=@"insert into pc_student.contactus(name,email,subject,message ) values(@name,@email,@subject,@message)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
            
                   new MySqlParameter("@name",rData.addInfo["name"]),
                     new MySqlParameter("@email", rData.addInfo["email"]),
                       new MySqlParameter("@subject", rData.addInfo["subject"]) ,
                          new MySqlParameter("@message", rData.addInfo["message"]) ,
                   
                    };
                    var insertResult = ds.executeSQL(sq, insertParams);

                    resData.rData["rMessage"] = "Thanks for the your query..";
                    
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



