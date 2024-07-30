using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class bodybuilding12
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Bodybuilding12(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"select * from pc_student.subscribe where email=@email";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
             
              
                 new MySqlParameter("@fname",rData.addInfo["fname"]),
                   new MySqlParameter("@lname",rData.addInfo["lname"]),
                     new MySqlParameter("@email", rData.addInfo["email"]),
                     new MySqlParameter("@subject", rData.addInfo["subject"]) 
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Already User Subscribed";
                }
                else
                {
                    var sq=@"insert into pc_student.subscribe(fname,lname,email,subject ) values(@fname,@lname,@email,@subject)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
           
                new MySqlParameter("@fname", rData.addInfo["fname"]) ,
                 new MySqlParameter("@lname",rData.addInfo["lname"]),
                   new MySqlParameter("@email",rData.addInfo["email"]),
                    new MySqlParameter("@subject",rData.addInfo["subject"]),
                   
                    };
                    var insertResult = ds.executeSQL(sq, insertParams);

                    resData.rData["rMessage"] = "Thanks For Subscribe Our Bodybuilding Classes";
                    
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



