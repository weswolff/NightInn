using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NightInn.Data;
using NightInn.Models.ThemeModels;
using NightInnV2.Models;

namespace NightInn.Services
{
    public class ThemeService
    {
        private readonly Guid _userId;

        public ThemeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTheme(ThemeCreate model)
        {
            var entity =
                new Theme()
                {
                    OwnerId = _userId,
                    ThemeId = model.ThemeId,
                    ThemeName = model.ThemeName,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Themes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ThemeListItem> GetThemes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Themes
                        .Select(
                            e =>
                                new ThemeListItem
                                {
                                    ThemeId = e.ThemeId,
                                    ThemeName = e.ThemeName,
                                }
                        );
                return query.ToArray();
            }
        }
        public ThemeDetail GetThemeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Themes
                        .Single(e => e.ThemeId == id);
                return
                    new ThemeDetail
                    {
                        ThemeId = entity.ThemeId,
                        ThemeName = entity.ThemeName,
                    };
            }
        }
        public bool UpdateTheme(ThemeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Themes
                        .Single(e => e.ThemeId == model.ThemeId);
                entity.ThemeName = model.ThemeName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTheme(int themeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Themes
                        .Single(e => e.ThemeId == themeId);
                ctx.Themes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
