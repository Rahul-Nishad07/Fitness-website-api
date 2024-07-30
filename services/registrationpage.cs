using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class registrationpage
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Registrationpage(requestData rData)
        {
            responseData resData = new responseData();

            try
               
               {

                var query = @"SELECT * FROM pc_student.student_data where EMAIL=@EMAIL";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
             
                 new MySqlParameter("@EMAIL",rData.addInfo["EMAIL"]),
                   new MySqlParameter("MOBILE_NO",rData.addInfo["MOBILE_NO"]),
                     new MySqlParameter("@PASSWORD", rData.addInfo["PASSWORD"]),
                     new MySqlParameter("@USERNAME", rData.addInfo["USERNAME"]) 
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Already User Subscribed";
                }

                else {

                var insertQuery = @"insert into pc_student.student_data(EMAIL,MOBILE_NO,PASSWORD,USERNAME) values(@EMAIL,@MOBILE_NO,@PASSWORD,@USERNAME)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                  
                    new MySqlParameter("@EMAIL", rData.addInfo["EMAIL"]),
                    new MySqlParameter("@MOBILE_NO", rData.addInfo["MOBILE_NO"]),
                     new MySqlParameter("@PASSWORD", rData.addInfo["PASSWORD"]),
                      new MySqlParameter("@USERNAME", rData.addInfo["USERNAME"])
                   
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Registration Successfulll";
              }
              
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
                // Log the exception as needed
            }

            return resData;
        }
    }
}