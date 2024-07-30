


using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class bmicalculator
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Bmicalculator(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"select * from pc_student.Bmicalculator where id=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
             
              
                new MySqlParameter("@id",rData.addInfo["id"]),
                 new MySqlParameter("@name",rData.addInfo["name"]),
                   new MySqlParameter("@gender",rData.addInfo["gender"]),
                     new MySqlParameter("@height", rData.addInfo["height"]),
                        new MySqlParameter("@weight", rData.addInfo["weight"]),
                         new MySqlParameter("@bmi",rData.addInfo["bmi"])
                      

                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Already User Checked BMI";
                }
                else
                {
                    var sq=@"insert into pc_student.Bmicalculator(id,name,gender,height,weight,bmi) values(@id,@name,@gender,@height,@weight,@bmi)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                         new MySqlParameter("@id",rData.addInfo["id"]),
                             new MySqlParameter("@name",rData.addInfo["name"]),
                                new MySqlParameter("@gender",rData.addInfo["gender"]),
                                  new MySqlParameter("@height", rData.addInfo["height"]),
                                    new MySqlParameter("@weight", rData.addInfo["weight"]),
                                        new MySqlParameter("@bmi",rData.addInfo["bmi"])
                    };
                    var insertResult = ds.executeSQL(sq, insertParams);

                    resData.rData["rMessage"] = "Thanks For....Checking BMI";
                    
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



