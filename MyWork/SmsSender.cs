using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MyWork
{
    class MessageSender
    {

        const string accountSid = "ACfa1dc641f65b4553982e12d1ed28e783";
        const string authToken = "de34e33c7f9562be46da7dbe240ec7dc";
        const string numFrom = "+19596666446"; // номер данный твилио по умолчанию, больше никакой не работает
        public string NumTo { private get; set; } 
        public string smsCode;
        Random random = new Random();

        public MessageSender()
        {
            smsCode = random.Next().ToString();
        }

        public MessageSender(string numTo)
        {
            smsCode = random.Next().ToString();
            NumTo = numTo;
        }

        public void SendMessage()
        {
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(numFrom),
                body: "Ваш код подтверждения:  " + smsCode,
                statusCallback: new Uri("http://postb.in/r4jrqx2e"),
                to: new Twilio.Types.PhoneNumber(NumTo)
            );

            Console.WriteLine(message.Sid);
        }

        public bool CheckCode(string value)//Проверяет код отправленный и код введенный 
        {
            if (String.Equals(value, smsCode))
                return true;
            else
                return false;
        }

        


    }
}
