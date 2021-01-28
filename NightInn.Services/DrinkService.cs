using NightInn.Data;
using NightInn.Models.DrinkModels;
using NightInnV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Services
{
    public class DrinkService
    {
        private readonly Guid _userId;

        public DrinkService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateDrink(DrinkCreate model)
        {
            var entity =
                new Drink()
                {
                    OwnerId = _userId,
                    DrinkName = model.DrinkName,
                    DrinkAbv = model.DrinkAbv,
                    Ingredients = model.Ingredients,
                    Instructions = model.Instructions,
                    DrinkServingSize = model.DrinkServingSize,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Drinks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DrinkListItem> GetDrinks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Drinks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new DrinkListItem
                            {
                                DrinkId = e.DrinkId,
                                DrinkName = e.DrinkName,
                                DrinkServingSize = e.DrinkServingSize,
                            }
                        );

                return query.ToArray();
            }
        }
        public DrinkDetail GetDrinkById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drinks
                        .Single(e => e.DrinkId == id && e.OwnerId == _userId);
                return
                    new DrinkDetail
                    {
                        DrinkId = entity.DrinkId,
                        DrinkName = entity.DrinkName,
                        DrinkAbv = entity.DrinkAbv,
                        Ingredients = entity.Ingredients,
                        Instructions = entity.Instructions,
                        DrinkServingSize = entity.DrinkServingSize,
                    };
            }
        }
        public bool UpdateDrink(DrinkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drinks
                        .Single(e => e.DrinkId == model.DrinkId && e.OwnerId == _userId);
                entity.DrinkName = model.DrinkName;
                entity.DrinkAbv = model.DrinkAbv;
                entity.Ingredients = model.Ingredients;
                entity.Instructions = model.Instructions;
                entity.DrinkServingSize = model.DrinkServingSize;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteDrink(int drinkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Drinks
                        .Single(e => e.DrinkId == drinkId && e.OwnerId == _userId);
                
                ctx.Drinks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
