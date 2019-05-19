using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using BVS.Data.Models;
using BVS.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class MessageController : Controller
    {

        //private readonly IMessageRepository repo;

        //public MessageController(IMessageRepository repo)
        //{
        //    this.repo = repo;
        //}

        public async Task InformUser(int id, IMessageRepository repo, ICollection<User> userList)
        {
            var message = await repo.GetMessage(id);         

            foreach (var user in userList)
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                mailMessage.From = new MailAddress("ltkarolissto2@gmail.com");
                mailMessage.To.Add(user.Email);
                mailMessage.Subject = "Pasikeitė bankomato būsena";
                mailMessage.Body = "Bankomatas esantis " + message.Autor.Address + " pakeitė būseną į " + message.Autor.State.ToString();
                
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("ktubvs@gmail.com","KTUBVS123");
                client.EnableSsl = true;                

                client.Send(mailMessage);
            }
           
        }

        
    }
}