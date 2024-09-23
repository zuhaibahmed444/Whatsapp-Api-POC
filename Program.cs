using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using RestSharp;

class Example
{
  static void Main(string[] args)
  {

    // using twilio
    var accountSid = "Twilio_Account_ID";
    var authToken = "TWILIO_AUTH_TOKEN";
    TwilioClient.Init(accountSid, authToken);

    string studentName = "Zuhaib";      
    string rollNumber = "233"; 
    string feesType = "term 1";         
    string pendingAmount = "500";

    var messageOptions = new CreateMessageOptions(
      new PhoneNumber("whatsapp:+919777798522"));
      messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
      messageOptions.Body = $"Dear {studentName},\n\n" +
                            $"This is a gentle reminder that your fees are still pending. Below are your details:\n\n" +
                            $"- Roll Number: {rollNumber}\n" +
                            $"- Fees head : {feesType}\n"+
                            $"- Pending Fees: {pendingAmount}\n\n" +
                            "We kindly request you to clear the outstanding amount at your earliest convenience to avoid any late fees or disruption in your enrollment.\n\n" +
                            "Thank you!\n\n" ;


    var message = MessageResource.Create(messageOptions);
    Console.WriteLine("Sent Via twilio",message);



    // using gupshup 

        var client = new RestClient("https://api.gupshup.io/wa/api/v1/msg");

        var request = new RestRequest();

        request.Method = Method.Post;

        request.AddHeader("Cache-Control", "no-cache");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddHeader("apikey", "GUPSHUP_API_KEY");
        request.AddHeader("cache-control", "no-cache");

        request.AddParameter("channel", "whatsapp");
        request.AddParameter("source", "917834811114"); // Sender's phone number
        request.AddParameter("destination", "91956266236"); // Receiver's phone number
        request.AddParameter("message", "{\"type\":\"text\",\"text\":\" \n" +
                            $"Dear {studentName},\n\n" +
                            $"This is a gentle reminder that your fees are still pending. Below are your details:\n\n" +
                            $"- Roll Number: {rollNumber}\n" +
                            $"- Fees head : {feesType}\n"+
                            $"- Pending Fees: {pendingAmount}\n\n" +
                            "We kindly request you to clear the outstanding amount at your earliest convenience to avoid any late fees or disruption in your enrollment.\n\n" +
                            "Thank you!\n\n");
        request.AddParameter("src.name", "ZuhaibTestApi");

        RestResponse response = client.Execute(request);

        Console.WriteLine("Sent viw gupshup",response.Content);
  }
}
