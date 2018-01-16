using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MovieReview_Website_Adv_DotNet.Models;
using System.Threading;
using System.Web.Routing;
using System.Data.Entity;
using System.Web.UI;

namespace MovieReview_Website_Adv_DotNet.Hubs
{
    public class ReviewHub : Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.            
            Clients.All.addNewMessageToPage(name, message);
        }
        //Function will call all the movie reviews
        //public void LoadListOfElements()
        //{

        //    List<Movie> movieList = db.Movies.ToList();
        //    foreach(var item in movieList)
        //    {
        //        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
        //        Clients.Caller.showMessage(item.Id,item.CategoryId,item.MovieName,item.Review,item.ReviewDate,item.RatingScore);
        //        //Thread.Sleep(300);
        //    }
        //}
    }
}