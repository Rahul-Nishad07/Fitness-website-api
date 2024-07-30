
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Text.Json;
using COMMON_PROJECT_STRUCTURE_API.services;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;

WebHost.CreateDefaultBuilder().
ConfigureServices(s =>
{
  IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
  s.AddSingleton<login>();
  s.AddSingleton<registration>();
  s.AddSingleton<information>();
  s.AddSingleton<loginnew>();
  s.AddSingleton<subscribe>();
  s.AddSingleton<getintouch>();
  s.AddSingleton<update>();
  s.AddSingleton<delete>();
  s.AddSingleton<fitness>();
  s.AddSingleton<setbodybuilding>();
  s.AddSingleton<crossfit>();
  s.AddSingleton<yoga>();
  s.AddSingleton<karate>();
  s.AddSingleton<martial>();
  s.AddSingleton<contactus>();
  s.AddSingleton<bmicalculator>();
  s.AddSingleton<plans>();
  s.AddSingleton<basicplan>();

  s.AddSingleton<classes>();
  s.AddSingleton<singleclass>();
  s.AddSingleton<getallclass>();
  s.AddSingleton<getallsingleclass>();
  s.AddSingleton<trainers>();
  s.AddSingleton<workout>();
  s.AddSingleton<gettouchall>();

  s.AddSingleton<getallSubsciber>();
  s.AddSingleton<getalluser>();
  s.AddSingleton<getallworkouts>();
  s.AddSingleton<getalltrainer>();

  s.AddSingleton<getInContact>();
  s.AddSingleton<getInformation>();

  s.AddSingleton<getAllInformation>();
  s.AddSingleton<getAllContacts>();
  s.AddSingleton<getallPackage>();
  s.AddSingleton<getallPackage>();
  s.AddSingleton<AdminLoginService>();
  s.AddSingleton<edit_classes>();
  s.AddSingleton<edit_workout>();
  s.AddSingleton<edit_trainer>();
  s.AddSingleton<edit_singleclass>();
  s.AddSingleton<edit_package>();
  s.AddSingleton<delete_classes>();
  s.AddSingleton<delete_package>();
  s.AddSingleton<delete_singleclass>();
  s.AddSingleton<delete_workout>();
  s.AddSingleton<delete_trainer>();
  s.AddSingleton<delete_users>();
  s.AddSingleton<delete_request>();
  s.AddSingleton<delete_subscribers>();
  s.AddSingleton<bodybuilding12>();
  s.AddSingleton<registrationpage>();
 s.AddSingleton<demo>();
 s.AddSingleton<emailService>();
  s.AddSingleton<generate>();
 s.AddSingleton<verify>();
  s.AddSingleton<updatepassword>();
    // s.AddSingleton<deletepayments>();
  s.AddSingleton<getallpayment>();







  




  



  s.AddAuthorization();
  s.AddControllers();
  s.AddCors();
  s.AddAuthentication("SourceJWT").AddScheme<SourceJwtAuthenticationSchemeOptions, SourceJwtAuthenticationHandler>("SourceJWT", options =>
      {
        options.SecretKey = appsettings["jwt_config:Key"].ToString();
        options.ValidIssuer = appsettings["jwt_config:Issuer"].ToString();
        options.ValidAudience = appsettings["jwt_config:Audience"].ToString();
        options.Subject = appsettings["jwt_config:Subject"].ToString();
      });
}).Configure(app =>
{
  app.UseAuthentication();
  app.UseAuthorization();
  app.UseCors(options =>
          options.WithOrigins(" http://localhost:5164", "http://localhost:5173")
          .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
  app.UseRouting();
  app.UseStaticFiles();

  app.UseEndpoints(e =>
  {
    var login = e.ServiceProvider.GetRequiredService<login>();
    var registration = e.ServiceProvider.GetRequiredService<registration>();
    var information = e.ServiceProvider.GetRequiredService<information>();
    var loginnew = e.ServiceProvider.GetRequiredService<loginnew>();
    var subscribe = e.ServiceProvider.GetRequiredService<subscribe>();
    var getintouch = e.ServiceProvider.GetRequiredService<getintouch>();
    var update = e.ServiceProvider.GetRequiredService<update>();
    var delete = e.ServiceProvider.GetRequiredService<delete>();
    var fitness = e.ServiceProvider.GetRequiredService<fitness>();
    var setbodybuilding = e.ServiceProvider.GetRequiredService<setbodybuilding>();
    var crossfit = e.ServiceProvider.GetRequiredService<crossfit>();
    var yoga = e.ServiceProvider.GetRequiredService<yoga>();
    var karate = e.ServiceProvider.GetRequiredService<karate>();
    var martial = e.ServiceProvider.GetRequiredService<martial>();
    var contactus = e.ServiceProvider.GetRequiredService<contactus>();
    var bmicalculator = e.ServiceProvider.GetRequiredService<bmicalculator>();
    var plans = e.ServiceProvider.GetRequiredService<plans>();

    var basicplan = e.ServiceProvider.GetRequiredService<basicplan>();
    var classes = e.ServiceProvider.GetRequiredService<classes>();
    var singleclass = e.ServiceProvider.GetRequiredService<singleclass>();
    var getallclass = e.ServiceProvider.GetRequiredService<getallclass>();
    var getallsingleclass = e.ServiceProvider.GetRequiredService<getallsingleclass>();
    var trainers = e.ServiceProvider.GetRequiredService<trainers>();
    var workout = e.ServiceProvider.GetRequiredService<workout>();
    var gettouchall = e.ServiceProvider.GetRequiredService<gettouchall>();
    var getallSubsciber = e.ServiceProvider.GetRequiredService<getallSubsciber>();
    var getalluser = e.ServiceProvider.GetRequiredService<getalluser>();
    var getallworkouts = e.ServiceProvider.GetRequiredService<getallworkouts>();
    var getalltrainer = e.ServiceProvider.GetRequiredService<getalltrainer>();
    var getInContact = e.ServiceProvider.GetRequiredService<getInContact>();
    var getInformation = e.ServiceProvider.GetRequiredService<getInformation>();
    var getAllInformation = e.ServiceProvider.GetRequiredService<getAllInformation>();
    var getAllContacts = e.ServiceProvider.GetRequiredService<getAllContacts>();
    var getallPackage = e.ServiceProvider.GetRequiredService<getallPackage>();
    var adminLoginService = e.ServiceProvider.GetRequiredService<AdminLoginService>();
    var edit_classes = e.ServiceProvider.GetRequiredService<edit_classes>();
    var edit_workout = e.ServiceProvider.GetRequiredService<edit_workout>();
    var edit_trainer = e.ServiceProvider.GetRequiredService<edit_trainer>();
    var edit_singleclass = e.ServiceProvider.GetRequiredService<edit_singleclass>();
    var edit_package = e.ServiceProvider.GetRequiredService<edit_package>();
    var delete_classes = e.ServiceProvider.GetRequiredService<delete_classes>();
    var delete_package = e.ServiceProvider.GetRequiredService<delete_package>();
    var delete_singleclass = e.ServiceProvider.GetRequiredService<delete_singleclass>();
    var delete_workout = e.ServiceProvider.GetRequiredService<delete_workout>();
    var delete_trainer = e.ServiceProvider.GetRequiredService<delete_trainer>();
    var delete_users = e.ServiceProvider.GetRequiredService<delete_users>();
    var delete_request = e.ServiceProvider.GetRequiredService<delete_request>();
    var delete_subscribers = e.ServiceProvider.GetRequiredService<delete_subscribers>();
    var bodybuilding12 = e.ServiceProvider.GetRequiredService<bodybuilding12>();
    var registrationpage = e.ServiceProvider.GetRequiredService<registrationpage>();
    var demo = e.ServiceProvider.GetRequiredService<demo>();
    var emailService = e.ServiceProvider.GetRequiredService<emailService>();
    var generate = e.ServiceProvider.GetRequiredService<generate>();
        var verify = e.ServiceProvider.GetRequiredService<verify>();
         var updatepassword = e.ServiceProvider.GetRequiredService<updatepassword>();
          var getallpayment = e.ServiceProvider.GetRequiredService<getallpayment>();
          // var deletepayments = e.ServiceProvider.GetRequiredService<deletepayments>();
        
          




  


    e.MapPost("login",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(await login.Login(rData));
});



    e.MapPost("registration",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(registration.Registerr(rData));
});

    e.MapPost("loginnew",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(loginnew.Loginnew(rData));
});


    e.MapPost("subscribe",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(subscribe.Subscribe(rData));
});

    e.MapPost("getintouch",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getintouch.Getintouch(rData));
});



    e.MapPut("update",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(update.Update(rData));
 });


    e.MapDelete("delete",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(delete.Delete(rData));
 });


    e.MapPost("fitness",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(fitness.Fitness(rData));
});



    e.MapPost("setbodybuilding",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(setbodybuilding.Setbodybuilding(rData));
});

    e.MapPost("crossfit",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(crossfit.Crossfit(rData));
});



    e.MapPost("yoga",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(yoga.Yoga(rData));
});



    e.MapPost("karate",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(karate.Karate(rData));
});



    e.MapPost("martial",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(martial.Martial(rData));
});



    e.MapPost("contactus",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(contactus.Contactus(rData));
});



    e.MapPost("bmicalculator",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(bmicalculator.Bmicalculator(rData));
});



    e.MapPost("plans",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(plans.Plans(rData));
});

    e.MapPost("basicplan",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(basicplan.Basicplan(rData));
});



   


    e.MapPost("classes",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(classes.Classes(rData));
 });

    e.MapPost("singleclass",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(singleclass.Singleclass(rData));
 });


    e.MapPost("getallsingleclass",
  [AllowAnonymous] async (HttpContext http) =>
  {
    var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
    requestData rData = JsonSerializer.Deserialize<requestData>(body);
    if (rData.eventID == "1001") // update
      await http.Response.WriteAsJsonAsync(getallsingleclass.Getallsingleclass(rData));
  });



    e.MapPost("getallclass",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getallclass.Getallclass(rData));
});



    e.MapPost("gettouchall",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(gettouchall.Gettouchall(rData));
});




    e.MapPost("trainers",
  [AllowAnonymous] async (HttpContext http) =>
  {
    var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
    requestData rData = JsonSerializer.Deserialize<requestData>(body);
    if (rData.eventID == "1001") // update
      await http.Response.WriteAsJsonAsync(trainers.Trainers(rData));
  });


    e.MapPost("workout",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(workout.Workout(rData));
 });


    e.MapPost("information",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(information.Information(rData));
});


    e.MapPost("getallSubsciber",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getallSubsciber.GetallSubsciber(rData));
 });


    e.MapPost("getalluser",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getalluser.Getalluser(rData));
});

    e.MapPost("getallworkouts",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getallworkouts.Getallworkouts(rData));
});

    e.MapPost("getalltrainer",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getalltrainer.Getalltrainer(rData));
});


    e.MapPost("getInContact",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getInContact.GetInContact(rData));
});



    e.MapPost("getInformation",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getInformation.GetInformation(rData));
});


    e.MapPost("getAllInformation",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getAllInformation.GetAllInformation(rData));
});



    e.MapPost("getAllContacts",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getAllContacts.GetAllContacts(rData));
});


    e.MapPost("getallPackage",
[AllowAnonymous] async (HttpContext http) =>
{
  var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
  requestData rData = JsonSerializer.Deserialize<requestData>(body);
  if (rData.eventID == "1001") // update
    await http.Response.WriteAsJsonAsync(getallPackage.GetallPackage(rData));
});



    e.MapPut("edit_classes",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(edit_classes.Edit_classes(rData));
 });


    e.MapPut("edit_workout",
     [AllowAnonymous] async (HttpContext http) =>
     {
       var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
       requestData rData = JsonSerializer.Deserialize<requestData>(body);
       if (rData.eventID == "1001") // update
         await http.Response.WriteAsJsonAsync(edit_workout.Edit_workout(rData));
     });


    e.MapPost("edit_trainer",
     [AllowAnonymous] async (HttpContext http) =>
     {
       var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
       requestData rData = JsonSerializer.Deserialize<requestData>(body);
       if (rData.eventID == "1001") // update
         await http.Response.WriteAsJsonAsync(edit_trainer.Edit_trainer(rData));
     });

    e.MapPut("edit_singleclass",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(edit_singleclass.Edit_singleclass(rData));
});


    e.MapPut("edit_package",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(edit_package.Edit_package(rData));
});


    e.MapPost("delete_classes",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(delete_classes.Delete_classes(rData));
 });




    e.MapPost("delete_package",
   [AllowAnonymous] async (HttpContext http) =>
   {
     var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
     requestData rData = JsonSerializer.Deserialize<requestData>(body);
     if (rData.eventID == "1001") // update
       await http.Response.WriteAsJsonAsync(delete_package.Delete_package(rData));
   });


    e.MapDelete("delete_singleclass",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_singleclass.Delete_singleclass(rData));
});



    e.MapPost("delete_workout",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_workout.Delete_workout(rData));
});


    e.MapPost("delete_trainer",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_trainer.Delete_trainer(rData));
});


    e.MapPost("delete_users",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_users.Delete_users(rData));
});


    e.MapPost("delete_request",
     [AllowAnonymous] async (HttpContext http) =>
    {
      var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
      requestData rData = JsonSerializer.Deserialize<requestData>(body);
      if (rData.eventID == "1001") // update
        await http.Response.WriteAsJsonAsync(delete_request.Delete_request(rData));
    });

    e.MapPost("delete_subscribers",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_subscribers.Delete_subscribers(rData));
});


    e.MapPost("bodybuilding12",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(bodybuilding12.Bodybuilding12(rData));
});



   e.MapPost("registrationpage",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(registrationpage.Registrationpage(rData));
});


   e.MapPost("demo",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(demo.Demo(rData));
});



  e.MapPost("verify",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(verify.Verifyotp(rData));
});


  e.MapPost("generate",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(generate.Generate(rData));
});


  e.MapPost("updatepassword",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(updatepassword.Updatepassword(rData));
});


    e.MapPost("getallpayment",
 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getallpayment.Getallpayment(rData));
 });


//  e.MapPost("deletepayments",
//  [AllowAnonymous] async (HttpContext http) =>
//  {
//    var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
//    requestData rData = JsonSerializer.Deserialize<requestData>(body);
//    if (rData.eventID == "1001") // update
//      await http.Response.WriteAsJsonAsync(deletepayments.Deletepayments(rData));
//  });



    e.MapPost("admin/login",
         async context =>
         {
           try
           {
             var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
             var loginRequest = JsonSerializer.Deserialize<LoginRequest>(body);

             var token = await adminLoginService.Authenticate(loginRequest.Username, loginRequest.Password);

             if (token == null)
             {
               context.Response.StatusCode = StatusCodes.Status401Unauthorized;
               await context.Response.WriteAsync("Invalid credentials.");
               return;
             }

             await context.Response.WriteAsJsonAsync(new { token });
           }
           catch (Exception ex)
           {
             context.Response.StatusCode = StatusCodes.Status500InternalServerError;
             await context.Response.WriteAsync($"An error occurred: {ex.Message}");
           }
         });


    e.MapPost("admin/logout",
         async context =>
         {
           await context.Response.WriteAsync("Logged out successfully.");
         });

    IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    e.MapGet("/dbstring",
     async c =>
     {
       dbServices dspoly = new();
       await c.Response.WriteAsJsonAsync("{'mongoDatabase':" + appsettings["mongodb:connStr"] + "," + " " + "MYSQLDatabase" + " =>" + appsettings["db:connStrPrimary"]);
     });


    e.MapGet("/bing",
        async c => await c.Response.WriteAsJsonAsync("{'Name':'Anish','Age':'26','Project':'COMMON_PROJECT_STRUCTURE_API'}"));
  });

}).Build().Run();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
public record requestData
{
  [Required]
  public string eventID { get; set; }
  [Required]
  public IDictionary<string, object> addInfo { get; set; }
}

public record responseData
{
  public responseData()
  {
    eventID = "";
    rStatus = 0;
    rData = new Dictionary<string, object>();
  }
  [Required]
  public int rStatus { get; set; } = 0;
  public string eventID { get; set; }
  public IDictionary<string, object> addInfo { get; set; }
  public IDictionary<string, object> rData { get; set; }
}


public class LoginRequest
{
  public string Username { get; set; }
  public string Password { get; set; }
  // Other properties related to login request
}















