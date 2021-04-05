using System;
using System.Collections.Generic;

namespace SendEmailsSeparately
{
    public class EmailService
    {
        public void SendEmail(List<string> emails)
        {
            Console.WriteLine($"Email was sent To '{string.Join(", ", emails)}' ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var initialEmails = new []{ "email1@mail.com", "email2@ail.com", "email3@ml.com", "email4@ma.com" };

            bool isSeparately = true; //or false

            var emailService = new EmailService();

            List<List<string>> emailsLists = new List<List<string>>();

            ///TODO! - задача - правильно подготовить emailsLists чтобы отправить письма в зависимости от выбранного режима (isSeparately - true or false) . 
            ///Если выбрано isSeparately = true - должно быть отправлено initialEmails.Length писем, каждое из которых содержит одного получателя 
            ///Если выбрано isSeparately = false - должно быть отправлено одно письмо с initialEmails.Length получателей

            ///
            /// Здесь ваш код!!!
            ///

            //отправить письма
            foreach (var emails in emailsLists)
                emailService.SendEmail(emails);
        }
    }
}
