using NightInn.Data;
using NightInn.Models;
using NightInn.Models.FoodModels;
using NightInnV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightInn.Services
{
    public class FoodService
    {
        private readonly Guid _userId;

        public FoodService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateFood(FoodCreate model)
        {
            var entity =
                new Food()
                {
                    OwnerId = _userId,
                    FoodName = model.FoodName,
                    Ingredients = model.Ingredients,
                    Instructions = model.Instructions,
                    FoodServingSize = model.FoodServingSize,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Foods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FoodListItem> GetFoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Foods
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FoodListItem
                                {
                                    FoodId = e.FoodId,
                                    FoodName = e.FoodName,
                                    Ingredients = e.Ingredients,
                                    Instructions = e.Instructions,
                                    FoodServingSize = e.FoodServingSize
                                }
                        );

                return query.ToArray();
            }
        }
        public FoodDetail GetFoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(e => e.FoodId == id && e.OwnerId == _userId);
                return
                    new FoodDetail
                    {
                        FoodId = entity.FoodId,
                        FoodName = entity.FoodName,
                        Ingredients = entity.Ingredients,
                        Instructions = entity.Instructions,
                        FoodServingSize = entity.FoodServingSize
                    };
            }
        }
        public bool UpdateFood(FoodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(e => e.FoodId == model.FoodId && e.OwnerId == _userId);
                
                entity.FoodName = model.FoodName;
                entity.Ingredients = model.Ingredients;
                entity.Instructions = model.Instructions;
                entity.FoodServingSize = model.FoodServingSize;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFood(int foodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(e => e.FoodId == foodId && e.OwnerId == _userId);

                ctx.Foods.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
