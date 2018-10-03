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
        const string numFrom = "+19596666446";
        public string numTo { private get; set; }
        public string smsCode;
        Random random = new Random();

        public MessageSender()
        {
            smsCode = random.Next().ToString();
        }

        public MessageSender(string numTo)
        {
            smsCode = random.Next().ToString();
            this.numTo = numTo;
        }

        public void SendMessage()
        {
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(numFrom),
                body: "Ваш код подтверждения:  " + smsCode,
                statusCallback: new Uri("http://postb.in/r4jrqx2e"),
                to: new Twilio.Types.PhoneNumber(numTo)
            );

            Console.WriteLine(message.Sid);
        }

        public bool CheckCode(string value)
        {
            if (string.Equals(value, smsCode))
                return true;
            else
                return false;
        }

        


    }
}
