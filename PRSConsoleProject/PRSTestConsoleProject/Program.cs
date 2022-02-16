using PRSLibraryProject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using PRSLibraryProject.Models;
using PRSLibraryProject.Controllers;

namespace PRSTestConsoleProject {
    class Program {

        static void Print(Product product) {
            Console.WriteLine($"{product.Id,-5} {product.PartNbr,-12} {product.Name,-12} " +
                                $"{product.Price,10:c} {product.Vendor.Name,-15}");
        }

        static void Main(string[] args) {

            var context = new PRSDbContext();

            var reqlCtrl = new RequestLinesController(context);

            var reql = reqlCtrl.GetByPk(1);
            reql.Quantity = 2;
            reqlCtrl.Change(reql);







            //var userController = new RequestsController(context);

            //var reqs = reqCtrl.GetRequestsInReview(3);

            //foreach (var req in reqs) {
            //    Console.WriteLine($"{req.Description} {req.Status} {req.Total} {req.UserId}");
            //}

           // var req = reqCtrl.GetByPk(1);

            //reqCtrl.SetReview(req);
            //reqCtrl.SetRejected(req);
           // reqCtrl.SetApproved(req);

           // req = reqCtrl.GetByPk(1);

           // Console.WriteLine($"{req.Description} {req.Status} {req.Total}");












            //var newUser = new User() {
            //    Id = 0, UserName = "xx", Password = "xx", FirstName ="User", LastName = "XX",
            //    Phone = "211", Email = "xx@user.com", IsReviewer = false, IsAdmin = false
            //};

            ////userController.Create(newUser);

            //var user3 = userController.GetByPK(3);

            //if(user3 is null) {
            //    Console.WriteLine("User not found!");
            //}
            //else {
            //    Console.WriteLine($"User3: {user3.FirstName} {user3.LastName}");
            //}

            //user3.LastName = "User3";
            //userController.Change(user3);

            //var user33 = userController.GetByPK(33);

            //if (user33 is null) {
            //    Console.WriteLine("User not found!");
            //}
            //else {
            //    Console.WriteLine($"User3: {user33.FirstName} {user33.LastName}");
            //}

            //userController.Remove(4);

            //var users = userController.GetAll();       //we created the GetAll() method in the controller

            //foreach(var user in users) {
            //    Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName}");
            //}
        }
    }
}
