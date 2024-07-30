using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class basicplan
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Basicplan(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.basicplan(name,email,address,contact,cardname,cardnumber,expMonth,expyear,cvv) values(@name,@email,@address,@contact,@cardname,@cardnumber,@expMonth,@expyear,@cvv)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                
                    new MySqlParameter("@name", rData.addInfo["name"]),
                    new MySqlParameter("@email", rData.addInfo["email"]),
                    new MySqlParameter("@address", rData.addInfo["address"]),
                    new MySqlParameter("@contact", rData.addInfo["contact"]),
                    new MySqlParameter("@cardname", rData.addInfo["cardname"]),
                    new MySqlParameter("@cardnumber", rData.addInfo["cardnumber"]),
                    new MySqlParameter("@expMonth", rData.addInfo["expMonth"]),
                    new MySqlParameter("@expyear", rData.addInfo["expyear"]),
                    new MySqlParameter("@cvv", rData.addInfo["cvv"])
                   
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Thank you Payment Successfull.....";
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
              
            }

            return resData;
        }
    }
}