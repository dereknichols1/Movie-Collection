using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository
{
    public class CollectionsRepository : Repository<Collections>, ICollectionsRepository
    {

        private readonly ApplicationDbContext _db;

        public CollectionsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCollectionsListForDropDown()
        {
            return _db.Collections.Select(i => new SelectListItem()
            {
                Text = i.CollectionName,
                Value = i.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetCollectionsListForDropDown(string userId)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var cols = _db.Collections.ToList().FindAll(x => x.UserId.Equals(userId));
            foreach(var col in cols)
            {
                SelectListItem item = new SelectListItem {
                    Text = col.CollectionName,
                    Value = col.Id.ToString()
                };
                items.Add(item);
            }

            //return _db.Collections.Select(i => new SelectListItem()
            //{
            //    Text = i.CollectionName,
            //    Value = i.Id.ToString()
            //}).Where();

            return items;
        }

        public void Update(Collections collections)
        {
            var objFromDb = _db.Collections.FirstOrDefault(s => s.Id == collections.Id);

            objFromDb.CollectionName = collections.CollectionName;
            objFromDb.UserId = collections.UserId;

            _db.SaveChanges();
        }
    }
}
