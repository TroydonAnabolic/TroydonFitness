using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Models.Products.ViewModels;
using TroydonFitnessWebsite.Models.UserAccounts;
using TroydonFitnessWebsite.Pages.CustomisedModel;
using TroydonFitnessWebsite.Services;

namespace TroydonFitnessWebsite.Pages.Products.Orders
{
    public class CreateOrderModel : FilterSortModel
    {
        private readonly ProductContext _context;
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;
        private readonly IMailService _mailService;

        public CreateOrderModel(
            ProductContext context,
            IMailService mailService,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)
        {
            _context = context;
            _userManager = userManager;
            _mailService = mailService;
        }

        [BindProperty]
        public IList<Cart> CartItemsToOrder { get; set; }
        [BindProperty]
        public Cart Cart { get; set; }
        [BindProperty]
        public OrderVM OrderVM { get; set; }

        [BindProperty]
        public OrderDetailVM OrderDetailVM { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.Id == null)
            {
                return NotFound();
            }

            CartItemsToOrder = await _context.CartItems
                .Where(currentCustomer => currentCustomer.PurchaserID == user.Id) // only create orders from what is in your cart
                .Include(o => o.Diet)
                    .ThenInclude(pt => pt.PersonalTrainingSession)
                        .ThenInclude(p => p.Product)
                .Include(o => o.Supplement)
                        .ThenInclude(p => p.Product)
                .Include(o => o.TrainingEquipment)
                    .ThenInclude(o => o.Product)
                .Include(o => o.TrainingRoutine)
                    .ThenInclude(pt => pt.PersonalTrainingSession)
                        .ThenInclude(p => p.Product)
                .ToListAsync();

            return Page();
        }

        // try to delete all cart items when we submit a post button
        public async Task<IActionResult> OnPostAsync(int? id, [FromForm] WelcomeRequest request)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // create the order -- TODO Try to automatically populate user details so we can link the cart items to a specific user info, but allow edit fields (may need to inject usermanager)
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CartItemsToOrder = await _context.CartItems
                .Where(currentCustomer => currentCustomer.PurchaserID == user.Id) // only create orders from what is in your cart
                    .Include(o => o.Diet)
                        .ThenInclude(pt => pt.PersonalTrainingSession)
                            .ThenInclude(p => p.Product)
                    .Include(o => o.Supplement)
                            .ThenInclude(p => p.Product)
                    .Include(o => o.TrainingEquipment)
                        .ThenInclude(o => o.Product)
                    .Include(o => o.TrainingRoutine)
                        .ThenInclude(pt => pt.PersonalTrainingSession)
                            .ThenInclude(p => p.Product)
                .ToListAsync();

            int numberOfItemsInOrder = 0;

            var emptyOrder = new Order();
            // TODO: See if i can redirect to newly created order using View Models or 
            var entry = _context.Add(emptyOrder);

            foreach (var item in CartItemsToOrder)
            {
                // if there are items in cart
                if (item.CartID != 0)
                {
                    // for each item that is
                    numberOfItemsInOrder++;
                    // if the cart is not empty and training routine is not null then take the training routine branch to extract data
                    if (item.TrainingRoutineID != null)
                    {
                        OrderVM.Price = item.TrainingRoutine.PersonalTrainingSession.Product.Price;
                        OrderVM.Quantity = item.Quantity;
                        OrderVM.TrainingRoutine = item.TrainingRoutine;
                        OrderVM.TrainingRoutineID = item.TrainingRoutineID;
                    }
                    else if (item.DietID != null)
                    {
                        OrderVM.Diet = item.Diet;
                        OrderVM.DietID = item.Diet.DietID;
                        OrderVM.ProductName = item.Diet.PersonalTrainingSession.Product.Title;
                        OrderVM.Price = item.Diet.PersonalTrainingSession.Product.Price;
                        OrderVM.Quantity = item.Quantity;
                    }
                }
            }
            #region MyRegion
            //    List<OrderVM> OrderVMList = new List<OrderVM>(); // to hold list of Customer and order details

            //// may need to look into making orderList of training routine and order list of others
            //var orderList = (from orders in _context.TrainingRoutines
            //                 join cart in _context.CartItems on orders.TrainingRoutineID equals cart.TrainingRoutineID
            //                 select new // here we select the data from relevant parts of the database
            //                 {
            //                     //  All Ids
            //                     cart.TrainingRoutineID,
            //                     cart.PersonalTrainingSession.PersonalTrainingID,
            //                     cart.DietID,
            //                     cart.TrainingEquipmentID,
            //                     cart.SupplementID,
            //                     cart.PersonalTrainingSession.ProductID,
            //                     // from product
            //                     cart.PersonalTrainingSession.Product.Price,
            //                     cart.PersonalTrainingSession.Product.HasStock,

            //                     // from personal training
            //                     cart.PersonalTrainingSession.PTSessionType,
            //                     cart.PersonalTrainingSession.LengthOfRoutine,
            //                     cart.PersonalTrainingSession.ExperienceLevel,

            //                     // from training routine
            //                     cart.TrainingRoutine.Comments,
            //                     cart.TrainingRoutine.RoutineName,
            //                     // from diet
            //                     cart.Diet.Allergies,
            //                     // TODO: Remaining items later
            //                     // from cart
            //                     cart.PurchaserID,
            //                     cart.Quantity // TODO: transfer data into cart so we can see product details like we can see in training routine, or even do the same here
            //                 })
            //                  .ToList();

            //OrderVM objcvm = new OrderVM(); // ViewModel
            ////query getting data from database from joining two tables and storing data in customerlist
            //foreach (var item in orderList)
            //{
            //    objcvm.ProductName = item.RoutineName;
            //    objcvm.Price = item.Price;
            //    objcvm.Quantity = item.Quantity;
            //    OrderVMList.Add(objcvm);
            //}
            #endregion

            // Now copy users details
            OrderVM.LastName = user.LastName;
            OrderVM.Email = user.Email;
            if (user.AddressLine1 != null) OrderVM.AddressLine1 = user.AddressLine1;
            else OrderVM.AddressLine1 = string.Empty;
            OrderVM.AddressLine2 = user.AddressLine2;
            OrderVM.City = user.City;
            OrderVM.State = user.State;
            OrderVM.Zip = user.Zip;
            OrderVM.State = user.State;
            OrderVM.PurchaserID = user.Id;
            OrderVM.NumberOfItemsOrdered = numberOfItemsInOrder;

            entry.CurrentValues.SetValues(OrderVM);
            await _context.SaveChangesAsync();


            // pull out the order just created
            var orderCreated = _context.Orders.OrderByDescending(o => o.OrderID).FirstOrDefault();

            // now add the ordered items into the order details table
            if (CartItemsToOrder != null)
            {
                numberOfItemsInOrder = 0;

                // now add all the items in the cart
                foreach (var item in CartItemsToOrder)
                {
                    // if item being copied is of training routine
                    if (item.TrainingRoutineID != null)
                    {
                        var emptyOrderDetail = new OrderDetail();
                        var entry2 = _context.Add(emptyOrderDetail);
                        numberOfItemsInOrder++;
                        OrderDetailVM.CurrentOrderItemNumber = numberOfItemsInOrder;

                        // copy the order that was just created above, and assign to the order details table
                        OrderDetailVM.OrderID = orderCreated.OrderID;
                        OrderDetailVM.OrderDate = orderCreated.OrderDate;
                        OrderDetailVM.PurchaserID = orderCreated.PurchaserID;
                        OrderDetailVM.OrderNumber = Guid.NewGuid();

                        // now copy cart items
                        // copy the order created to the order details
                        OrderDetailVM.ProductID = CartItemsToOrder.FirstOrDefault().TrainingRoutine.PersonalTrainingSession.ProductID;
                        OrderDetailVM.TrainingRoutineID = CartItemsToOrder.FirstOrDefault().TrainingRoutineID;
                        OrderDetailVM.ProductName = CartItemsToOrder.FirstOrDefault().TrainingRoutine.PersonalTrainingSession.Product.Title;
                        OrderDetailVM.Price = CartItemsToOrder.FirstOrDefault().TrainingRoutine.PersonalTrainingSession.Product.Price;
                        OrderDetailVM.Quantity = CartItemsToOrder.FirstOrDefault().Quantity;
                        OrderDetailVM.PTSessionType = CartItemsToOrder.FirstOrDefault().TrainingRoutine.PersonalTrainingSession.PTSessionType;
                        OrderDetailVM.LengthOfRoutine = CartItemsToOrder.FirstOrDefault().TrainingRoutine.PersonalTrainingSession.LengthOfRoutine;
                        OrderDetailVM.ExperienceLevel = CartItemsToOrder.FirstOrDefault().TrainingRoutine.PersonalTrainingSession.ExperienceLevel;
                        entry2.CurrentValues.SetValues(OrderDetailVM);
                        await _context.SaveChangesAsync();

                        // email the order details 
                        await _mailService.SendRoutineOrderConfirmationEmail(request, user.Email, user.FirstName,
                            OrderDetailVM.OrderDate, OrderDetailVM.OrderNumber,
                            OrderDetailVM.ProductName, OrderDetailVM.Price, OrderDetailVM.Quantity, OrderDetailVM.PTSessionType, OrderDetailVM.LengthOfRoutine, OrderDetailVM.ExperienceLevel);
                    }
                }
                // now delete everything in the cart
                _context.CartItems.RemoveRange(CartItemsToOrder);
                await _context.SaveChangesAsync();
            }

            // sets the new ID to the order just created, by arranging all order items in the db by descending and querying the first one
            var newId = _context.OrderDetails.Where(o => o.OrderDetailID > 0).OrderByDescending(o => o.OrderID).FirstOrDefault().OrderDetailID;

            // redirect to the order that was just created, using the ID
            return newId > 0 ? RedirectToPage("./OrderDetail", new { id = newId }) : RedirectToPage("./Orders");
            // return RedirectToPage("./OrderDetail");
        }
    }
}